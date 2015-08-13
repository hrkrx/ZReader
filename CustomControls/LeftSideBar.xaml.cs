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
	/// Interaktionslogik für LeftSideBar.xaml
	/// </summary>
	public partial class LeftSideBar : UserControl
	{
		bool open = false;
		public LeftSideBar()
		{
			InitializeComponent();
			this.Margin = new Thickness(-250, 0, 0, 0);
		}

		public void AddMenuItem(string title, MouseButtonEventHandler action)
		{
			var x = new SideBarItem();
			x.lbContent.Content = title;
			MenuPanel.Children.Add(x);
			if (action != null) {
				x.itemGrid.MouseUp += action;
				x.lbContent.MouseUp += action;
			}
		}

		public void RemoveMenuItem(string title)
		{
		}

		#region Events
		private void Ellipse_MouseEnter_1(object sender, MouseEventArgs e)
		{
			var x = new SolidColorBrush(Colors.Orange);
			x.Opacity = 0.5;
			elButton.Fill = x;
		}

		private void Ellipse_MouseLeave_1(object sender, MouseEventArgs e)
		{
			var x = new SolidColorBrush(Colors.White);
			x.Opacity = 0.5;
			elButton.Fill = x;
		}

		private void elButton_MouseDown(object sender, MouseButtonEventArgs e)
		{
			elButton.Fill.Opacity = 1;
		}

		private void elButton_MouseUp(object sender, MouseButtonEventArgs e)
		{
			elButton.Fill.Opacity = 0.5;
			if (open) {
				this.Margin = new Thickness(-250, 0, 0, 0);
			}
			else {
				this.Margin = new Thickness(0, 0, 0, 0);
			}
			open = !open;
		}
		#endregion
	}
}
