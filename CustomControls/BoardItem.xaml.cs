using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Util;

namespace CustomControls
{
	/// <summary>
	/// Interaktionslogik für BoardItem.xaml
	/// </summary>
	public partial class BoardItem : UserControl
	{
		public BoardItem()
		{
			InitializeComponent();
		}

		private bool empty;
		public bool isEmpty
		{
			get { return empty; }
			set
			{
				if (value)
				{
					imgImage.Visibility = System.Windows.Visibility.Hidden;
					lbTitle.Content = "";
				}
				else
				{
					imgImage.Visibility = System.Windows.Visibility.Visible;
				}
				empty = value;
			}
		}

		public void setContentFromEBook(eBook ebook)
		{
			setTitle(ebook.getTitle());
			setImage(ebook.getBookCover());
		}

		public void setTitle(string title)
		{
			lbTitle.Content = title;
		}

		public void setImage(ImageSource source)
		{
			imgImage.Source = source;
		}

		private void imgImage_MouseUp(object sender, MouseButtonEventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.ShowDialog();
			string tmpfile = ofd.FileName;
			eBook tmpEbook = new eBook(tmpfile);
			setContentFromEBook(tmpEbook);
		}
	}
}
