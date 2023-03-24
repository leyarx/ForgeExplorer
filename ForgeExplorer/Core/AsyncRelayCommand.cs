using System;
using System.Threading.Tasks;

namespace ForgeExplorer.Core
{
    public class AsyncRelayCommand : AsyncCommandBase
    {
        private readonly Func<Task> _callback;

        public AsyncRelayCommand(Func<Task> callback, Action<Exception> onException) : base(onException)
        {
            _callback = callback;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            await _callback();
        }
    }
}
