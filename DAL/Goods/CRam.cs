using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Helper;
namespace DAL.Goods
{
	public class CRam : CMerchandise
	{
		public static bool isValidCapacity(uint capacity) => 
			capacity >= 128 && capacity <= 64000;
		public static bool isValidModuleCount(ushort moduleCount) => 
			moduleCount >= 1 && moduleCount <= 4;
		public Eddr DdrVersion { get; set; }
		public ushort ModuleCount { get; set; }
		private uint _Capacity;
		public uint Capacity //MB
		{
			get => _Capacity;
			set
			{
				if (isValidCapacity(value))
					_Capacity = value;
				else
					isValidCapacity(value);
			}
		}
		public uint Frequency { get; set; }

	}
}
