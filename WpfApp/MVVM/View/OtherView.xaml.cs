using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp.MVVM.View
{
    /// <summary>
    /// Interaction logic for OtherView.xaml
    /// </summary>
    public partial class OtherView : UserControl
    {
        private MovieInfo movieInfos = new MovieInfo();

        private Scraper scraper = new Scraper();

        public OtherView()
        {
            InitializeComponent();
            this.bindUrl.SetBinding(System.Windows.Controls.Image.SourceProperty, new Binding("Url") { Source = movieInfos });
            this.DataContext = scraper;
        }


        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {

            var web = new HtmlWeb();
            var doc = web.Load("https://movie.douban.com/top250?start=175&filter=");
            HtmlNodeCollection movies = doc.DocumentNode.SelectNodes("//*[@class='item']");
            var a = RetrieveImages("https://movie.douban.com/top250?start=175&filter=");
            foreach (var mv in movies)
            {
                var title = HttpUtility.HtmlDecode(mv.SelectSingleNode(".//span[@class='title']")?.InnerText);
                var starNode = mv.SelectSingleNode(".//div[@class='star']");
                var rating = HttpUtility.HtmlDecode(mv.SelectSingleNode(".//span[@class='rating_num']")?.InnerText);
                var ratingPeople = HttpUtility.HtmlDecode(starNode.SelectNodes(".//span")[3]?.InnerText);
                var topComment = HttpUtility.HtmlDecode(mv.SelectSingleNode(".//span[@class='inq']")?.InnerText); // no comments found, string will be null, null will output empty
                Console.WriteLine("{0} - {1} - {2} - {3}", title, rating, topComment, ratingPeople);

                scraper.Entries.Add(new EntryModel { Title = title, Description = topComment });
            }
        }

        private List<string> RetrieveImages(string address)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            List<string> imgList = new List<string>();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load(wc.OpenRead(address));  //or whatever HTML file you have 
            HtmlNodeCollection imgs = doc.DocumentNode.SelectNodes("//img[@src]");
            if (imgs == null)
                return new List<string>();

            //foreach (HtmlNode imgg in imgs)
            //{
            //    if (imgg.Attributes["src"] == null)
            //        continue;
            HtmlAttribute src = imgs[0].Attributes["src"];
            movieInfos.Url = src.Value;
            HtmlAttribute src2 = imgs[1].Attributes["src"];

            imgList.Add(src.Value);
            //Do something with src.Value such as Get the image and save it to pictureBox
            this.img.Source = BitmapToImageSource(GetImage(src.Value));
            this.img2.Source = BitmapToImageSource(GetImage(src2.Value));

            //}
            return imgList;
        }

        private Bitmap GetImage(string url)
        {
            System.Net.WebRequest request = System.Net.WebRequest.Create(url);
            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream = response.GetResponseStream();
            Bitmap bmp = new Bitmap(responseStream);
            responseStream.Dispose();
            return bmp;
        }

        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                return bitmapimage;
            }
        }
    }


    public class Scraper
    {
        private ObservableCollection<EntryModel> _entries = new ObservableCollection<EntryModel>();

        public ObservableCollection<EntryModel> Entries
        {
            get { return _entries; }
            set { _entries = value; }
        }
    }
    public class EntryModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
    } 

    class MovieInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string url;

        public string Url
        {
            get { return this.url; }
            set
            {
                this.url = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Url"));
            }
        }
    }
}
