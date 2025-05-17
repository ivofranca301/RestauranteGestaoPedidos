using PdfSharp.Drawing;
using PdfSharp.Pdf;
using RestauranteGestaoPedidos.Controllers;
using System;
using System.IO;
using System.Windows.Forms;

namespace RestauranteGestaoPedidos.Views
{
    public partial class FormRelatorio : Form
    {
        private readonly PedidoController _pedidoController;

        public FormRelatorio(PedidoController pedidoController)
        {
            InitializeComponent();
            _pedidoController = pedidoController;
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Salvar Relatório de Pedidos";
                saveFileDialog.FileName = "RelatorioPedidos.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GerarRelatorioPDF(saveFileDialog.FileName);
                    MessageBox.Show("Relatório gerado com sucesso!", "Sucesso");
                }
            }
        }

        private void GerarRelatorioPDF(string filePath)
        {
            using (var document = new PdfDocument())
            {
                var page = document.AddPage();
                var gfx = XGraphics.FromPdfPage(page);
                var fontTitle = new XFont("Arial", 16);
                var fontText = new XFont("Arial", 12);

                gfx.DrawString("Relatório de Pedidos", fontTitle, XBrushes.Black, new XRect(0, 20, page.Width, 40), XStringFormats.Center);

                var pedidos = _pedidoController.ListarPedidos();
                int yPosition = 80;

                foreach (var pedido in pedidos)
                {
                    gfx.DrawString($"Pedido #{pedido.Id}", fontText, XBrushes.Black, new XRect(50, yPosition, page.Width, 20), XStringFormats.TopLeft);
                    yPosition += 20;
                    gfx.DrawString($"Cliente: {pedido.Cliente}", fontText, XBrushes.Black, new XRect(50, yPosition, page.Width, 20), XStringFormats.TopLeft);
                    yPosition += 20;
                    gfx.DrawString($"Data: {pedido.Data:dd/MM/yyyy}", fontText, XBrushes.Black, new XRect(50, yPosition, page.Width, 20), XStringFormats.TopLeft);
                    yPosition += 20;
                    gfx.DrawString($"Status: {pedido.Status}", fontText, XBrushes.Black, new XRect(50, yPosition, page.Width, 20), XStringFormats.TopLeft);
                    yPosition += 20;
                    gfx.DrawString($"Total: €{pedido.Total:F2}", fontText, XBrushes.Black, new XRect(50, yPosition, page.Width, 20), XStringFormats.TopLeft);
                    yPosition += 30;

                    if (yPosition > page.Height - 50)
                    {
                        page = document.AddPage();
                        gfx = XGraphics.FromPdfPage(page);
                        yPosition = 20;
                    }
                }

                document.Save(filePath);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}