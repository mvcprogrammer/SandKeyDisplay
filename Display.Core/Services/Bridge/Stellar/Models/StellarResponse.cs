namespace Display.Core.Services.Bridge.Stellar.Models;

public record StellarListingResponse()
{
    public bool Success { get; set; }
    public int Status { get; set; }
    public Bundle? Bundle { get; set; } = null;
    public string ErrorMessage { get; set; } = string.Empty;
}

public record StellarListingsResponse
{
    public bool Success { get; set; }
    public int Status { get; set; }
    public List<Bundle>? Bundle { get; set; }
    public int Total { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
}

public record Bundle
{
    public int? ListPrice { get; set; }
    public string SubdivisionName { get; set; } = string.Empty;
    public int? BedroomsTotal { get; set; }
    public DateTime BridgeModificationTimestamp { get; set; }
    public List<Media>? Media { get; set; } = new();
    public int? BathroomsFull { get; set; }
    public int? BathroomsHalf { get; set; }
    public int? LivingArea { get; set; }
    public bool WaterfrontYn { get; set; } = false;
    public List<string> PetsAllowed { get; set; } = new();
    public List<string> ExteriorFeatures { get; set; } = new();
    public List<string> PoolFeatures { get; set; } = new();
    public List<string> InteriorFeatures { get; set; } = new();
    public List<string> WaterfrontFeatures { get; set; } = new();
    public List<string> CommunityFeatures { get; set; } = new();
    public int? YearBuilt { get; set; } = default;
    public bool? GarageYn { get; set; }
    public string PublicRemarks { get; set; } = string.Empty;
    public string PropertyType { get; set; } = string.Empty;
    public string PropertySubType { get; set; } = string.Empty;
    public string ListOfficeName { get; set; } = string.Empty;
    public string UnparsedAddress { get; set; } = string.Empty;
    public string ListingKey { get; set; } = string.Empty;
    public string ListingId { get; set; } = string.Empty;
}

public partial record Media
{
    public long Order { get; set; }
    public Uri? MediaUrl { get; set; }
    public string MediaCategory { get; set; } = string.Empty;
}