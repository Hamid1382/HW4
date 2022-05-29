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
using DAL.Helper;
using DAL.Goods;
using System.Text.RegularExpressions;
using BLL;

namespace GUI
{

	/// <summary>
	/// Interaction logic for AddCpu.xaml
	/// </summary>
	public partial class AddCpu : Window
	{
		public uint? TargetID;
		public EFunc Functionality;
		public AddCpu(EFunc func , uint id)
		{
			InitializeComponent();
			Functionality = func;
			TargetID = id;
			if(this.Functionality == EFunc.edit)
			{
				CCpu cpu = DataStorage.GetMerchandisenByID(TargetID.Value) as CCpu;
				Title = "Edit Cpu";
				Name.Text = cpu.Name.ToString();
				Price.Text = cpu.Price.ToString();
				Discount.Text = cpu.Discount.ToString();
				Manufactor.Text = cpu.Manufacturer.ToString();
				Count.Text = cpu.Available.ToString();
				State.SelectedIndex = (int) cpu.State;
				CoreCount.Text = cpu.CoreCount.ToString();
				ThreadCount.Text = cpu.ThreadCount.ToString();
				Frequency.Text = cpu.Frequency.ToString();
				Lithographic.Text = cpu.Lithographic.ToString();
				TDP.Text = cpu.TDP.ToString();
				DDRSupport.SelectedIndex = (int) cpu.DdrSupport;
				Series.Text = cpu.Series;
				Description.Text = cpu.Description;
			}
		}

		public bool reMatch(TextBox textBox, string regex)
		{
			bool a = Regex.IsMatch(textBox.Text, regex);
			match(textBox,a);
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
			bool isAllGood = true ,a;
			isAllGood &= reMatch(Price, @"^[0-9]+$");
			isAllGood &= reMatch(Discount, @"^[0-9]+$");
			isAllGood &= reMatch(Manufactor, @"^[A-Za-z]+$");
			isAllGood &= reMatch(Count, @"^[0-9]+$");
			isAllGood &= reMatch(CoreCount, @"^[0-9]+$");
			isAllGood &= reMatch(ThreadCount, @"^[0-9]+$");
			isAllGood &= reMatch(Frequency, @"^[0-9]+$");
			isAllGood &= reMatch(Lithographic, @"^[0-9]+$");
			isAllGood &= reMatch(TDP, @"^[0-9]+$");

			if (!isAllGood)
				return;

			var price = uint.Parse(Price.Text);
			var discount = uint.Parse(Discount.Text);

			a = discount < price;
			match(this.Discount, a);
			isAllGood &= a;

			//CoreCount
			var coreCount = ushort.Parse(CoreCount.Text);
			a = CCpu.IsValidCoreCount(coreCount);
			match(CoreCount, a);
			isAllGood &= a;

			//ThreadCount
			var threadCount = ushort.Parse(ThreadCount.Text);
			a = CCpu.IsValidThreadCount(threadCount);
			match(ThreadCount, a);
			isAllGood &= a;

			//Frequency
			var frequency = uint.Parse(Frequency.Text);
			a = CCpu.IsValidFrequency(frequency);
			match(Frequency, a);
			isAllGood &= a;

			//Lithographic
			var lithographic = ushort.Parse(Lithographic.Text);
			a = CCpu.IsValidLithographic(lithographic);
			match(Lithographic, a);
			isAllGood &= a;

			//TDP
			var tdp = ushort.Parse(TDP.Text);
			a = CCpu.IsValidTDP(tdp);
			match(TDP, a);
			isAllGood &= a;

			//Count
			a = reMatch(Count, "[0-9]+");
			isAllGood &= a;

			if (!isAllGood)
				return;
			var count = uint.Parse(Count.Text);
			if(Functionality == EFunc.add)
			{
				CCpu cpu = new CCpu()
				{
					Name = Name.Text,
					Description = Description.Text,
					Price = price,
					Discount = discount,
					CoreCount = coreCount,
					ThreadCount = threadCount,
					Frequency = frequency,
					Lithographic = lithographic,
					Available = count,
					Manufacturer = Manufactor.Text,
					State = (EState) State.SelectedIndex,
					DdrSupport = (Eddr) DDRSupport.SelectedIndex,
					Series = Series.Text,
					TDP = tdp,
				};
				Logic.AddStuff(cpu);
			}
			else
			{
				var cpu = DataStorage.GetMerchandisenByID(TargetID.Value) as CCpu;
				cpu.LastUpdate = DateTime.Now;
				cpu.Name = Name.Text;
				cpu.Description = Description.Text;
				cpu.Price = price;
				cpu.Discount = discount;
				cpu.Manufacturer = Manufactor.Text;
				cpu.Available = count;
				cpu.State = (EState) State.SelectedIndex;
				cpu.CoreCount = coreCount;
				cpu.ThreadCount = threadCount;
				cpu.Frequency = frequency;
				cpu.Lithographic = lithographic;
				cpu.DdrSupport = (Eddr) DDRSupport.SelectedIndex;
				cpu.Series = Series.Text;
				cpu.TDP = tdp;
			}
			Close();
		}
	}
}
