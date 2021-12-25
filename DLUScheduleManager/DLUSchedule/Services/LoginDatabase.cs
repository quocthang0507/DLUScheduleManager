using DLUSchedule.Models;
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

		public async Task<List<Login>> GetItemsAsync()
		{
			return await Database.Table<Login>().ToListAsync();
		}

		public async Task<Login> GetItemByIdAsync(string id)
		{
			return await Database.Table<Login>().Where(l => l.ProfessorId == id).FirstOrDefaultAsync();
		}

		public async Task<Login> GetItemByNameAsync(string name)
		{
			return await Database.Table<Login>().Where(l => l.ProfessorName == name).FirstOrDefaultAsync();
		}

		public async Task<int> InsertOrUpdateAsync(Login item)
		{
			await Database.DeleteAllAsync<Login>();
			return await Database.InsertAsync(item);
		}

		public async Task<int> DeleteItemAsync(Login item)
		{
			return await Database.DeleteAsync(item);
		}

		public async Task<int> DeleteItemsAsync()
		{
			return await Database.ExecuteAsync("DELETE * FROM [Login]");
		}
	}
}
