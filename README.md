# DynamicallyLoadedPagesRepro

To set this up, build the solution (don't run), add a symbolic link from the MyModule build result into the assets of the main project:

    cd DynamicallyLoadedPagesRepro\Resources\Raw
    mklink MyModule.dll ..\..\..\MyModule\bin\Debug\net7.0\MyModule.dll

To trigger loading the Page from the module DLL, click on the button on the MainPage.

To reproduce the issue with breakpoints in the loaded DLL, place a breakpoint in ModuleMain.cs in the MyModule project.
