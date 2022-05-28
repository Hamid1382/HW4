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
			currentUser = id;
		}
		public static void AddStuff(CMerchandise merchandise)
		{
			merchandise.ID = DataStorage.GetNewStuffID();
			merchandise.Added = DateTime.Now;
			merchandise.OwnerID = currentUser.GetValueOrDefault();
			merchandise.Rate = new CRate();
			merchandise.LastUpdate = DateTime.Now;
			DataStorage.AddStuff(merchandise);
		}
		public static SResolution GetSResolution(uint width, uint height) =>
			new SResolution() { Height = height, Width = width };
		public static void Logout() => currentUser = null;
		public static bool Login(string name, string password) {
			var found = DataStorage.dataHolder.People.Where<CPerson>
				(x => x.Username == name && x.Password == password);
			if (found.Any<CPerson>())
			{
				currentUser = found.First<CPerson>().Id;
			}
			return found.Any<CPerson>();

		}
			

		public static void SignIn(String name, string username, string password) => 
			DataStorage.AddPerson(new CPerson()
			{
				Id = DataStorage.GetNewPersonID(),
				Name = name,
				Username = username,
				Password = password,
				Role = (DataStorage.dataHolder.People.Count == 0 ? ERole.mainAdmin : ERole.Costumer)
			});

	}
}

