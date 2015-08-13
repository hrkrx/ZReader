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

namespace CustomControls
{
	/// <summary>
	/// Interaktionslogik für ItemShelf.xaml
	/// </summary>
	public partial class ItemShelf : UserControl
	{
		public ItemShelf()
		{
			InitializeComponent();
			this.SizeChanged += ItemShelf_SizeChanged;
		}

		void ItemShelf_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			LoadBoards();
		}
		public ItemShelf(double width, double height)
			:base()
		{
			this.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
			this.Arrange(new Rect(0, 0, width, height));
			if ((this.ActualWidth % 200) > 0)
			{
				this.Width = this.ActualWidth - (this.ActualWidth % 200);
			}
			if ((this.ActualHeight % 200) > 0)
			{
				this.Height = this.ActualHeight - (this.ActualWidth % 200);
			}
			LoadBoards();
		}

		private void LoadBoards()
		{
			int bCount = (int)(this.ActualHeight / 200);
			spShelf.Children.Clear();
			for (int i = 0; i < bCount; i++)
			{
				ShelfBoard s = new ShelfBoard(this.ActualWidth);
				s.VerticalContentAlignment = System.Windows.VerticalAlignment.Top;
				s.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
				spShelf.Children.Add(s);
			}
		}

		public void ApplyResize(double width, double height)
		{
			this.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
			this.Arrange(new Rect(0, 0, width, height));
			if ((width % 200) > 0)
			{
				this.Width = width - (width % 200);
			}
			if ((height % 200) > 0)
			{
				this.Height = height - (height % 200);
			}
		}
	}
}
