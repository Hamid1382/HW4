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
using DAL.Goods;
using DAL.Helper;
using System.Text.RegularExpressions;

namespace GUI
{
	/// <summary>
	/// Interaction logic for AddGpu.xaml
	/// </summary>
	public partial class AddGpu : Window
	{
		public AddGpu()
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
			bool isAllGood = true, a;
			isAllGood &= reMatch(Price, @"^$[0-9]+$");
			isAllGood &= reMatch(Discount, @"^$[0-9]+$");
			isAllGood &= reMatch(Manufactor, @"^$[A-Za-z]+$");
			isAllGood &= reMatch(Count, @"^$[0-9]+$");
			isAllGood &= reMatch(VramSize, @"^$[0-9]+$");
			isAllGood &= reMatch(MaxDisplayPossible, @"^$[0-9]+$");
			isAllGood &= reMatch(MaxResolution, @"^$[0-9]+x[0-9]+$");


			if (!isAllGood)
				return;

			var price = uint.Parse(Price.Text);
			var discount = uint.Parse(Discount.Text);

			a = discount < price;
			match(this.Discount, a);
			isAllGood &= a;

			//VRam Size
			uint vRamSize = uint.Parse(VramSize.Text);
			a = CGpu.IsValidVRamSize(vRamSize);
			match(VramSize, a);
			isAllGood &= a;

			//Count
			a = reMatch(Count, "[0-9]+");
			isAllGood &= a;

			//Max display Possible
			ushort maxDispalyPossible = ushort.Parse(MaxDisplayPossible.Text);
			a = CGpu.IsValidMaxDisplayPossible(maxDispalyPossible);
			match(MaxDisplayPossible, a);
			isAllGood &= a;

			//Resolution
			string[] s = this.MaxResolution.Text.Split('x');
			SResolution resolution = new SResolution() { Height = ushort.Parse(s[1]), Width = ushort.Parse(s[0])};
			a = CGpu.IsValidMaxResolution(resolution);
			match(MaxResolution, a);
			isAllGood &= a;

			if (!isAllGood)
				return;
			var count = uint.Parse(Count.Text);

			Logic.AddGpu(this.Name.Text, this.Description.Text, price, discount, this.Manufactor.Text, count, (EState) this.State.SelectedIndex, vRamSize,
				(ushort) PciVersion.SelectedIndex,maxDispalyPossible, resolution, this.Series.Text, (EGDDR) this.VramModule.SelectedIndex);
		}
	}
}
