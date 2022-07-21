using Display.Core.Services.Bridge.Stellar.Models;
using SandKeyDisplay.ViewModels;
using Media = SandKeyDisplay.ViewModels.Media;

namespace SandKeyDisplay.Mappers;

public static class StellarListingsToListings
{
    public static IEnumerable<ListingViewModel> Convert(IEnumerable<Bundle> stellarListingsModel) 
        => stellarListingsModel.Select(Convert).ToList();

    private static ListingViewModel Convert(Bundle stellarListingModel)
    {
        var photoList = stellarListingModel.Media?.Select(photo 
            => new Media {Order = photo.Order, MediaUrl = $"/photo{photo.MediaUrl?.AbsolutePath}", MediaCategory = photo.MediaCategory})
            .Where(x => x.MediaCategory == "Photo")
            .OrderBy(x => x.Order)
            .Take(10)
            .ToList();

        return new ListingViewModel
        {
            ListPrice = stellarListingModel.ListPrice ?? 0,
            SubdivisionName = stellarListingModel.SubdivisionName,
            BedroomsTotal = stellarListingModel.BedroomsTotal ?? 0,
            Media = photoList ?? new List<Media>(),
            BathroomsFull = stellarListingModel.BathroomsFull ?? 0,
            BathroomsHalf = stellarListingModel.BathroomsHalf ?? 0,
            LivingArea = stellarListingModel.LivingArea ?? 0,
            WaterfrontYn = stellarListingModel.WaterfrontYn,
            PetsAllowed = stellarListingModel.PetsAllowed,
            ExteriorFeatures = stellarListingModel.ExteriorFeatures,
            PoolFeatures = stellarListingModel.PoolFeatures,
            InteriorFeatures = stellarListingModel.InteriorFeatures,
            PublicRemarks = stellarListingModel.PublicRemarks,
            PropertyType = stellarListingModel.PropertyType,
            PropertySubType = stellarListingModel.PropertySubType,
            ListOfficeName = stellarListingModel.ListOfficeName,
            ListingKey = stellarListingModel.ListingKey,
            ListingId = stellarListingModel.ListingId
        };
    }
}
    