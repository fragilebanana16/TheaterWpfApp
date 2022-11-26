using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.Utility;
using FFMpegCore;
using System.IO;
using System.Diagnostics;
/// <summary>
/// 1、可计算运行时间
/// </summary>
namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private VideoApp vidApp = null;
        public MainWindow()
        {
            InitializeComponent();
            this.vidApp = new VideoApp();
            //this.loadingCircle.Visibility = Visibility.Hidden;
            //this.lbl1.Visibility = Visibility.Hidden;
            //this.lbl2.Visibility = Visibility.Hidden;
            //this.lbl3.Visibility = Visibility.Hidden;

            // Config first
            GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"H:\csharpProjects\ffmpeg-5.1.2-full_build-shared\ffmpeg-5.1.2-full_build-shared\bin", TemporaryFilesFolder = @"H:\csharpProjects\WpfApp" });
        }

        /// <summary>
        /// Home
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string dirPath = @"G:\迅雷下载\Cyberpunk.Edgerunners.S01.JAPANESE.1080p.NF.WEB-DL.x265.10bit.HDR.DDP5.1-SMURF[rartv]";
            string[] files = Directory.GetFiles(dirPath, "*.mkv", SearchOption.TopDirectoryOnly);
            for (int vidIndex = 0; vidIndex < files.Length; vidIndex++)
            {
                FFMpeg.Snapshot(files[vidIndex], @"H:\csharpProjects\WpfApp\" + vidIndex + ".png");
                //var source = FFProbe.Analyse(files[vidIndex]);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(@"H:\csharpProjects\WpfApp\WpfApp\Protocol.mkv");
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        //private async void RadioButton_Checked(object sender, RoutedEventArgs e)
        //{
        //    this.loadingCircle.Visibility = Visibility.Visible;
        //    string imagePath = string.Empty;
        //    string imagePath2 = string.Empty;
        //    string imagePath3 = string.Empty;
        //    // 支持刷新封面往后查看
        //    var task = Task.Run(() =>
        //    {
        //        imagePath = this.vidApp.GetpicFromvideo(@"H:\csharpProjects\WpfApp\WpfApp\Protocol.mkv", "160*100", "00:00:05", false);
        //        imagePath2 = this.vidApp.GetpicFromvideo(@"G:\迅雷下载\Cyberpunk.Edgerunners.S01.JAPANESE.1080p.NF.WEB-DL.x265.10bit.HDR.DDP5.1-SMURF[rartv]\Cyberpunk.Edgerunners.S01E02.Like.A.Boy.1080p.NF.WEB-DL.DUAL.DDP5.1.HDR.H.265-SMURF.mkv", "160*100", "00:00:56", false);
        //        imagePath3 = this.vidApp.GetpicFromvideo(@"G:\迅雷下载\Cyberpunk.Edgerunners.S01.JAPANESE.1080p.NF.WEB-DL.x265.10bit.HDR.DDP5.1-SMURF[rartv]\Cyberpunk.Edgerunners.S01E03.Smooth.Criminal.1080p.NF.WEB-DL.DUAL.DDP5.1.HDR.H.265-SMURF.mkv", "160*100", "00:00:44", false);

        //        if (string.IsNullOrEmpty(imagePath))
        //        {
        //            HandyControl.Controls.MessageBox.Warning("封面获取失败", "FFMpeg");
        //        }

        //        Thread.Sleep(25000); // 等待完成，待优化
        //    });

        //    await task;
        //    this.lbl1.Visibility = Visibility.Visible;
        //    this.lbl2.Visibility = Visibility.Visible;
        //    this.lbl3.Visibility = Visibility.Visible;
        //    this.lbl1.Content = System.IO.Path.GetFileNameWithoutExtension(imagePath);
        //    this.lbl2.Content = System.IO.Path.GetFileNameWithoutExtension(imagePath2);
        //    this.lbl3.Content = System.IO.Path.GetFileNameWithoutExtension(imagePath3);
        //    this.imageViewer.Source = new BitmapImage(new Uri(imagePath));
        //    this.imageViewer2.Source = new BitmapImage(new Uri(imagePath2));
        //    this.imageViewer3.Source = new BitmapImage(new Uri(imagePath3));
        //    this.loadingCircle.Visibility = Visibility.Hidden;
        //}



        //private void Button_Movie_Click(object sender, RoutedEventArgs e)
        //{
        //    MainFrame.Content = new MoviePage();
        //}

        //private void Button_Other_Click(object sender, RoutedEventArgs e)
        //{
        //    MainFrame.Content = new OtherPage();
        //}
    }
}
