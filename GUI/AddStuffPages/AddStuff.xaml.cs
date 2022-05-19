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
using GUI.AddStuffPages;

namespace GUI
{
	/// <summary>
	/// Interaction logic for AddStuff.xaml
	/// </summary>
	public partial class AddStuff : Window
	{
		public AddStuff()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var selected = combo.SelectedIndex;
			switch (selected)
			{
				case 1:
					(new AddCpu()).ShowDialog();
					break;
				case 2:
					(new AddGpu()).ShowDialog();
					break;
				case 3:
					(new AddRam()).ShowDialog();
					break;
				case 4:
					(new AddMotherBoard()).ShowDialog();
					break;
			}
		}
	}
}
