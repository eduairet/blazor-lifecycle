# Blazor Lifecycle

Notes and examples for deep understanding of Blazor component lifecycle.

## Project
- [BlazorLifecycle Server Side](./BlazorLifecycle/BlazorLifecycle/BlazorLifecycle.csproj)
- [BlazorLifecycle Client Side](./BlazorLifecycle/BlazorLifecycle.Client/BlazorLifecycle.Client.csproj)
- Run the project locally by running any of the following commands:
  ```bash
  dotnet run --project BlazorLifecycle.csproj
  dotnet watch --project BlazorLifecycle.csproj
  ```
  - You can also run the project from your IDE.
- And in parallel run tailwindcss watcher in the server side project:
  ```bash
  cd BlazorLifecycle
  npx tailwindcss -i ./Styles/app.css -o ./wwwroot/app.css --watch
  ```

## Notes
1. [Lifecycle Events Introduction](./_notes/01-lifecycle-events-intro.md)
2. [`SetParametersAsync`](./_notes/02-set-parameters-async.md)

## Further reading
- [API Documentation](https://learn.microsoft.com/en-us/dotnet/api/)
- [`ComponentBase`](https://github.com/dotnet/aspnetcore/blob/main/src/Components/Components/src/ComponentBase.cs)
- [ASP.NET Core Razor component rendering](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/rendering?view=aspnetcore-9.0#statehaschanged)