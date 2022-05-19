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
using DAL.Helper;
using DAL.Goods;
using System.Text.RegularExpressions;
namespace GUI
{
	/// <summary>
	/// Interaction logic for AddMotherBoard.xaml
	/// </summary>
	public partial class AddMotherBoard : Window
	{
		public AddMotherBoard()
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
			isAllGood &= reMatch(Price, @"^[0-9]+$");
			isAllGood &= reMatch(Discount, @"^[0-9]+$");
			isAllGood &= reMatch(Manufactor, @"^[A-Za-z]+$");
			isAllGood &= reMatch(Count, @"^[0-9]+$");
			isAllGood &= reMatch(RamCount, @"^[0-9]+$");
			isAllGood &= reMatch(Count, @"^[0-9]+$");
			isAllGood &= reMatch(PciCount, @"^[0-9]+$");
			isAllGood &= reMatch(RaidSupport, @"^[0-9]+$");


			if (!isAllGood)
				return;

			var price = uint.Parse(Price.Text);
			var discount = uint.Parse(Discount.Text);

			a = discount < price;
			match(this.Discount, a);
			isAllGood &= a;

			var count = uint.Parse(Count.Text);
			var ramCount = ushort.Parse(RamCount.Text);
			var pciCount = ushort.Parse(PciCount.Text);
			var raidSpppurt = ushort.Parse(RaidSupport.Text);
			a = CMotherboard.IsValidRaidSupport(raidSpppurt);
			match(this.RaidSupport, a);
			isAllGood &= a;

			if (!isAllGood)
				return;

			Logic.AddMotherboard(Name.Text, Description.Text, price, discount, this.Manufactor.Text, count,
				(EState) this.State.SelectedIndex,ramCount,(ushort)PciVersion.SelectedIndex,pciCount,(EBase)Base.SelectedIndex,raidSpppurt);
			this.Close();
		}
	}
}
