# The Summary of Creating a View Component using Razor Pages

View Components' File Structure
----

- A View Component implementation follows a naming convention, demonstrated below.
- Assuming to have two View Components named "Foo" and "Bar"
- Each View Component has two parts - Code and View

```dotnet

/Domain.cs              // contains Domain models used by View Components

/Services/              // Services used by View Components
    IXyzService.cs      // Service Interface
    XyzService.cs       // Implementation of the Service

/ViewComponents/        // contains all View Components' Code files
    FooViewComponent.cs // "Code" part of the Foo View Component (IXyzService is injected)
    BarViewComponent.cs // "Code" part of the Bar View Component (IXyzService is injected)
                        // In the end, a "View" is called with "Foo" or "Bar", the name of
                        // the View Component--like: return View("Foo");
/Pages/
    _ViewImports.cshtml     // include View Components as tag helpers
                            // eg: @addTagHelper: *, ViewCompDemo <<< the project name
    Components/
        Foo/default.cshtml  // "View" part of the Foo View Component
        Bar/default.cshtml  // "View" part of the Bar View Component

    Shared/_Layout.cshtml   // Example of View Component usage

/Startup.cs     // Setup the IOC container for XyzService, ready to be injected
                // into View Component's Code
                // eg:
                // services.AddTransient<IXyzService, XyzService>();

```

Two ways to Use View Components
----

1. Directly calls Component's Invoke/Async("[Component-Name"], arg1 = "value1", arg2="value2"...);

    ```dotnet
        @await Component.InvokeAsync("Foo");
        @await Component.InvokeAsync("Bar", new Random().Next(1, 10));
    ```

2. Uses a View Component as a tag helper

    ```dotnet
        <vc:foo></vc:foo>
        <vc:bar id="new Random().Next(1,10)"></vc:bar>
    ```

Difference between Partial View and View Component
----

- A View Component is much like a Partial View.
- A View Component is self contained with Code and View parts.
- A View Component is a way to separate of concerns, not depending on controller, and testable.
- A Partial View uses Single File Approach, with needed models are injected into it.
- Using a View Component can

    + callView Component's Invoke/Async(...);

    ```dotnet
        Invoke/Async("[Component-Name"], arg1 = "value1", arg2="value2"...);
    ```

    + use View Component as tag helper

    ```dotnet
        <vc:[view-component-name] arg1="value1" arg2="value2"></vc:[view-component-name]>
    ```

- Using a Partial View by using the `<partial>` tag helper

    ```dotnet
        <partial name="_LoginPartial"/>
    ```
