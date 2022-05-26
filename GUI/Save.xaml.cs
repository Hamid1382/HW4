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
using System.Windows.Forms;
using BLL;
using System.IO;

namespace GUI
{
	/// <summary>
	/// Interaction logic for Save.xaml
	/// </summary>
	public partial class Save : Window
	{
		SaveFileDialog sdf;
		public Save()
		{
			InitializeComponent();
			if (DataStorage.SavePath != null)
			{
				this.PathContainer.Text = DataStorage.SavePath;
			}
			sdf = new SaveFileDialog();
			sdf.Filter = @"Hamid Shop Data Files(*.hsd)|*.hsd";
		}

		private void Save_Save_Click(object sender, RoutedEventArgs e)
		{
			DataStorage.SavePath = this.PathContainer.Text;
			DataStorage.Save();		
		}

		private void Browse_Save_Click(object sender, RoutedEventArgs e)
		{
			sdf.ShowDialog();
			DataStorage.SavePath = (PathContainer.Text = sdf.FileName); 
		}
	}
}
