using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.Mvvm.Messaging;
using PDFIn.Asset;
using PDFIn.Helper;
using PDFIn.Manager;
using PDFIn.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using System.IO;
using PDFIn.Messenger;
using iText.Kernel.Pdf;

namespace PDFIn.ViewModel
{
    public partial class StartWindowViewModel : ObservableRecipient
    {
        [ObservableProperty]
        private bool _toClose;

        public StartWindowViewModel()
        {
            
        }

        [RelayCommand]
        private void OpenFile()
        {
            string filePath = OpenFileHelper.GetFilePathOrEmpty(OpenFileHelper.FileType.PDF);
            if (filePath != string.Empty)
            {
                PdfReader reader = new PdfReader(filePath);
                if (reader.IsEncrypted())
                {

                }

                ToClose = true;
                WindowManager.Show(StaticName.MainWindowName);
                WeakReferenceMessenger.Default.Send(new FilePathMessenger(filePath));
            }
        }
    }
}
