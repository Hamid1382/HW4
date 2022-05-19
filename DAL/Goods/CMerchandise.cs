using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Helper;

namespace DAL.Goods
{
	public class CMerchandise
	{
		public string Description { get; set; }
		public bool IsValidDiscout(uint discount) => discount <= this.Price;
		private uint _Discount;
		public uint Discount
		{
			get => _Discount;
			set
			{
				if(IsValidDiscout(Discount))
					_Discount = value;
				else
					throw new ArgumentOutOfRangeException();
			}
		}
		public uint ID { get; set; }
		public string Name { get; set; }
		public string Manufacturer { get; set; }
		public uint Price { get; set; }
		public uint Available { get; set; }
		public CRate Rate { set; get; } 
		public EState State { get; set; }
		public DateTime Added { get; set; }
		public DateTime LastUpdate { get; set; }
		public uint OwnerID { get; set; }
	}
}

