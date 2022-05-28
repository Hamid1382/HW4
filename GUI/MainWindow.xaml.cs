using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using BLL;
using DAL.Goods;
using DAL.Helper;
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
			EssentialChecks();
		}
		public void EssentialChecks()
		{
			if(DataStorage.dataHolder is null)
			{
				Save_Session.IsEnabled		= false;
				Load_Session.IsEnabled		= true;
				New_Session.IsEnabled		= true;
				Reload_Session.IsEnabled	= false;
				Sign_In.IsEnabled			= false;
				Log_In.IsEnabled			= false;
				Log_Out.IsEnabled			= false;
				View_People.IsEnabled		= false;
				Add_Goods.IsEnabled			= false;
				Edit_Remove.IsEnabled		= false;
			}
			else
			{
				Save_Session.IsEnabled		= true;
				Load_Session.IsEnabled		= true;
				New_Session.IsEnabled		= true;
				Reload_Session.IsEnabled	= true;
				if(Logic.currentUser is null)
				{
					Sign_In.IsEnabled		= true;
					Log_In.IsEnabled		= true;
					Log_Out.IsEnabled		= false;
					View_People.IsEnabled	= false;
					Add_Goods.IsEnabled		= false;
					Edit_Remove.IsEnabled	= false;
				}
				else
				{
					Sign_In.IsEnabled = false;
					Log_In.IsEnabled = false;
					Log_Out.IsEnabled = true;
					switch (DataStorage.GetPersonByID(Logic.currentUser.Value).Role)
					{
						case ERole.mainAdmin:
							View_People.IsEnabled	= true;
							Add_Goods.IsEnabled		= true;
							Edit_Remove.IsEnabled	= true;
							break;
						case ERole.Admin:
							View_People.IsEnabled	= false;
							Add_Goods.IsEnabled		= true;
							Edit_Remove.IsEnabled	= true;
							break;
						case ERole.Costumer:
							View_People.IsEnabled	= false;
							Add_Goods.IsEnabled		= false;
							Edit_Remove.IsEnabled	= false;
							break;
					}
				}
			}
		}
		public void AddGoodSafe()
		{
			if(DataStorage.dataHolder != null)
			{
				AddGoods();
			}
		}
		public void AddGoods()
		{
			Binding b = new Binding();
			b.Source = RightStack;
			RightStack.Children.Clear();
			MiddleStack.Children.Clear();
			LeftStack.Children.Clear();
			uint count = 0;
			var toAdd = DataStorage.dataHolder.Goods.Where<CMerchandise>(x => x.State == EState.Visible && x.Available > 0).ToArray<CMerchandise>();
			foreach (var merchandise in toAdd)
			{
				if(merchandise is CCpu cpu && ShowCpu.IsChecked == true)
				{
					var viewCpuUC = new ViewCpuUC
					{
						ID = cpu.ID
					};
					viewCpuUC.Name.Text = cpu.Name;
					viewCpuUC.Price.Text = cpu.Price.ToString();
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
					viewCpuUC.SetBinding(WidthProperty, b);
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
				}
				else if(merchandise is CGpu gpu && ShowGpu.IsChecked==true)
				{
					var viewGpuUC = new ViewGpuUC
					{
						ID = gpu.ID
					};
					viewGpuUC.Name.Text = gpu.Name;
					viewGpuUC.Price.Text = gpu.Price.ToString();
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
					viewGpuUC.SetBinding(WidthProperty, b);

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
				}
				else if(merchandise is CMotherboard motherboard && ShowMotherboard.IsChecked == true)
				{
					var viewMotherboard = new ViewMotherboard
					{
						ID = motherboard.ID
					};
					viewMotherboard.Name.Text = motherboard.Name;
					viewMotherboard.Price.Text = motherboard.Price.ToString();
					viewMotherboard.Available.Text = motherboard.Available.ToString();
					viewMotherboard.Rate.Text = motherboard.Rate.Percent.ToString() + "%";
					viewMotherboard.Added.Text = motherboard.Added.ToString();
					viewMotherboard.Updated.Text = motherboard.LastUpdate.ToString();
					viewMotherboard.Manufacturer.Text = motherboard.Manufacturer;
					viewMotherboard.Description.Text = motherboard.Description;
					viewMotherboard.RamSlotCount.Text = motherboard.RamSlotCount.ToString();
					viewMotherboard.PciVersion.Text = motherboard.PCIVersion.ToString();
					viewMotherboard.PciCount.Text = motherboard.PciCount.ToString();
					viewMotherboard.SetBinding(WidthProperty, b);

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
				}
				else if(merchandise is CRam ram && ShowRam.IsChecked == true)
				{
					var viewRamUC = new ViewRamUC
					{
						ID = ram.ID
					};
					viewRamUC.Name.Text = ram.Name;
					viewRamUC.Price.Text = ram.Price.ToString();
					viewRamUC.Available.Text = ram.Available.ToString();
					viewRamUC.Rate.Text = ram.Rate.Percent.ToString() + "%";
					viewRamUC.Added.Text = ram.Added.ToString();
					viewRamUC.Updated.Text = ram.LastUpdate.ToString();
					viewRamUC.Manufacturer.Text = ram.Manufacturer;
					viewRamUC.Description.Text = ram.Description;
					viewRamUC.Capacity.Text = ram.Capacity.ToString() + "MB";
					viewRamUC.DDRVersion.Text = ram.DdrVersion.ToString();
					viewRamUC.ModuleCount.Text = ram.ModuleCount.ToString();
					viewRamUC.Frequency.Text = ram.Frequency.ToString() + "MH";
					viewRamUC.SetBinding(WidthProperty, b);

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
				}
				else if (merchandise is null)
				{
					MessageBox.Show("Null" , "Alert",MessageBoxButton.OK);	
				}
			}
		}
		private void Save_Session_Click(object sender, RoutedEventArgs e) =>
			(new Save()).ShowDialog();
		private void Load_Session_Click(object sender, RoutedEventArgs e) => 
			(new Load()).ShowDialog();
		private void New_Session_Click(object sender, RoutedEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Do you really want to start a new session?","Confirmation",
										  MessageBoxButton.YesNo, MessageBoxImage.Question);
			if (result == MessageBoxResult.Yes)
				DataStorage.NewSession();
		}
		private void Reload_Session_Click(object sender, RoutedEventArgs e)
		{
			MessageBoxResult result = MessageBox.Show("Do you really want to reload session from the file?",
										  "Confirmation",
										  MessageBoxButton.YesNo,
										  MessageBoxImage.Question);
			if (result == MessageBoxResult.Yes)
			{
				DataStorage.Reload();
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
				Logic.currentUser = null;
			}
			EssentialChecks();
		}
		private void Add_Goods_click(object sender, RoutedEventArgs e) =>
			(new AddStuff()).ShowDialog();

		private void Button_Click(object sender, RoutedEventArgs e) => AddGoodSafe();

		private void ShowAll_Checked(object sender, RoutedEventArgs e)
		{
			ShowCpu.IsChecked = true;
			ShowGpu.IsChecked = true;
			ShowMotherboard.IsChecked = true;
			ShowRam.IsChecked = true;
		}

		private void ShowAll_Unchecked(object sender, RoutedEventArgs e)
		{
			ShowCpu.IsChecked = false;
			ShowGpu.IsChecked = false;
			ShowMotherboard.IsChecked = false;
			ShowRam.IsChecked = false;
		}

		private void Window_Activated(object sender, EventArgs e)
		{
			EssentialChecks();
		}
	}
}
