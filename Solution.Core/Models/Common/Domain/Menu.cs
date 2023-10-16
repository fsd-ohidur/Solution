using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Core.Models.Common.Domain
{
	public class Menu:BaseModel
	{
		public string ParentID { get; set; }
		public string Content { get; set; }
		public string IconClass { get; set; }
		public string Url { get; set; }
		public long Order { get; set; }
	}
}
