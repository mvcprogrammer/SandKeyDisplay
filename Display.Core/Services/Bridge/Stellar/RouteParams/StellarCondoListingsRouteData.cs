using Display.Core.Services.Bridge.Stellar.Enums;

namespace Display.Core.Services.Bridge.Stellar.RouteParams;

public class StellarCondoListingsRouteData : RouteData
{
    private readonly int _condoId;
    private readonly int _listingType;
    private readonly int _skip;
    private readonly int _take;
    private readonly int _sortBy;
    private readonly int _sortDirection;

    public StellarCondoListingsRouteData(string accessToken, int condoId, int listingType, int skip, int take, int sortBy, int sortDirection) : base(accessToken)
    {
        _condoId = condoId;
        _listingType = listingType;
        _skip = skip;
        _take = take;
        _sortBy = sortBy;
        _sortDirection = sortDirection;
    }
    
    private static readonly string FieldsFilter = StellarListingsFieldsToRetrieve.GetFields;
    private static readonly string QueryFilter = StellarQueryFilter.GetClearwaterBeachQueryFilter;
    
    private string GetCondoFilter => CondoConverter.CondoNameById.TryGetValue(_condoId, out var condoName) ? $"&SubdivisionName.in={condoName}" : string.Empty;
    public string Uri => $"{BasePath}?access_token={AccessToken}&offset={_skip}&limit={_take}&sortBy={EnumConverter.SortByToString(_sortBy)}&order={EnumConverter.SortDirectionToString(_sortDirection)}&fields={FieldsFilter}&{QueryFilter}{GetCondoFilter}";

    
}