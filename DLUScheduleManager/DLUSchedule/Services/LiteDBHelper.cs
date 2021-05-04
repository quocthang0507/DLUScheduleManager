using DLUSchedule.Models;
using LiteDB;
using System;
using System.Linq;

namespace DLUSchedule.Services
{
	public class LiteDBHelper : IDisposable
	{
		// To detech redundant calls
		private bool _disposed = false;
		private ILiteCollection<Login> entities;

		public LiteDBHelper(string path)
		{
			using (var db = new LiteDatabase(path))
			{
				entities = db.GetCollection<Login>("Login");
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_disposed)
				return;
			if (disposing)
			{
				// TODO: 
			}
			_disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
		}

		public Login GetOne()
		{
			try
			{
				var result = entities.FindAll();
				return result.First();
			}
			catch (Exception e)
			{
				return null;
			}
		}

		public void Insert(Login model)
		{
			entities.DeleteAll();
			entities.Insert(model);
		}
	}
}
