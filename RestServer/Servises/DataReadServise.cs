using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using RestServer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RestServer.Servises
{
	/// <summary>
	/// Using Npoi becouse asp.net core cant read xls without libraris and EPPlus cant read xls
	/// </summary>
	public class DataReadServise
	{
		/// <summary>
		/// Parsing String with date to DateTime |||
		/// i dont found easer way to parse string with date to DataTime|
		/// The reason: 1.2.18 , 1.10.18 , 01.02.2018 shall be parsed by 3 diferent functions =>
		/// this is to mush to do, and test
		/// </summary>
		/// <param name="Input"></param>
		/// <returns></returns>
		private static DateTime StringToDate(String Input)
		{
			var data = Input.Split(".");
			int day = int.Parse(data[0]);
			int month = int.Parse(data[1]);
			int year = int.Parse(data[2]);
			return new DateTime(year,month,day);
		}

		public static List<Data> GetData()
		{
			var answer = new List<Data>();

			HSSFWorkbook book;
			using (FileStream file = new FileStream(@"DataFile.xls", FileMode.Open, FileAccess.Read))
			{
				book = new HSSFWorkbook(file);
			}

			ISheet page = book.GetSheet("Page1");
			for (int row = 1; row <= page.LastRowNum; row++)
			{
				var item = page.GetRow(row);
				if (item != null) //null is when the row only contains empty cells
				{
					try
					{
						String Name = item.Cells[0].ToString();
						String Url = item.Cells[3].ToString();
						DateTime StartData = StringToDate(item.Cells[1].ToString());
						DateTime EndData = StringToDate(item.Cells[2].ToString());
						answer.Add(new Data(Name, StartData, EndData, Url));
					}
					catch (Exception e)
					{
						// im lazy to parse if some data is not correct or dont exist
						// first of all, i dont know what i shall do
						// put a message on it place like "Ещё не выбрано" or it ""?
						// mush easer to skip this line
						Console.Error.WriteLine("Cant parse xls row to Data");
						Console.Error.WriteLine(e.Message);
					}
				}
			}
			return answer;
		}
	}
}
