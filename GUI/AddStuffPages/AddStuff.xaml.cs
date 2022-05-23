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
					var a = new AddCpu
					{
						Functionality = EFunc.add
					};
					a.Show();
					break;
				case 2:
					var b = new AddGpu
					{
						functionality = EFunc.add
					};
					b.Show();
					break;
				case 3:
					var c = new AddRam
					{
						Functionality = EFunc.add
					};
					c.Show();
					break;
				case 4:
					var d = new AddMotherBoard
					{
						Functionality = EFunc.add
					};
					d.Show();
					break;
			}
		}
	}
}
