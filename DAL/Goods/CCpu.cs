using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Helper;

namespace DAL.Goods
{
	public class CCpu : CMerchandise
	{
		public static bool IsValidCoreCount(ushort coreCount) => 
			coreCount > 1 && coreCount <= 128;
		public static bool IsValidThreadCount(ushort threadCount) => 
			threadCount > 2 && threadCount <= 256;
		public static bool IsValidFrequency(uint frequency) => 
			frequency >= 1000 && frequency <= 7000;
		public static bool IsValidLithographic(ushort lithographic) =>
			lithographic >= 1 && lithographic <= 30;
		public static bool IsValidTDP(ushort TDP) =>
			TDP >= 1 && TDP <= 300;

		private ushort _CoreCount;
		private ushort _ThreadCount;
		private uint _Frequency;
		private ushort _Lithographic;
		private ushort _TDP;

		public string Series { get; set; }
		public Eddr DdrSupport { get; set; }
		
		public ushort CoreCount { 
			get => _CoreCount;
			set 
			{
				if (IsValidCoreCount(value))
					_CoreCount = value;
				else
					throw new ArgumentOutOfRangeException();
			}
		}
		public ushort ThreadCount
		{
			get => _ThreadCount;
			set
			{
				if (IsValidThreadCount(value))
					_ThreadCount = value;
				else
					throw new ArgumentOutOfRangeException();
			}
		}
		public uint Frequency //MHz
		{
			get => _Frequency;
			set
			{
				if (IsValidFrequency(value))
					_Frequency = value;
				else
					throw new ArgumentOutOfRangeException();
			}

		} 
		public ushort Lithographic
		{
			get => _Lithographic;
			set
			{
				if (IsValidLithographic(value))
					_Frequency = value;
				else
					throw new ArgumentOutOfRangeException();
			}

		}
		public ushort TDP
		{
			get => _TDP;
			set
			{
				if (IsValidTDP(value))
					_TDP = value;
				else
					throw new ArgumentOutOfRangeException();
			}

		}
	}
}

