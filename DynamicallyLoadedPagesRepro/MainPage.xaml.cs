
using System.Reflection;

namespace DynamicallyLoadedPagesRepro;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
    {
		// Works fine if directly referenced.
        //Application.Current.MainPage = new NavigationPage(new Home());

        var assemblyPath = Path.Combine(FileSystem.AppDataDirectory, "MyModule.dll");
        using (var resStream = FileSystem.OpenAppPackageFileAsync("MyModule.dll").Result)
        {
            using var writeStream = new FileStream(assemblyPath, FileMode.Create);
            resStream.CopyTo(writeStream);
        }
        var symbolPath = Path.Combine(FileSystem.AppDataDirectory, "MyModule.pdb");
        using (var resStream = FileSystem.OpenAppPackageFileAsync("MyModule.pdb").Result)
        {
            using var writeStream = new FileStream(symbolPath, FileMode.Create);
            resStream.CopyTo(writeStream);
        }

        var assem = Assembly.LoadFile(assemblyPath);
        var moduleClass = assem.GetTypes().First(t => t.Name == "ModuleMain");
        var moduleInstance = Activator.CreateInstance(moduleClass);
        var initMethod = moduleClass.GetMethod("Init");
        initMethod.Invoke(moduleInstance, null);
    }
}

