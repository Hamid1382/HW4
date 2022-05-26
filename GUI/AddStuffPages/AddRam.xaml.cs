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

		public uint? TargetID;
		public EFunc Functionality;
		public AddRam()
		{
			InitializeComponent();
			if (this.Functionality == EFunc.edit)
			{
				var ram = DataStorage.GetMerchandisenByID(TargetID.Value) as CRam;
				Title = "Edit Motherboard";
				Name.Text = ram.Name.ToString();
				Price.Text = ram.Price.ToString();
				Discount.Text = ram.Discount.ToString();
				Manufactor.Text = ram.Manufacturer.ToString();
				Count.Text = ram.Available.ToString();
				State.SelectedIndex = (int) ram.State;
				Description.Text = ram.Description;
				Capacity.Text = ram.Capacity.ToString() + "MB";
				DDRSupport.SelectedIndex = (int) ram.DdrVersion;
				Frequncy.Text = ram.Frequency.ToString() + "MH";
				ModuleCount.Text = ram.ModuleCount.ToString();
			}
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
			if (Functionality == EFunc.add)
			{
				var ram = new CRam()
				{
					Name = Name.Text,
					Description = Description.Text,
					Price = price,
					Discount = discount,
					Manufacturer = Manufactor.Text,
					Available = count,
					State = (EState) State.SelectedIndex,
					DdrVersion = (Eddr) DDRSupport.SelectedIndex,
					ModuleCount = moduleCount,
					Capacity = capacity,
					Frequency = frequency,
				};
				Logic.AddStuff(ram);
			}
			else
			{
				var ram = DataStorage.GetMerchandisenByID(TargetID.Value) as CRam;
				ram.LastUpdate = DateTime.Now;
				ram.Name = Name.Text;
				ram.Description = Description.Text;
				ram.Price = price;
				ram.Discount = discount;
				ram.Manufacturer = Manufactor.Text;
				ram.Available = count;
				ram.State = (EState) State.SelectedIndex;
				ram.DdrVersion = (Eddr) DDRSupport.SelectedIndex;
				ram.Frequency = frequency;
				ram.Capacity = capacity;
				ram.ModuleCount = moduleCount;
			}
		}
	}
}
