namespace Display.Core.Services.Bridge.Stellar.RouteParams;

public class StellarListingRouteData : RouteData
{
    private readonly string _listingKey;

    public StellarListingRouteData(string accessToken, string listingKey) : base(accessToken)
    {
        _listingKey = listingKey;
    }

    public string Uri => $"{BasePath}/{_listingKey}?access_token={AccessToken}&fields={StellarListingsFieldsToRetrieve.GetFields}";
}