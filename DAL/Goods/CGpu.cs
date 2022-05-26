using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Helper;

namespace DAL.Goods
{
	public class CGpu : CMerchandise
	{
		public static bool IsValidVRamSize(uint vRamSize) =>
			vRamSize >= 512 && vRamSize <= 32000;
		public static bool IsValidPciVersion(ushort pciVersion) =>
			pciVersion >= 1 && pciVersion <= 5;
		public static bool IsValidMaxDisplayPossible(ushort maxDisplayPossible) =>
			maxDisplayPossible >= 1 && maxDisplayPossible <= 10;
		public static bool IsValidMaxResolution(SResolution maxResolution)
		{
			ulong pixel = maxResolution.Height * maxResolution.Width;
			return pixel >= 480_000 && pixel <= 240_000_000;
		}
		private uint _VRamSive;
		public uint VRamSize //MB 
		{
			get => _VRamSive;
			set
			{
				if (IsValidVRamSize(value))
					_VRamSive = value;
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
		private ushort _MaxDisplayPossible;
		public ushort MaxDisplayPossible
		{
			get => _MaxDisplayPossible;
			set
			{
				if (IsValidMaxDisplayPossible(value))
					_MaxDisplayPossible = value;
				else
					throw new ArgumentOutOfRangeException();
			}
		}
		private SResolution _MaxResolution;
		public SResolution MaxResolution
		{
			get => _MaxResolution;
			set
			{
				if (IsValidMaxResolution(value))
					_MaxResolution = value;
				else
					throw new ArgumentOutOfRangeException();
			}
		}
		public string Series { get; set; }
		public EGDDR VRamModule { get; set; }
	}
}
