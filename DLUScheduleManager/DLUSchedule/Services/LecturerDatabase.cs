using DLUSchedule.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DLUSchedule.Services
{
	public class LecturerDatabase
	{
		private static SQLiteAsyncConnection database;

		public static readonly AsyncLazy<LecturerDatabase> Instance = new AsyncLazy<LecturerDatabase>(async () =>
		{
			var instance = new LecturerDatabase();
			CreateTableResult result = await database.CreateTableAsync<Lecturer>();
			return instance;
		});

		public LecturerDatabase()
		{
			database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
		}

		public Task<List<Lecturer>> GetLecturersAsync()
		{
			return database.Table<Lecturer>().ToListAsync();
		}

		public Task<List<Lecturer>> GetLecturersNotDoneAsync()
		{
			return database.QueryAsync<Lecturer>("SELECT * FROM [Lecturer]");
		}

		public Task<int> DeleteAllAsync()
		{
			return database.ExecuteAsync("DELETE FROM [Lecturer]");
		}

		public Task<Lecturer> GetItemAsync(string id)
		{
			return database.Table<Lecturer>().Where(x => x.ProfessorID == id).FirstOrDefaultAsync();
		}

		public Task<int> SaveItemAsync(Lecturer lecturer)
		{
			var result = GetItemAsync(lecturer.ProfessorID);
			if (result.Result == null)
			{
				return database.InsertAsync(lecturer);
			}
			else
			{
				return database.UpdateAsync(lecturer);
			}
		}

		public Task<int> DeleteItemAsync(Lecturer lecturer)
		{
			return database.DeleteAsync(lecturer);
		}
	}
}
