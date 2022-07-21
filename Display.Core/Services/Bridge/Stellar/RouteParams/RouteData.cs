namespace Display.Core.Services.Bridge.Stellar.RouteParams;

public class RouteData
{
    public RouteData(string accessToken)
    {
        AccessToken = accessToken;
    }
    protected const string BasePath = "v2/stellar/listings";
    protected string AccessToken { get; }
}   