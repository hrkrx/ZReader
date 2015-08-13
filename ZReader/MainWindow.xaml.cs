using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ZReader
{
	/// <summary>
	/// Interaktionslogik für MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		BackgroundWorker bw = new BackgroundWorker();
		Splash splash = new Splash();

		public MainWindow()
		{
			LoadData();
			InitializeComponent();
			this.SizeChanged += MainWindow_SizeChanged;
		}

		void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			isItemShelf.ApplyResize(this.ActualWidth, this.ActualHeight);
		}

		#region PreLoading
		private void LoadData()
		{
			this.Visibility = System.Windows.Visibility.Hidden;
			bw.ProgressChanged += bw_ProgressChanged;
			bw.RunWorkerCompleted += bw_RunWorkerCompleted;
			bw.DoWork += bw_DoWork;
			bw.WorkerReportsProgress = true;
			bw.RunWorkerAsync();
		}

		void bw_DoWork(object sender, DoWorkEventArgs e)
		{
			this.Dispatcher.Invoke(new Action(() =>
			{
				splash.Show();
				for (int i = 0; i < 6; i++) {
					SideBar.AddMenuItem("Test " + i, null);
				}
			}));
			for (int i = 0; i < 100; i++)
			{
				Thread.Sleep(1);
				bw.ReportProgress(i);
			}
		}

		void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.Dispatcher.Invoke(new Action(() =>
			{

				splash.Close();
				this.Visibility = System.Windows.Visibility.Visible;
			}));
		}

		void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			this.Dispatcher.Invoke(new Action(() =>
			{

				splash.setProgress(e.ProgressPercentage);

			}));
		}
		#endregion

	}
}
