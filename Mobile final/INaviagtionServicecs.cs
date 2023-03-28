using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile_final;

public interface INavigationService
{
    Task NaviagteToAsync(string desination);
    Task NavigateToAsync(string desination, IDictionary<string, object> parameters);
    Task NavigateBackAsync();
}

public class NavigationService : INavigationService
{
    public async Task NaviagteToAsync(string desination)
    {
        await Shell.Current.GoToAsync(desination);
    }

    public async Task NavigateBackAsync()
    {
        await Shell.Current.GoToAsync("..");
    }

    public async Task NavigateToAsync(string desination, IDictionary<string, object> parameters)
    {
        await Shell.Current.GoToAsync(desination, parameters);
    }

}

