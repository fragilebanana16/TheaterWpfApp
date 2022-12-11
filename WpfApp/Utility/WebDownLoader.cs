using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfApp.Utility
{
    public class WebDownLoader
    {
		public Task<Image> GetFavicon(string domain)
		{
			int numeric;
			if (domain == null)
			{
				throw new ArgumentNullException("domain");
			}
			else if (Int32.TryParse(domain, out numeric))
			{
				throw new ArgumentException("domain");
			}
			return GetFaviconInternal(domain);
		}

		public async Task<Image> GetFaviconInternal(string domain)
		{
			WebClient webClient = new WebClient();
			byte[] bytes = await webClient.DownloadDataTaskAsync("http://" + domain + "/favicon.ico");
			return MakeImageControl(bytes);
		}

		private static Image MakeImageControl(byte[] bytes)
		{
			Image imageControl = new Image();
			BitmapImage bitmapImage = new BitmapImage();
			bitmapImage.BeginInit();
			bitmapImage.StreamSource = new MemoryStream(bytes);
			bitmapImage.EndInit();
			imageControl.Source = bitmapImage;
			imageControl.Width = 16;
			imageControl.Height = 16;
			return imageControl;
		}
	}
}
