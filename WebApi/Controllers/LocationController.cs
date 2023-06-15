using DefaultNamespace;
using Domain.Dtos.Location;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class LocationController
{
    private readonly LocationService _locationService;

    public LocationController(LocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet("getlocations")]
    public async Task<List<GetLocation>> GetLocations()
    {
        return await  _locationService.GetLocations();
    }

    [HttpGet("GetLocationById")]
    public async Task<GetLocation> GetLocationById(int Id)
    {
        return await _locationService.GetLocationById(Id);
    }

    [HttpPost("AddLocation")]
    public async Task<AddLocation> AddLocation(AddLocation addlocation)
    {
        return await _locationService.AddLocation(addlocation);
    }
    [HttpPut("UpdateLocation")]
    public async Task<AddLocation> UpdateLocation(AddLocation addlocation)
    {
        return await _locationService.UpdateLocation(addlocation);
    }
    
    [HttpDelete("DeleteLocation")]
    public async Task<bool> DeleteLocation(int Id)
    {
        return await _locationService.Delete(Id);
    }
}