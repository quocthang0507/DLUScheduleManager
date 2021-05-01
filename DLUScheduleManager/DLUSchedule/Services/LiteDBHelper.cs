using DLUSchedule.ViewModels;
using LiteDB;
using System;
using System.Linq;

namespace DLUSchedule.Services
{
	public class LiteDBHelper
	{
		private ILiteCollection<HomeViewModel> entities;

		public LiteDBHelper(string path)
		{
			using (var db = new LiteDatabase(path))
			{
				entities = db.GetCollection<HomeViewModel>("Schedule");
			}
		}

		public HomeViewModel GetOne()
		{
			try
			{
				var result = entities.FindAll();
				return result.First();
			}
			catch (Exception)
			{
				return null;
			}
		}

		public void Insert(HomeViewModel model)
		{
			entities.DeleteAll();
			entities.Insert(model);
		}
	}
}
