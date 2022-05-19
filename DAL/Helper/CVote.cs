using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helper
{
	/// <summary>
	/// represents a vote 
	/// </summary>
	public class CVote
	{
		/// <summary>
		/// points to customer voted for future changes
		/// </summary>
		public ulong VoterId { get; set; }
		/// <summary>
		/// from 0 to 5,worst to best
		/// </summary>
		public ushort Stars { get; set; }
	}
}
