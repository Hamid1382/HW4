using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Helper;
namespace DAL {
	public class CPerson {
		public uint Id { get; set; }
		public string Username { get; set; }
		public string Name { get; set; }
		public ERole Role { get; set; }
		public string Password { get; set; }
	}
}

