using Display.Core.Services.Bridge.Stellar;
using FluentEmail.Core;
using Microsoft.AspNetCore.Mvc;
using SandKeyDisplay.Mappers;
using SandKeyDisplay.ViewModels;

namespace SandKeyDisplay.Controllers;

[Route("Email")]
public class EmailController : Controller
{
    private readonly IConfiguration _configuration;
    public EmailController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    private string AccessToken => _configuration["StellarSettings:AccessToken"];
    
    [Route("Residential/{emailAddress}/{listingKey}")]
    public async Task<IActionResult> ResidentialEmail([FromServices] IFluentEmail singleEmail, string emailAddress, string listingKey)
    {
        var listing = await GetListing(listingKey);

        if (listing.PropertyType.ToUpperInvariant().Contains("LEASE"))
        {
            return RedirectToAction("RentalEmail", "Email", new {singleEmail, emailAddress, listingKey});
        }
        
        var strDetails = "Address: " + listing.UnparsedAddress + "\r\n";
        strDetails += listing.BedroomsTotal + " beds, " + listing.BathroomsFull + " full baths " + listing.BathroomsHalf + " half bath\r\n";
        strDetails += "Property Type: " + listing.PropertySubType + "\r\n";
        strDetails += "Price: " + $"{listing.GetListPrice}" + "\r\n\r\n";
        strDetails += "More info link: " + $"https://www.c21coasttocoast.com/property/{listing.ListingId}/";
        strDetails += "\r\n\r\n";
        strDetails += "Description: \r\n" + listing.PublicRemarks  + "\r\n\r\n";
        
        strDetails += "Thank you, and I look forward to hearing from you.\r\n\r\n";
        strDetails += "Office Manager - CENTURY 21 Coast to Coast\r\n";
        strDetails += "Office: 727-398-3030\r\n";
        strDetails += "info.request@sandkeyhomesandcondos.com\r\n";
        strDetails += "www.c21coasttocoast.com\r\n\r\n";
        strDetails += "CENTURY 21 Coast to Coast\r\n";
        strDetails += "1261 Gulf Blvd #128\r\n";
        strDetails += "Clearwater Beach, Fl 33767\r\n\r\n";
        strDetails += "Information deemed reliable but not guaranteed.  Parties are advised to verify.";
        
        singleEmail
            .To(emailAddress)
            .BCC("mkochc21@gmail.com")
            .BCC("mvc.programmer@gmail.com")
            .Subject($"Property Details Request from Sand Key Display: {listing.ListingId}")
            .Body(strDetails);
        
        var response = await singleEmail.SendAsync();

        return response.Successful 
            ? new StatusCodeResult(StatusCodes.Status202Accepted) 
            : new StatusCodeResult(StatusCodes.Status503ServiceUnavailable);
    }
    
    [Route("Rental/{emailAddress}/{listingKey}")]
    public async Task<IActionResult> RentalEmail([FromServices] IFluentEmail singleEmail, string emailAddress, string listingKey)
    {
        var listing = await GetListing(listingKey);
        
        var strDetails = "Address: " + listing.UnparsedAddress + "\r\n";
        strDetails += listing.BedroomsTotal + " beds, " + listing.BathroomsFull + " full baths " + listing.BathroomsHalf + " half bath\r\n";
        strDetails += "Property Type: " + listing.PropertySubType + "\r\n";
        strDetails += "Price: " + $"${listing.GetLeasePrice}" + "\r\n\r\n";
        strDetails += "Description: \r\n" + listing.PublicRemarks  + "\r\n\r\n";
        strDetails += "Information deemed reliable but not guaranteed.  Parties are advised to verify.";
        
        singleEmail
            .To(emailAddress)
            .BCC("mkochc21@gmail.com")
            .BCC("mvc.programmer@gmail.com")
            .Subject($"Rental Details Request: {listing.ListingId}")
            .Body(strDetails);
        
        var response = await singleEmail.SendAsync();
        
        return response.Successful 
            ? new StatusCodeResult(StatusCodes.Status202Accepted) 
            : new StatusCodeResult(StatusCodes.Status503ServiceUnavailable);
    }
    
    [Route("ContactRequest/{phoneNumber}/{listingKey}")]
    public async Task<IActionResult> ContactRequest([FromServices] IFluentEmail singleEmail, string phoneNumber, string listingKey)
    {
        var listing = await GetListing(listingKey);

        var strDetails = $"Contact request from {phoneNumber}\r\n\r\n";
        strDetails += $"https://www.c21coasttocoast.com/property/{listing.ListingId}\r\n\r\n";

        singleEmail
            .To("info.request@sandkeyhomesandcondos.com")
            .BCC("mkochc21@gmail.com")
            .BCC("mvc.programmer@gmail.com")
            .Subject($"Contact Request from Sand Key Display: {listing.ListingId}")
            .Body(strDetails);
        
        var response = await singleEmail.SendAsync();
        
        return response.Successful 
            ? new StatusCodeResult(StatusCodes.Status202Accepted) 
            : new StatusCodeResult(StatusCodes.Status503ServiceUnavailable);
    }
    
    private async Task<ListingViewModel> GetListing(string listingKey)
    {
        var stellarListing = await StellarService.GetListing(AccessToken, listingKey);
        var listingViewModel = StellarListingToListing.Convert(stellarListing);
        return listingViewModel;
    }
}