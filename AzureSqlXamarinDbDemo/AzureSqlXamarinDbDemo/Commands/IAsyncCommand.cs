using System.Threading.Tasks;
using System.Windows.Input;

namespace AzureSqlXamarinDbDemo.Commands
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();
        bool CanExecute();
    }
}
