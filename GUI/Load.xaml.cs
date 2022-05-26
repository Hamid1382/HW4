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
using System.Windows.Forms;

namespace GUI
{
	/// <summary>
	/// Interaction logic for Load.xaml
	/// </summary>
	public partial class Load : Window
	{
		OpenFileDialog ofd;
		public Load()
		{
			InitializeComponent();
			ofd = new OpenFileDialog();
			ofd.Filter = "Hamid Shop Data Files(*.hsd)|*.hsd";
		}

		private void Browse_Load_Click(object sender, RoutedEventArgs e)
		{
			ofd.ShowDialog();
			this.PathHolder.Text = ofd.FileName;
		}

		private void Load_Load_Click(object sender, RoutedEventArgs e)
		{
			DataStorage.PerviousSession(ofd.FileName);
			this.Close();
		}
	}
}
