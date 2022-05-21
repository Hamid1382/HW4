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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL;
using DAL.Goods;
using GUI.ViewGoodsUC;
namespace GUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.Activated += MainWindow_Activated;
		}

		private void MainWindow_Activated(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}

		public void AddGoodsConditioned()
		{
			if(DataStorage.dataHolder != null)
			{
				AddGoods();
			}
		}
		public void AddGoods()
		{
			uint count = 0;
			foreach(var merchandise in DataStorage.dataHolder.Goods)
			{
				switch (merchandise)
				{
					case CCpu cpu:
						var viewCpuUC = new ViewCpuUC();
						viewCpuUC.Name.Text = cpu.Name;
						viewCpuUC.Available.Text = cpu.Available.ToString();
						viewCpuUC.Rate.Text = cpu.Rate.Percent.ToString() + "%";
						viewCpuUC.Added.Text = cpu.Added.ToString();
						viewCpuUC.Updated.Text = cpu.LastUpdate.ToString();
						viewCpuUC.Manufacturer.Text = cpu.Manufacturer;
						viewCpuUC.CoreCount.Text = cpu.CoreCount.ToString();
						viewCpuUC.ThreadCount.Text = cpu.ThreadCount.ToString();
						viewCpuUC.Frequency.Text = cpu.Frequency.ToString() + "MH";
						viewCpuUC.Lithographic.Text = cpu.Lithographic.ToString() + "nm";
						viewCpuUC.TDP.Text = cpu.TDP.ToString() + "w";
						viewCpuUC.Series.Text = cpu.Series;
						viewCpuUC.DDRSupport.Text = cpu.DdrSupport.ToString();
						viewCpuUC.Description.Text = cpu.Description;
						switch (count)
						{
							case 0:
								LeftStack.Children.Add(viewCpuUC);
								break;
							case 1:
								MiddleStack.Children.Add(viewCpuUC);
								break;
							case 2:
								RightStack.Children.Add(viewCpuUC);
								break;
						}
						count++;
						count %= 3;
						break;
					case CGpu gpu:
						var viewGpuUC = new ViewGpuUC();
						viewGpuUC.Name.Text = gpu.Name;
						viewGpuUC.Available.Text = gpu.Available.ToString();
						viewGpuUC.Rate.Text = gpu.Rate.Percent.ToString() + "%";
						viewGpuUC.Added.Text = gpu.Added.ToString();
						viewGpuUC.Updated.Text = gpu.LastUpdate.ToString();
						viewGpuUC.Manufacturer.Text = gpu.Manufacturer;
						viewGpuUC.Series.Text = gpu.Series;
						viewGpuUC.Description.Text = gpu.Description;
						viewGpuUC.VRamSize.Text = gpu.VRamSize.ToString() + "MB";
						viewGpuUC.PCIVersion.Text = gpu.PCIVersion.ToString();
						viewGpuUC.VRamModule.Text = gpu.VRamModule.ToString();
						viewGpuUC.MaxDisplayPossible.Text = gpu.MaxDisplayPossible.ToString();
						viewGpuUC.MaxResolution.Text = gpu.MaxResolution.ToString();
						
						switch (count)
						{
							case 0:
								LeftStack.Children.Add(viewGpuUC);
								break;
							case 1:
								MiddleStack.Children.Add(viewGpuUC);
								break;
							case 2:
								RightStack.Children.Add(viewGpuUC);
								break;
						}
						count++;
						count %= 3;
						break;
					case CMotherboard motherboard:
						var viewMotherboard = new ViewMotherboard();
						viewMotherboard.Name.Text = motherboard.Name;
						viewMotherboard.Available.Text = motherboard.Available.ToString();
						viewMotherboard.Rate.Text = motherboard.Rate.Percent.ToString() + "%";
						viewMotherboard.Added.Text = motherboard.Added.ToString();
						viewMotherboard.Updated.Text = motherboard.LastUpdate.ToString();
						viewMotherboard.Manufacturer.Text = motherboard.Manufacturer;
						viewMotherboard.Description.Text = motherboard.Description;
						viewMotherboard.RamSlotCount.Text = motherboard.RamSlotCount.ToString();
						viewMotherboard.PciVersion.Text = motherboard.PCIVersion.ToString();
						viewMotherboard.PciCount.Text = motherboard.PciCount.ToString();


						switch (count)
						{
							case 0:
								LeftStack.Children.Add(viewMotherboard);
								break;
							case 1:
								MiddleStack.Children.Add(viewMotherboard);
								break;
							case 2:
								RightStack.Children.Add(viewMotherboard);
								break;
						}
						count++;
						count %= 3;
						break;
					case CRam ram:
						var viewRamUC = new ViewRamUC();
						viewRamUC.Name.Text = ram.Name;
						viewRamUC.Available.Text = ram.Available.ToString();
						viewRamUC.Rate.Text = ram.Rate.Percent.ToString() + "%";
						viewRamUC.Added.Text = ram.Added.ToString();
						viewRamUC.Updated.Text = ram.LastUpdate.ToString();
						viewRamUC.Manufacturer.Text = ram.Manufacturer;
						viewRamUC.Description.Text = ram.Description;
						viewRamUC.Capacity.Text = ram.Capacity.ToString();
						viewRamUC.DDRVersion.Text = ram.DdrVersion.ToString();
						viewRamUC.ModuleCount.Text = ram.ModuleCount.ToString();
						viewRamUC.Frequency.Text = ram.Frequency.ToString();

						switch (count)
						{
							case 0:
								LeftStack.Children.Add(viewRamUC);
								break;
							case 1:
								MiddleStack.Children.Add(viewRamUC);
								break;
							case 2:
								RightStack.Children.Add(viewRamUC);
								break;
						}
						count++;
						count %= 3;
						break;
				}
			}
		}
		private void Save_Session_Click(object sender, RoutedEventArgs e) =>
			(new Save()).ShowDialog();
		private void Load_Session_Click(object sender, RoutedEventArgs e) => 
			(new Load()).ShowDialog();
		private void New_Session_Click(object sender, RoutedEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Do you really want to start a new session?",
										  "Confirmation",
										  MessageBoxButton.YesNo,
										  MessageBoxImage.Question);
			if (result == MessageBoxResult.Yes)
			{
				DataStorage.NewSession();
			}
		}
		private void Reload_Session_Click(object sender, RoutedEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Do you really want to reload session from the file?",
										  "Confirmation",
										  MessageBoxButton.YesNo,
										  MessageBoxImage.Question);
			if (result == MessageBoxResult.Yes)
			{
				//reload session
			}
		}
		private void Sign_In_Click(object sender, RoutedEventArgs e) => 
			(new SignIn()).ShowDialog();

		private void Login_Click(object sender, RoutedEventArgs e) =>
			(new Login()).ShowDialog();
		private void Log_Out_Click(object sender, RoutedEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Do you really want to log out?",
										  "Confirmation",
										  MessageBoxButton.YesNo,
										  MessageBoxImage.Question);
			if (result == MessageBoxResult.Yes)
			{
				//Log out
			}
		}
		private void Add_Goods_click(object sender, RoutedEventArgs e) =>
			(new AddStuff()).ShowDialog();
	}
}
