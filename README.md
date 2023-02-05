# DynamicallyLoadedPagesRepro

To set this up, build the solution (don't run), add a symbolic link from the MyModule build result into the assets of the main project:

    cd DynamicallyLoadedPagesRepro\Resources\Raw
    mklink MyModule.dll ..\..\..\MyModule\bin\Debug\net7.0\MyModule.dll

To trigger loading the Page from the module DLL, click on the button on the MainPage. When running with a debugger, you can see that the Header ContentView does not display. When starting without debugging it just hard crashes.

To reproduce the issue with breakpoints in the loaded DLL, place a breakpoint in ModuleMain.cs in the MyModule project.
