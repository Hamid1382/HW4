using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Helper;
using DAL.Goods;
using System.IO;
using System.Xml.Serialization;
namespace BLL
{
	public class DataHolder
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
		private static XmlSerializer serializer;
		static DataStorage()
		{
			var xmlAttributes = new XmlAttributes();
			xmlAttributes.XmlElements.Add(new XmlElementAttribute("CCpu", typeof(CCpu)));
			xmlAttributes.XmlElements.Add(new XmlElementAttribute("CGpu", typeof(CGpu)));
			xmlAttributes.XmlElements.Add(new XmlElementAttribute("CMotherboard", typeof(CMotherboard)));
			xmlAttributes.XmlElements.Add(new XmlElementAttribute("CRam", typeof(CRam)));
			var xmlAttributeOverrides = new XmlAttributeOverrides();
			xmlAttributeOverrides.Add(typeof(DataHolder) , "Goods" , xmlAttributes);
			serializer = new XmlSerializer(typeof(DataHolder) , xmlAttributeOverrides);
		}
		public static string SavePath { get; set; }
		public static DataHolder dataHolder;
		public static void NewSession()
		{
			SavePath = null;
			dataHolder = new DataHolder();
		}
		public static void PerviousSession(string savePath)
		{
			using(var stream = new StreamReader(savePath))
			{
				dataHolder = serializer.Deserialize(stream) as DataHolder;
			}
		}
		public static void Reload() => PerviousSession(SavePath);
		public static void Save()
		{
			using (var stream = new StreamWriter(SavePath))
				serializer.Serialize(stream, dataHolder);
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
