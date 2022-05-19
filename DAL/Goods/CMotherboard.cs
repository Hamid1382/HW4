using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Helper;

namespace DAL.Goods
{
	public class CMotherboard : CMerchandise
	{
		public static bool IsValidPciVersion(ushort pciVersion) =>
			pciVersion >= 1 && pciVersion <= 5;
		public static bool IsValidRaidSupport(ushort raidSupport) =>
			raidSupport >= 1 && raidSupport <= 5;
		public EBase Base { get; set; }
		public ushort RamSlotCount { get; set; }
		private ushort _RaidSupport;
		public ushort RaidSupport
		{
			get => _RaidSupport;
			set
			{
				if (IsValidRaidSupport(value))
					_RaidSupport = value;
				else
					throw new ArgumentOutOfRangeException();
			}
		}
		private ushort _PCIVersion;
		public ushort PCIVersion
		{
			get => _PCIVersion;
			set
			{
				if (IsValidPciVersion(value))
					_PCIVersion = value;
				else
					throw new ArgumentOutOfRangeException();
			}
		}
		public ushort PciCount { get; set; }


	}
}
