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
using System.Text.RegularExpressions;
using BLL;
using DAL.Goods;
using DAL.Helper;


namespace GUI.AddStuffPages
{
	/// <summary>
	/// Interaction logic for AddRam.xaml
	/// </summary>
	public partial class AddRam : Window
	{
		public AddRam()
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
			isAllGood &= reMatch(ModuleCount, @"^[0-9]+$");
			isAllGood &= reMatch(Capacity, @"^[0-9]+$");
			isAllGood &= reMatch(Frequncy, @"^[0-9]+$");

			if (!isAllGood)
				return;

			var price = uint.Parse(Price.Text);
			var discount = uint.Parse(Discount.Text);

			a = discount < price;
			match(this.Discount, a);
			isAllGood &= a;


			//Count
			a = reMatch(Count, "[0-9]+");
			isAllGood &= a;

			//Module Count
			var moduleCount = ushort.Parse(ModuleCount.Text);
			a = CRam.isValidModuleCount(moduleCount);
			match(ModuleCount, a);
			isAllGood &= a;

			//Capacity
			var capacity = ushort.Parse(Capacity.Text);
			a = CRam.isValidCapacity(capacity);
			match(Capacity, a);
			isAllGood &= a;

			var frequency = uint.Parse(Frequncy.Text);

			if (!isAllGood)
				return;
			var count = uint.Parse(Count.Text);

			Logic.AddRam(Name.Text, Description.Text, price, discount, this.Manufactor.Text, count,
				(EState) this.State.SelectedIndex,(Eddr)DDRSupport.SelectedIndex,moduleCount,capacity,frequency);
		}
	}
}
