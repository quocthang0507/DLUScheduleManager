using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DLUSchedule.Services
{
	public class AsyncLazy<T> : Lazy<Task<T>>
	{
		readonly Lazy<Task<T>> instance;

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "VSTHRD011:Use AsyncLazy<T>", Justification = "<Pending>")]
		public AsyncLazy(Func<T> factory)
		{
			instance = new Lazy<Task<T>>(() => Task.Run(factory));
		}

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "VSTHRD011:Use AsyncLazy<T>", Justification = "<Pending>")]
		public AsyncLazy(Func<Task<T>> factory)
		{
			instance = new Lazy<Task<T>>(() => Task.Run(factory));
		}

		public TaskAwaiter<T> GetAwaiter()
		{
			return instance.Value.GetAwaiter();
		}
	}
}
