using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Helper;
using DAL.Goods;
using System.IO;
using Newtonsoft.Json;

namespace BLL
{
	internal class DataHolder
	{
		public List<CPerson> People;
		public List<CMerchandise> Goods;
		public DataHolder()
		{
			People = new List<CPerson>();
			Goods = new List<CMerchandise>();
		}
	}
	public static class DataStorage
	{
		private static JsonSerializer serializer = new JsonSerializer();
		public static string SavePath { get; set; }
		private static DataHolder dataHolder;
		public static void NewSession() =>
			dataHolder = new DataHolder();
		public static void PerviousSession(string savePath)
		{
			SavePath = savePath;
			using (var fileStream = new StreamReader(savePath))
			{
				using(var jsonStream = new JsonTextReader(fileStream))
				{
					dataHolder = serializer.Deserialize<DataHolder>(jsonStream);
				}
			}
		}
		public static void Reload()
		{
			using (var fileStream = new StreamReader(SavePath))
			{
				using(var jsonStream = new JsonTextReader(fileStream))
				{
					dataHolder = serializer.Deserialize<DataHolder>(jsonStream);
				}
}
		}
		public static void Save()
		{
			using (var fileStream = new StreamWriter(SavePath))
			{
				using (var JsonStream = new JsonTextWriter(fileStream))
				{
					serializer.Serialize(JsonStream,dataHolder);
				}
			}
		}

		public static CPerson GetPersonByID(uint ID) =>
			dataHolder.People.Find(x => x.Id == ID);

		public static CMerchandise GetMerchandisenByID(uint ID) =>
			dataHolder.Goods.Find(x => x.ID == ID);

		public static uint GetNewPersonID() => 
			(uint)dataHolder.People.Count;

		public static uint GetNewStuffID() => 
			(uint)dataHolder.Goods.Count;

		public static void AddPerson(CPerson person) => 
			dataHolder.People.Add(person);

		public static void AddStuff(CMerchandise merchandise) => 
			dataHolder.Goods.Add(merchandise);

		public static bool RemovePerson(CPerson person) => 
			dataHolder.People.Remove(person); //totally Writted by intelliSense.

		public static bool RemoveStuff(CMerchandise merchandise) => 
			dataHolder.Goods.Remove(merchandise);

	}
}
