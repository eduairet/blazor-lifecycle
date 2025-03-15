# `SetParametersAsync`

- Sets the parameters of the component.
- Overriding this method allows to interact with `ParameterView`.
  - The `ParameterView` is a struct that contains the parameters of the component.
- Generally, we have to use `base.SetParametersAsync(ParameterView)` when overriding
  - Calling `base.SetParametersAsync(ParameterView)` is important to ensure that the component is updated correctly.
  - `await base.SetParametersAsync(ParameterView.Empty);` is used when need the method but we don't need to process the parameters.
- `ParameterView.TryGetValue<T>(string key, out T value)` is used to get the value of a parameter (case sensitive for routing parameters).

    ```razor
    @page "/set-params-async/{Param?}"
    
    <PageTitle>Set Parameters Async</PageTitle>
    
    <h1>Set Parameters Async Example</h1>
    
    <p>@message</p>
    
    @code {
        private string message = "Not set";
    
        [Parameter]
        public string? Param { get; set; }
    
        public override async Task SetParametersAsync(ParameterView parameters)
        {
            if (parameters.TryGetValue<string>(nameof(Param), out var value))
            {
                if (value is null)
                {
                    message = "The value of 'Param' is null.";
                }
                else
                {
                    message = $"The value of 'Param' is {value}.";
                }
            }
    
            await base.SetParametersAsync(parameters);
        }
    }
    ```