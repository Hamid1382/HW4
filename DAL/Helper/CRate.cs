using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Helper
{
	/// <summary>
	/// reperesents a Rate for a Merchandise
	/// </summary>
	public class CRate
	{
		public List<CVote> Votes { get; set; }
		public uint TotalStars {
			get
			{
				uint _totalStars = 0;
				foreach (var vote in this.Votes)
					_totalStars += vote.Stars;
				return _totalStars;
			}
		}
		/// <summary>
		/// returns null if no one has voted
		/// </summary>
		public long? Percent
		{
			get
			{
				if (this.Votes.Count == 0)
					return null;
				return (100 * this.TotalStars) / this.Votes.Count;
			}
		}
		public CRate()
		{ 
			this.Votes = new List<CVote>();
		}

	}
}


