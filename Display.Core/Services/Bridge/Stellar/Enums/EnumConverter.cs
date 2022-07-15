namespace Display.Core.Services.Bridge.Stellar.Enums;

public static class EnumConverter
{
    public static string SortDirectionToString(int sortDirection) => 
        sortDirection switch
    {
        (int)ParamEnums.SortDirection.Ascending => "asc",
        (int)ParamEnums.SortDirection.Descending => "desc",
        _=> ""
    };

    public static string SortByToString(int sortBy) => sortBy switch
    {
        (int)ParamEnums.SortBy.ListPrice => "ListPrice",
        _ => ""
    };
    
    public static string ListingTypeToString(int listingType) => listingType switch
    {
        (int)ParamEnums.ListingType.ResidentialSale => "&PropertyType=Residential",
        (int)ParamEnums.ListingType.ResidentialLease => "&PropertyType=Residential%20Lease",
        _ => ""
    };
}