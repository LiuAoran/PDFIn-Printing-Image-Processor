using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFIn.Helper
{
    class OpenFileHelper
    {
        public enum FileType
        {
            PDF,
            Image
        }

        public static string GetFilePathOrEmpty(FileType fileType)
        {
            string selectedFilePath = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (fileType == FileType.PDF)
            {
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            }

            if (openFileDialog.ShowDialog() == true)
            {
                selectedFilePath = openFileDialog.FileName;
            }
            return selectedFilePath;
        }
    }
}
