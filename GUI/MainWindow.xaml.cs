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
using BLL;

namespace GUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Save_Session_Click(object sender, RoutedEventArgs e) =>
			(new Save()).ShowDialog();
		private void Load_Session_Click(object sender, RoutedEventArgs e) => 
			(new Load()).ShowDialog();
		private void New_Session_Click(object sender, RoutedEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Do you really want to start a new session?",
										  "Confirmation",
										  MessageBoxButton.YesNo,
										  MessageBoxImage.Question);
			if (result == MessageBoxResult.Yes)
			{
				DataStorage.NewSession();
			}
		}
		private void Reload_Session_Click(object sender, RoutedEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Do you really want to reload session from the file?",
										  "Confirmation",
										  MessageBoxButton.YesNo,
										  MessageBoxImage.Question);
			if (result == MessageBoxResult.Yes)
			{
				//reload session
			}
		}
		private void Sign_In_Click(object sender, RoutedEventArgs e) => 
			(new SignIn()).ShowDialog();

		private void Login_Click(object sender, RoutedEventArgs e) =>
			(new Login()).ShowDialog();
		private void Log_Out_Click(object sender, RoutedEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Do you really want to log out?",
										  "Confirmation",
										  MessageBoxButton.YesNo,
										  MessageBoxImage.Question);
			if (result == MessageBoxResult.Yes)
			{
				//Log out
			}
		}
		private void Add_Goods_click(object sender, RoutedEventArgs e) =>
			(new AddStuff()).ShowDialog();
	}
}
