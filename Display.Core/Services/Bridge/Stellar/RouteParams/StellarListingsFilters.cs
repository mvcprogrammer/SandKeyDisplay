namespace Display.Core.Services.Bridge.Stellar.RouteParams;

public static class StellarListingsFieldsToRetrieve
{
    private static readonly string[] FieldToRetrieve =
    {
        "ListPrice",
        "SubdivisionName",
        "BedroomsTotal",
        "Media",
        "BathroomsFull",
        "BathroomsHalf",
        "LivingArea",
        "PetsAllowed",
        "ExteriorFeatures",
        "PoolFeatures",
        "InteriorFeatures",
        "WaterfrontFeatures",
        "CommunityFeatures",
        "YearBuilt",
        "GarageYN",
        "PublicRemarks",
        "PropertyType",
        "PropertySubType",
        "ListOfficeName",
        "UnparsedAddress",
        "ListingKey",
        "ListingId"
    };
    
    public static string GetFields => string.Join(",", FieldToRetrieve);
}

public static class StellarQueryFilter
{
    private static readonly string[] ClearwaterBeachQueryFilter = {"MlsStatus=Active", "PostalCode=33767"};
    public static string GetClearwaterBeachQueryFilter => string.Join("&", ClearwaterBeachQueryFilter);
}