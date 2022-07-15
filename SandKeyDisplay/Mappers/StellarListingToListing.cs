using Display.Core.Services.Bridge.Stellar.Models;
using SandKeyDisplay.ViewModels;

namespace SandKeyDisplay.Mappers;

public static class StellarListingToListing
{
    public static ListingViewModel Convert(Bundle stellarListingModel)
    {
        var photoList = stellarListingModel.Media?.Select(photo 
            => new ViewModels.Media {Order = photo.Order, MediaUrl = $"/photo{photo.MediaUrl?.AbsolutePath}", MediaCategory = photo.MediaCategory})
            .Where(x => x.MediaCategory == "Photo")
            .OrderBy(x => x.Order)
            .Take(10)
            .ToList();

        return new ListingViewModel
        {
            ListPrice = stellarListingModel.ListPrice ?? 0,
            SubdivisionName = stellarListingModel.SubdivisionName,
            BedroomsTotal = stellarListingModel.BedroomsTotal ?? 0,
            Media = photoList,
            BathroomsFull = stellarListingModel.BathroomsFull ?? 0,
            BathroomsHalf = stellarListingModel.BathroomsHalf ?? 0,
            LivingArea = stellarListingModel.LivingArea ?? 0,
            WaterfrontYn = stellarListingModel.WaterfrontYn,
            PetsAllowed = stellarListingModel.PetsAllowed,
            ExteriorFeatures = stellarListingModel.ExteriorFeatures,
            PoolFeatures = stellarListingModel.PoolFeatures,
            InteriorFeatures = stellarListingModel.InteriorFeatures,
            WaterfrontFeatures = stellarListingModel.WaterfrontFeatures,
            CommunityFeatures = stellarListingModel.CommunityFeatures,
            YearBuilt = stellarListingModel.YearBuilt ?? 0,
            GarageYn = stellarListingModel.GarageYn,
            LastModification = $"{stellarListingModel.BridgeModificationTimestamp.ToLocalTime()}.",
            PublicRemarks = stellarListingModel.PublicRemarks,
            PropertyType = stellarListingModel.PropertyType,
            PropertySubType = stellarListingModel.PropertySubType,
            ListOfficeName = stellarListingModel.ListOfficeName,
            UnparsedAddress = stellarListingModel.UnparsedAddress,
            ListingKey = stellarListingModel.ListingKey,
            ListingId = stellarListingModel.ListingId
        };
    }
}
    