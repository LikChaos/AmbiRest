using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestServer.Models;
using RestServer.Servises;
using System;
using System.Collections.Generic;

namespace RestServer.Controllers
{
	[Route("[controller]")]
	public class DataController : Controller
	{
		// GET /data
		[HttpGet]
		public String Get()
		{
			List<Data> data = DataReadServise.GetData();
			String answer = JsonConvert.SerializeObject(data);
			return answer;
		}
	}
}
