using CommunityToolkit.Mvvm.Input;
using PDFIn.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PDFIn.ViewModel
{
    class StartWindowViewModel : INotifyPropertyChanged
    {

        public ICommand OpenFileCommand { get; set; }

        public StartWindowViewModel()
        {
            OpenFileCommand = new RelayCommand(OpenFile);
        }

        private void OpenFile()
        {
            if (!(OpenFileHelper.GetFilePathOrEmpty(OpenFileHelper.FileType.PDF) == string.Empty))
            {

            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
