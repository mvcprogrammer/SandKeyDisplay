namespace SandKeyDisplay.ViewModels;

public record ListingViewModel
{
    public int ListPrice { get; init; }
    public string GetListPrice => $"${ListPrice:N0}";
    public string GetLeasePrice => $"{GetListPrice}/Month";
    public string SubdivisionName { get; init; } = string.Empty;
    public int BedroomsTotal { get; init; }
    public string LastModification { get; init; } = string.Empty;
    public List<Media>? Media { get; init; } = new();
    public int BathroomsFull { get; init; }
    public int BathroomsHalf { get; init; }
    public int LivingArea { get; init; }
    public string GetLivingArea => LivingArea.ToString("N0");
    public bool WaterfrontYn { get; init; }
    public List<string> PetsAllowed { get; init; } = new();
    public List<string> ExteriorFeatures { get; init; } = new();
    public List<string> PoolFeatures { get; init; } = new();
    public List<string> InteriorFeatures { get; init; } = new();
    public List<string> WaterfrontFeatures { get; init; } = new();
    public List<string> CommunityFeatures { get; init; } = new();
    public int YearBuilt { get; init; }
    public bool? GarageYn { get; init; }
    public string GetHasGarage => GarageYn switch {true => "Yes", false => "No", _ => "Unspecified"};
    public string PublicRemarks { get; init; } = string.Empty;
    public string PropertyType { get; init; } = string.Empty;
    public string PropertySubType { get; init; } = string.Empty;
    public string ListOfficeName { get; init; } = string.Empty;
    public string UnparsedAddress { get; init; } = string.Empty;
    public string ListingKey { get; init; } = string.Empty;
    public string ListingId { get; set; } = string.Empty;
}

public record Media
{
    public long Order { get; init; }
    public string? MediaUrl { get; init; }
    public string? MediaCategory { get; init; }
}