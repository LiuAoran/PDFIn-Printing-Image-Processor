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

namespace PDFIn.ViewModel
{
    public partial class StartWindowViewModel : ObservableRecipient
    {
        [ObservableProperty]
        private bool _toClose;

        [RelayCommand]
        private void OpenFile()
        {
            string filePath = OpenFileHelper.GetFilePathOrEmpty(OpenFileHelper.FileType.PDF);
            if (filePath != string.Empty)
            {
                WindowManager.Show(StaticName.MainWindowName);
                WeakReferenceMessenger.Default.Send(new ValueChangedMessage<string>(filePath));
                ToClose = true; 
            }
        }
    }
}
