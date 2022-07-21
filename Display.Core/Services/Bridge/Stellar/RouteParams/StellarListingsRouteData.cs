using Display.Core.Services.Bridge.Stellar.Enums;

namespace Display.Core.Services.Bridge.Stellar.RouteParams;

public class StellarListingsRouteData : RouteData
{
    private readonly int _condoId;
    private readonly int _listingType;
    private readonly int _skip;
    private readonly int _take;
    private readonly int _sortBy;
    private readonly int _sortDirection;
    
    public StellarListingsRouteData(
        string accessToken,
        int condoId = 0, 
        int listingType = (int)ParamEnums.ListingType.ResidentialSale, 
        int skip = 0, int take = 9,
        int sortBy = (int)ParamEnums.SortBy.ListPrice, 
        int sortDirection = (int)ParamEnums.SortDirection.Descending) : base(accessToken)
    {
        _condoId = condoId;
        _listingType = listingType;
        _skip = skip * take;
        _take = take;
        _sortBy = sortBy;
        _sortDirection = sortDirection;
    }
    
    private static readonly string FieldsFilter = StellarListingsFieldsToRetrieve.GetFields;
    private static readonly string QueryFilter = StellarQueryFilter.GetClearwaterBeachQueryFilter;

    private string GetCondoFilter => CondoConverter.CondoNameById.TryGetValue(_condoId, out var condoName) ? $"&SubdivisionName.in={condoName}" : string.Empty;
    
    public string Uri => $"{BasePath}?access_token={AccessToken}" +
                         $"&offset={_skip}&limit={_take}" +
                         EnumConverter.ListingTypeToString(_listingType) +
                         $"&sortBy={EnumConverter.SortByToString(_sortBy)}" +
                         $"&order={EnumConverter.SortDirectionToString(_sortDirection)}" +
                         $"&fields={FieldsFilter}" +
                         $"&{QueryFilter}{GetCondoFilter}";
}