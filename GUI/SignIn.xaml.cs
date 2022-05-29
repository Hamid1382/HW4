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
using System.Text.RegularExpressions;

namespace GUI
{
	/// <summary>
	/// Interaction logic for SignIn.xaml
	/// </summary>
	public partial class SignIn : Window
	{
		public SignIn()
		{
			InitializeComponent();
		}
		public bool reMatch(TextBox textBox, string regex)
		{
			bool a = Regex.IsMatch(textBox.Text, regex);
			match(textBox, a);
			return a;
		}
		public void match(TextBox textBox, bool a)
		{
			if (a)
				textBox.Foreground = Brushes.Black;
			else
				textBox.Foreground = Brushes.Red;
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			bool isAllgood = true, a;
			a = password.Password == cpassword.Password;
			if (a)
				cpassword.Foreground = Brushes.Black;
			else
				cpassword.Foreground = Brushes.Red;
			isAllgood &= a;
			a = reMatch(username, @"[0-9_A-z.]{5,16}");
			isAllgood &= a;
			if (!isAllgood)
				return;
			Logic.AddPerson(FullName.Text, username.Text, password.Password);
			this.Close();
		}
	}
}
