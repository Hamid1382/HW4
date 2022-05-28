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
using System.Windows.Shapes;
using BLL;

namespace GUI
{
	/// <summary>
	/// Interaction logic for Login.xaml
	/// </summary>
	public partial class Login : Window
	{
		public Login()
		{
			InitializeComponent();
		}

		private void Login_Click(object sender, RoutedEventArgs e)
		{
			var a = Logic.Login(username.Text, password.Text);
			if (a)
			{
				this.ErrorMessage.Visibility = Visibility.Collapsed;
				Close();
			}
			else
			{
				this.ErrorMessage.Visibility = Visibility.Visible;
			}
		}
	}
}
