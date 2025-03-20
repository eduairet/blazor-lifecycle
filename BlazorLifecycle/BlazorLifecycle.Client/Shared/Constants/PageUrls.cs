namespace BlazorLifecycle.Client.Shared.Constants;

public class PageUrls
{
    public const string Home = "/";
    public const string NotFound = "/{*Path}";
    public const string Error = "/error";
    public const string SetParamsAsync = "/set-parameters-async/{Param?}";
    public const string Counter = "/counter";
}