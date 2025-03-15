# Lifecycle events

- Set of synchronous and asynchronous methods that are called during the lifecycle of a Blazor component.
- They can be overridden to perform custom logic.

## Lifecycle events

- General rules:
  - Synchronous methods are called before asynchronous methods.
  - Parent component lifecycle events are called before child component lifecycle events.
  - In server-side prerendering waits for quiescence (no more tasks to run) before rendering.
- Lifecycle events are called in the following order:
  - **Initialization**: `OnInitialized`, `OnInitializedAsync`
    - Create component instance.
    - Properties are injected.
    - Waits until the component is fully initialized (Task is returned).
  - **When parameters are set**: `SetParametersAsync`
    - Sets the parameters of the component.
  - **Parameter change**: `OnParametersSet`, `OnParametersSetAsync`
    - Called when parameters are set.
  - **Render**: `OnAfterRender`, `OnAfterRenderAsync`
    - Called after the component has been rendered.
    - Can be called multiple times.
    - Can be used to interact with the DOM. (JavaScript interop)

- Pre-rendering lifecycle events:
  ```
  ┌──────────────────────┐
  │ OnInitialized{Async} │
  └──────────┬───────────┘
             ▼
      ┌─────────────┐ No  ┌────────────┐   ┌────────────────────┐
      │Task complete├───► │ Await task ├─► │       Render       │
      └──────┬──────┘     └────────────┘   └────────────────────┘
             ▼ Yes
  ┌───────────────────────┐
  │        Render         │
  └──────────┬────────────┘
             ▼
      ┌─────────────┐ No  ┌────────────┐   ┌────────────────────┐
      │Task complete├───► │ Await task ├─► │       Render       │
      └──────┬──────┘     └────────────┘   └────────────────────┘
             ▼ Yes
  ┌───────────────────────┐
  │        Render         │
  └───────────────────────┘
  ```
- DOM event processing
  ```
  ┌───────────────────────┐
  │   Run event handler   │
  └──────────┬────────────┘
             ▼
      ┌─────────────┐ No  ┌────────────┐   ┌────────────────────┐
      │Task complete├───► │ Await task ├─► │       Render       │
      └──────┬──────┘     └────────────┘   └────────────────────┘
             ▼ Yes
  ┌───────────────────────┐
  │        Render         │
  └───────────────────────┘
  ```
- Rendering
```
┌───────────────────────────────────────────┐ No  ┌────────────┐
│ Is first render or ShoudRender() == true? ├───► │ Do nothing │
└────────────┬──────────────────────────────┘     └────────────┘
             ▼ Yes
  ┌─────────────────────────┐
  │    Build render tree    │
  │ Set render batch to DOM │
  └──────────┬──────────────┘
             ▼ 
   ┌───────────────────┐
   │ Await DOM update  │
   └─────────┬─────────┘
             ▼
 ┌──────────────────────┐
 │ OnAfterRender{Async} │
 └──────────────────────┘
```

- Calls to `StateHasChanged` method:
  - Triggers a re-render of the component.
  - Calls `OnAfterRender` and `OnAfterRenderAsync` lifecycle events.
  - Call `ShouldRender` method to determine if the component should re-render.