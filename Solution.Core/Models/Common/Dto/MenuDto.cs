using Solution.Core.Models.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Core.Models.Common.Dto
{
	public class CreateMenuDto
	{
		public string Content { get; set; }
		public string IconClass { get; set; }
		public string Url { get; set; }
		public IList<MenuDto> Children { get; set; }
	}
	public class MenuDto: CreateMenuDto
	{
		public string Id { get; set; }
	}

}
