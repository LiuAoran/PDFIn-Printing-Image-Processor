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

        /// <summary>
        /// 指定文件类型，打开文件浏览器，读取文件
        /// </summary>
        /// <param name="fileType">文件类型枚举</param>
        /// <returns>设置成功则返回文件绝对路径，反之返回string.empty</returns>
        public static string GetFilePathOrEmpty(FileType fileType)
        {
            string selectedFilePath = string.Empty;
            OpenFileDialog openFileDialog = new();
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
