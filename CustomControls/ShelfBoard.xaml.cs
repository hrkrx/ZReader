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
	/// Interaktionslogik für ShelfBoard.xaml
	/// </summary>
	public partial class ShelfBoard : UserControl
	{
		public ShelfBoard(double width)
		{
			InitializeComponent();
			this.Measure(new Size(double.PositiveInfinity, 200));
			this.Arrange(new Rect(0, 0, width, 200));
			if ((this.ActualWidth % 200) > 0)
			{
				this.Width = this.ActualWidth - (this.ActualWidth % 200);
			}
			LoadBooks();
		}

		private void LoadBooks()
		{
			int bCount = (int)(this.ActualWidth / 200);
			for (int i = 0; i < bCount; i++)
			{
				BoardItem b = new BoardItem();
				b.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
				b.VerticalAlignment = System.Windows.VerticalAlignment.Center;
				//b.isEmpty = true;
				spBoard.Children.Add(b);
			}
		}
	}
}
