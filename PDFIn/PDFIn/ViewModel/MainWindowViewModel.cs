using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFIn.ViewModel
{
    public partial class MainWindowViewModel : ObservableRecipient, IRecipient<ValueChangedMessage<string>>
    {
        private string filePath = string.Empty;
        MainWindowViewModel()
        { 

        }
        public void Receive(ValueChangedMessage<string> message)
        {
            filePath = message.Value;
        }
    }
}
