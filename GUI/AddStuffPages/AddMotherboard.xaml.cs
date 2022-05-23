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
		public uint? TargetID;
		public EFunc Functionality;
		public AddMotherBoard()
		{
			InitializeComponent();
			if (this.Functionality == EFunc.edit)
			{
				var motherboard= DataStorage.GetMerchandisenByID(TargetID.Value) as CMotherboard;
				Title = "Edit Motherboard";
				Name.Text = motherboard.Name.ToString();
				Price.Text = motherboard.Price.ToString();
				Discount.Text = motherboard.Discount.ToString();
				Manufactor.Text = motherboard.Manufacturer.ToString();
				Count.Text = motherboard.Available.ToString();
				State.SelectedIndex = (int) motherboard.State;
				Description.Text = motherboard.Description;
				RamCount.Text = motherboard.RamSlotCount.ToString();
				PciVersion.SelectedIndex = (int) motherboard.PCIVersion;
				PciCount.Text = motherboard.PciCount.ToString();
				Base.SelectedIndex = (int) motherboard.Base;
				RaidSupport.Text = motherboard.RaidSupport.ToString();

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
			if (this.Functionality == EFunc.add)
			{
				Logic.AddMotherboard(Name.Text, Description.Text, price, discount, this.Manufactor.Text, count,
				(EState) this.State.SelectedIndex, ramCount, (ushort) PciVersion.SelectedIndex, pciCount, (EBase) Base.SelectedIndex, raidSpppurt);
			}
			else
			{
				var motherboard = DataStorage.GetMerchandisenByID(TargetID.Value) as CMotherboard;
				motherboard.LastUpdate = DateTime.Now;
				motherboard.Name = Name.Text;
				motherboard.Description = Description.Text;
				motherboard.Price = price;
				motherboard.Discount = discount;
				motherboard.Manufacturer = Manufactor.Text;
				motherboard.Available = count;
				motherboard.State = (EState) State.SelectedIndex;
				motherboard.PCIVersion = (ushort) PciVersion.SelectedIndex;
				motherboard.RamSlotCount = ramCount;
				motherboard.PciCount = pciCount;
				motherboard.Base = (EBase) Base.SelectedIndex;
			}
			this.Close();
		}
	}
}
