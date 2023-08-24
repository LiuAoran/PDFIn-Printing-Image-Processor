using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDFIn.Messenger;
using iText.Kernel.Pdf.Colorspace;
using iText.Kernel.Pdf;

namespace PDFIn.ViewModel
{
    public partial class MainWindowViewModel : ObservableRecipient
    {
        private string filePath = string.Empty;
        private PdfDocument document;

        public MainWindowViewModel()
        {
            RegistMessenger();
        }

        private void RegistMessenger()
        {
            WeakReferenceMessenger.Default.Register<FilePathMessenger>(this, (r, m) =>
            {
                InitPDFDocument(m.Value);
            });
        }

        private void InitPDFDocument(string filePath)
        {
            document = new PdfDocument(new PdfWriter(filePath));
        }
    }
}
