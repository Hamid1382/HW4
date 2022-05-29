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
using GUI.AddStuffPages;
using DAL.Helper;

namespace GUI {
	/// <summary>
	/// Interaction logic for UCForEditStuffList.xaml
	/// </summary>
	public partial class UCForEditStuffList : UserControl {
		public uint id;
		private CMerchandise t;
		public UCForEditStuffList()
		{
			InitializeComponent();
			t = DataStorage.GetMerchandisenByID(id);
			this.ID.Text = id.ToString();
			this.Name.Text = t.Name;
			this.Added.Text = t.Added.ToString();
		}

		private void Edit_Click(object sender, RoutedEventArgs e)
		{
			switch (t)
			{
				case CCpu cpu:
					var ViewCpu = new AddCpu()
					{
						Functionality = EFunc.edit,
						TargetID = t.ID,
					};
					ViewCpu.ShowDialog();
					break;
				case CGpu gpu:
					var ViewGpu = new AddGpu()
					{
						functionality = EFunc.edit,
						TargetID = id,
					};
					ViewGpu.ShowDialog();
					break;
				case CRam ram:
					var ViewRam = new AddRam()
					{
						Functionality = EFunc.edit,
						TargetID = id,
					};
					ViewRam.ShowDialog();
					break;
				case CMotherboard motherboard:
					var Viewmotherboard = new AddMotherBoard()
					{
						Functionality = EFunc.edit,
						TargetID = id,
					};
					Viewmotherboard.ShowDialog();
					break;
			}
		}

		private void Delete_Click(object sender, RoutedEventArgs e)
		{
			t.State = EState.Deleted;
		}
	}
}
