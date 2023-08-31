using CommunityToolkit.Mvvm.Messaging;
using iText.Kernel.Pdf;
using PDFIn.Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFIn.ViewModel
{
    public class PasswordDialogViewModel
    {

        public PasswordDialogViewModel() => RegistMessenger();

        private void RegistMessenger()
        {
            WeakReferenceMessenger.Default.Register<PdfReaderMessenger>(this, (r, m) =>
            {

            });
        }
    }
}
