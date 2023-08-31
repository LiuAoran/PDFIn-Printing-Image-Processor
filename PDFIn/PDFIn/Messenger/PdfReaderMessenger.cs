using CommunityToolkit.Mvvm.Messaging.Messages;
using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFIn.Messenger
{
    class PdfReaderMessenger : ValueChangedMessage<PdfReader>
    {
        public PdfReaderMessenger(PdfReader value) : base(value)
        {
        }
    }
}
