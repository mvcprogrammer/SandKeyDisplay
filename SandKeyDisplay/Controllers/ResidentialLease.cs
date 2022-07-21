using Display.Core.Services.Bridge.Stellar;
using Display.Core.Services.Bridge.Stellar.Enums;
using Microsoft.AspNetCore.Mvc;
using SandKeyDisplay.Mappers;
using SandKeyDisplay.ViewModels;

namespace SandKeyDisplay.Controllers;

[Route("Rental")]
public class ResidentialLeaseController : Controller
{
    private readonly IConfiguration _configuration;
    public ResidentialLeaseController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    private string AccessToken => _configuration["StellarSettings:AccessToken"];
    
    [Route("")]
    public async Task<IActionResult> Index()
    {
        var listings = await GetListings(AccessToken);
        
        if (listings.Count == 0) RedirectToAction("Index", "Home");

        ViewBag.SortDirection = (int)ParamEnums.SortDirection.Descending;
        ViewBag.Skip = 0;
        ViewBag.CondoId = 0;
        
        return View(listings);
    }
    
    [Route("{sortDirection:int}")]
    public async Task<IActionResult> Index(int sortDirection)
    {
        var listings = await GetListings(AccessToken, sortDirection: sortDirection);
        
        if (listings.Count == 0) RedirectToAction("Index", "Home");

        ViewBag.SortDirection = sortDirection;
        ViewBag.Skip = 0;
        ViewBag.CondoId = 0;
        
        return View(listings);
    }
    
    [Route("{sortDirection:int}/{skip:int}")]
    public async Task<IActionResult> Index(int sortDirection, int skip)
    {
        skip = SafeSkip(skip);
        
        var listings = await GetListings(AccessToken, sortDirection: sortDirection, skip: skip);
        
        if (listings.Count == 0) RedirectToAction("Index", "Home");

        ViewBag.SortDirection = sortDirection;
        ViewBag.Skip = skip;
        ViewBag.CondoId = 0;
        
        return View(listings);
    }
    
    [Route("{sortDirection:int}/{skip:int}/{condoId:int}")]
    public async Task<IActionResult> Index(int sortDirection, int skip, int condoId)
    {
        skip = SafeSkip(skip);
        
        var listings = await GetListings(AccessToken, sortDirection: sortDirection, skip: skip, condoId: condoId);
        
        if (listings.Count == 0) RedirectToAction("Index", "Home");

        ViewBag.SortDirection = sortDirection;
        ViewBag.Skip = skip;
        ViewBag.CondoId = condoId;
        
        return View(listings);
    }
    
    [Route("Details/{listingKey}")]
    public async Task<IActionResult> Detail(string listingKey)
    {
        var listings = await GetListing(AccessToken, listingKey);
        return View(listings);
    }
    
    private static async Task<List<ListingViewModel>> GetListings(string accessToken, int sortDirection = (int)ParamEnums.SortDirection.Descending, int skip = 0, int condoId = 0)
    {
        var stellarListingsModel = await StellarService.GetListings(accessToken, sortDirection: sortDirection, skip: skip, condoId: condoId, listingType: (int)ParamEnums.ListingType.ResidentialLease);
        var listingsModel = stellarListingsModel.ToList();
        var listingsViewModel = StellarListingsToListings.Convert(listingsModel);
        return listingsViewModel.ToList();
    }

    private static async Task<ListingViewModel> GetListing(string accessToken, string listingKey)
    {
        var stellarListing = await StellarService.GetListing(accessToken, listingKey);
        var listingViewModel = StellarListingToListing.Convert(stellarListing);
        return listingViewModel;
    }
    
    private static int SafeSkip(int skip)
    {
        return skip < 0 ? 0 : skip;
    }
}