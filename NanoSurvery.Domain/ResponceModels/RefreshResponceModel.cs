using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NanoSurvery.Domain.Models;

namespace NanoSurvery.Domain.ResponceModels
{
	public class RefreshResponceModel
	{
		public string Jwt { get; set; } = string.Empty;
		public string Message { get; set; } = string.Empty;
		public RefreshToken RefreshToken { get; set; } = new RefreshToken();
	}
}
