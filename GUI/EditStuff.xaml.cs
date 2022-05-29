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

namespace GUI {
	/// <summary>
	/// Interaction logic for EditStuff.xaml
	/// </summary>
	public partial class EditStuff : Window {
		public EditStuff()
		{
			InitializeComponent();
			foreach(var merchandise in DataStorage.dataHolder.Goods)
			{
				GoodsList.Items.Add(new UCForEditStuffList() { id = merchandise.ID });
			}
		}
	}
}
