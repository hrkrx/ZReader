using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eBdb.EpubReader;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace Util
{
	public class eBook
	{
		Epub eStory;

		public eBook()
		{

		}

		public eBook(String filePath)
		{
			eStory = new Epub(filePath);
		}

		public ImageSource getBookCover()
		{
			String base64String = "";
			foreach (var item in eStory.ExtendedData.Keys) {
				if (item.ToString().ToUpper().Contains("COVER")) {
					try {
						base64String = (eStory.ExtendedData[item] as ExtendedData).Content;
						return BitmapFromBase64(base64String);
					}
					catch (Exception) {	
						throw;
					}
				}
			}
			return null;
		}

		public String getTitle()
		{
			return eStory.Title[0];
		}

		public static BitmapSource BitmapFromBase64(string b64string)
		{
			var bytes = Convert.FromBase64String(b64string);

			using (var stream = new MemoryStream(bytes)) {
				return BitmapFrame.Create(stream,
					BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
			}
		}
	}
}
