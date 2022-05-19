using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Goods;
using DAL.Helper;

namespace BLL
{
	public static class Logic
	{
		public static uint? currentUser = null;
		public static void AddPerson(string name,string username,string Password)
		{
			uint id = DataStorage.GetNewPersonID();
			DataStorage.AddPerson(new CPerson() { Id = id, Name = name, Username = username,
				Password = Password,Role = (id ==0?ERole.mainAdmin:ERole.Costumer)});
		}
		public static void AddCpu(string name,string description,uint price,
			uint discount,string manufacturer,uint count,EState state,ushort coreCount, ushort ThreadCount,
			uint frequency, ushort lithographic,ushort tdp,Eddr ddrSupport, string Series)
		{
			CCpu c = new CCpu()
			{
				ID = DataStorage.GetNewStuffID(),
				Name = name,
				Manufacturer = manufacturer,
				Description = description,
				Price = price,
				Discount = discount,
				Available = count,
				Added = DateTime.Now,
				OwnerID = currentUser.GetValueOrDefault(),
				Rate = new CRate(),
				State = state,
				LastUpdate = DateTime.Now,
				CoreCount = coreCount,
				ThreadCount = ThreadCount,
				Frequency = frequency,
				Lithographic = lithographic,
				TDP = tdp,
				DdrSupport = ddrSupport,
				Series = Series
			};
			DataStorage.AddStuff(c);
		}
		public static void AddGpu(string name, string description, uint price,
			uint discount, string manufacturer, uint count, EState state,uint vRamSize,
			ushort pciVersion, ushort maxPossibleDisplayes, SResolution maxResolution, string series, EGDDR vRamModule)
		{
			DataStorage.AddStuff(new CGpu()
			{
				ID = DataStorage.GetNewStuffID(),
				Name = name,
				Manufacturer = manufacturer,
				Description = description,
				Price = price,
				Discount = discount,
				Available = count,
				Added = DateTime.Now,
				OwnerID = currentUser.Value,
				Rate = new CRate(),
				State = state,
				LastUpdate = DateTime.Now,
				VRamSize = vRamSize,
				PCIVersion = pciVersion,
				MaxDisplayPossible = maxPossibleDisplayes,
				MaxResolution = maxResolution,
				Series = series,
				VRamModule = vRamModule
			});
		}
		public static void AddMotherboard(string name, string description, uint price,
			uint discount, string manufacturer, uint count, EState state, ushort ramSlotCount, ushort pciVersion,
			ushort pciCount,EBase based, ushort raidSupport)
		{
			DataStorage.AddStuff(new CMotherboard()
			{
				ID = DataStorage.GetNewStuffID(),
				Name = name,
				Manufacturer = manufacturer,
				Description = description,
				Price = price,
				Discount = discount,
				Available = count,
				Added = DateTime.Now,
				OwnerID = currentUser.Value,
				Rate = new CRate(),
				State = state,
				LastUpdate = DateTime.Now,
				RamSlotCount = ramSlotCount,
				PCIVersion = pciVersion,
				PciCount = pciCount,
				Base = based,
				RaidSupport = raidSupport
			});
		}
		public static void AddRam(string name, string description, uint price,
			uint discount, string manufacturer, uint count, EState state, Eddr ddrVersion,
			ushort moduleCount, uint capacity, uint frequency)
		{
			DataStorage.AddStuff(new CRam()
			{
				ID = DataStorage.GetNewStuffID(),
				Name = name,
				Manufacturer = manufacturer,
				Description = description,
				Price = price,
				Discount = discount,
				Available = count,
				Added = DateTime.Now,
				OwnerID = currentUser.Value,
				Rate = new CRate(),
				State = state,
				LastUpdate = DateTime.Now,
				DdrVersion = ddrVersion,
				ModuleCount = moduleCount,
				Capacity = capacity,
				Frequency = frequency
			});
		}
		public static SResolution GetSResolution(uint width, uint height) =>
			new SResolution() { Height = height, Width = width };
	}
}

