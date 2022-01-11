using DLUSchedule.Models;
using Microsoft.VisualStudio.Threading;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DLUSchedule.Services
{
	public class LoginDatabase
	{
		static SQLiteAsyncConnection Database;

		public static readonly AsyncLazy<LoginDatabase> Instance = new AsyncLazy<LoginDatabase>(async () =>
		{
			var instance = new LoginDatabase();
			CreateTableResult result = await Database.CreateTableAsync<Login>();
			return instance;
		});

		public LoginDatabase()
		{
			Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
		}

		public Task<List<Login>> GetItemsAsync()
		{
			return Database.Table<Login>().ToListAsync();
		}

		public Task<Login> GetItemByIdAsync(string id)
		{
			return Database.Table<Login>().Where(l => l.ProfessorId == id).FirstOrDefaultAsync();
		}

		public Task<Login> GetItemByNameAsync(string name)
		{
			return Database.Table<Login>().Where(l => l.ProfessorName == name).FirstOrDefaultAsync();
		}

		public Task<int> InsertOrUpdateAsync(Login item)
		{
			_ = Database.DeleteAllAsync<Login>();
			return Database.InsertAsync(item);
		}

		public Task<int> DeleteItemAsync(Login item)
		{
			return Database.DeleteAsync(item);
		}

		public Task<int> DeleteItemsAsync()
		{
			return Database.ExecuteAsync("DELETE * FROM [Login]");
		}
	}
}
