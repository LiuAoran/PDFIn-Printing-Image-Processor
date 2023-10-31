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
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Colors;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.IO;
using System.Windows;
using iText.Layout;
using iText.IO.Image;
using System.Windows.Media;
using MuPDFCore; 
using System.Windows.Media.Media3D;
using System.Threading;

namespace PDFIn.ViewModel
{
    public partial class MainWindowViewModel : ObservableRecipient
    {
        private string filePath = string.Empty;
        private PdfDocument document;

        [ObservableProperty]
        private BitmapImage? _imageSource;

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

        public async Task LoadImageAsync(MuPDFDocument document, int pageIndex)
        {
            ImageSource = null;
            BitmapImage bitmap = await Task.Run(() => LoadImage(document, pageIndex));

            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                ImageSource = bitmap;
            }));
        }
        private BitmapImage LoadImage(MuPDFDocument document, int pageIndex)
        {
            BitmapImage bitmap = new BitmapImage();
            MuPDFPage page = document.Pages[pageIndex];
            // 将 byte[] 转换为 BitmapImage 
            int width = (int)page.Bounds.Width; // 你的图像宽度
            int height = (int)page.Bounds.Height; // 你的图像高度
            double dpiX = 96; // 水平分辨率
            double dpiY = 96; // 垂直分辨率
            int bytesPerPixel = 3; // 每像素字节数

            int stride = width * bytesPerPixel; // 计算 stride
            PixelFormat pixelFormat = System.Windows.Media.PixelFormats.Bgr24; // 或者其他合适的像素格式
            double zoomLevel = 1;
            
            byte[] renderedImage = document.Render(pageIndex, zoomLevel, MuPDFCore.PixelFormats.BGR, true);
            // 使用正确的宽度、高度、分辨率和像素格式
            BitmapSource bitmapSource = BitmapSource.Create(
                width, height, dpiX, dpiY, pixelFormat, null, renderedImage, stride);
            // 从BitmapSource创建BitmapImage
            BitmapImage bitmapImage = new BitmapImage();
            PngBitmapEncoder encoder = new PngBitmapEncoder(); 
            encoder.Frames.Add(BitmapFrame.Create(bitmapSource));

            using (MemoryStream memoryStream = new MemoryStream())
            {
                encoder.Save(memoryStream);
                memoryStream.Position = 0;

                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
            }
            return bitmapImage;
        }

        private async void InitPDFDocument(string filePath)
        {
            using MuPDFContext ctx = new MuPDFContext();
            using MuPDFDocument document = new MuPDFDocument(ctx, filePath);
            int pageIndex = 0;
            try
            {
                MuPDFPage page = document.Pages[pageIndex];

            }
            catch
            {
                MessageBox.Show("文档损坏");
                return;
            }
            await LoadImageAsync(document, pageIndex);
        }
    }
}
