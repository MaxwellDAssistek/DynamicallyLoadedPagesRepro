using System.Diagnostics;

namespace MyModule;

public class ModuleMain
{
    public void Init()
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Application.Current!.UserAppTheme = AppTheme.Light;

            // Put breakpoint here.
            var navPage = new NavigationPage(new Home());
            Application.Current!.MainPage = navPage;
        });
    }
}
