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
	/// Interaktionslogik für SideBarItem.xaml
	/// </summary>
	public partial class SideBarItem : UserControl
	{
		public SideBarItem()
		{
			InitializeComponent();
		}

		private void Grid_MouseEnter_1(object sender, MouseEventArgs e)
		{
			itemGrid.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xFD, 0xC2, 0x43));
			//lbContent.Foreground = new SolidColorBrush(Colors.Black);
			lLine.Stroke = new SolidColorBrush(Colors.Orange);
		}

		private void itemGrid_MouseLeave(object sender, MouseEventArgs e)
		{
			itemGrid.Background = new SolidColorBrush(Colors.Orange);
			lbContent.Foreground = new SolidColorBrush(Colors.White);
			lLine.Stroke = new SolidColorBrush(Colors.White);
		}

		private void itemGrid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{

			itemGrid.Background = new SolidColorBrush(Colors.White);
			lbContent.Foreground = new SolidColorBrush(Colors.Black);
			lLine.Stroke = new SolidColorBrush(Colors.Orange);
		}

		private void itemGrid_PreviewMouseUp(object sender, MouseButtonEventArgs e)
		{
			itemGrid.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xFD, 0xC2, 0x43));
			//lbContent.Foreground = new SolidColorBrush(Colors.Black);
			lLine.Stroke = new SolidColorBrush(Colors.Orange);
		}
	}
}
