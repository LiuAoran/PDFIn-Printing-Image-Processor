using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDFIn.Messenger;
using MuPDFCore;

namespace PDFIn.ViewModel
{
    public partial class MainWindowViewModel : ObservableRecipient
    {
        private string filePath = string.Empty;
        private MuPDFDocument? document = null;
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
            using MuPDFContext ctx = new MuPDFContext();
            using MuPDFDocument document = new MuPDFDocument(ctx, filePath);

            int pageIndex = 2;

            double zoomLevel = 6;

            document.SaveImage(pageIndex, zoomLevel, PixelFormats.RGBA, "output.png", RasterOutputFileTypes.PNG);
        }
    }
}
