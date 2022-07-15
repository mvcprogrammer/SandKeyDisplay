using Display.Core.Services.Bridge.Stellar.Enums;
using Display.Core.Services.Bridge.Stellar.HttpClient;
using Display.Core.Services.Bridge.Stellar.Models;
using Display.Core.Services.Bridge.Stellar.RouteParams;

namespace Display.Core.Services.Bridge.Stellar;

public static class StellarService
{
    public static async Task<IEnumerable<Bundle>> GetListings(
        string accessToken,
        int listingType = (int)ParamEnums.ListingType.ResidentialSale,
        int skip = 0, 
        int sortDirection = (int)ParamEnums.SortDirection.Descending, 
        int condoId = 0)
    {
        var stellarListingsRouteData = new StellarListingsRouteData(
            accessToken,
            sortDirection: sortDirection, 
            skip: skip, 
            condoId: condoId, 
            listingType:listingType);

        var stellarListingResponse = await StellarClient.GetAsync(stellarListingsRouteData.Uri);

        if (stellarListingResponse == null)
            throw new Exception("Failure getting Stellar Listings Data.");

        var stellarListingModel = (IEnumerable<Bundle>)stellarListingResponse.bundle.ToObject<IEnumerable<Bundle>>();
        return stellarListingModel;
    }
    
    public static async Task<Bundle> GetListing(string accessToken, string listingKey)
    {
        var stellarListingRouteData = new StellarListingRouteData(accessToken, listingKey);

        var stellarListingResponse = await StellarClient.GetAsync(stellarListingRouteData.Uri);

        if (stellarListingResponse == null)
            throw new Exception("Failure getting Stellar Listing Data.");
        
        var stellarListingModel = (Bundle)stellarListingResponse.bundle.ToObject<Bundle>();
        return stellarListingModel;
    }
}