﻿using System;
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

namespace GUI.ViewGoodsUC {
	/// <summary>
	/// Interaction logic for ViewCpuUC.xaml
	/// </summary>
	public partial class ViewCpuUC : UserControl {
		public uint ID;
		public ViewCpuUC()
		{
			InitializeComponent();
		}

		private void Buy_Click(object sender, RoutedEventArgs e)
		{
			DataStorage.GetMerchandisenByID(ID).Available--;
			uint available = DataStorage.GetMerchandisenByID(ID).Available;
			Available.Text = available.ToString();
			if (available == 0)
				this.Buy.IsEnabled = false;
		}
	}
}
