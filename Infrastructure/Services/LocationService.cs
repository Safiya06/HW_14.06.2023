using DefaultNamespace;
using Domain.Dtos.Location;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class LocationService
{
    private readonly DataContext _context;

    public LocationService(DataContext context)
    {
        _context = context;
    }
    public async Task<List<GetLocation>> GetLocations()
    {
        return await  _context.Locations.Select(c => new GetLocation()
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description
            
        }).ToListAsync();
    }
    public async Task<GetLocation>GetLocationById(int Id)
    {
        var find = await _context.Locations.FindAsync(Id);
        return new GetLocation()
        {
            Id = find.Id,
            Name = find.Name,
            Description = find.Description
        };
    }
    public async Task< AddLocation> AddLocation(AddLocation group)
    {
        await  _context.Locations.AddAsync(new Location()
        {
            Id = group.Id,
            Name = group.Name,
            Description = group.Description
        });
        await _context.SaveChangesAsync();
        return group;
    }
    public async Task<AddLocation> UpdateLocation(AddLocation group)
    {
        var find =await _context.Locations.FindAsync(group.Id);
        find.Id = group.Id;
       find.Name = group.Name;
        find.Description = group.Description;
        await _context.SaveChangesAsync();
        return group;
    }
    public async Task<bool> Delete (int Id)
    {
        var find = await _context.Locations.FindAsync(Id);
        if (find!=null)
        {
            _context.Locations.Remove(find);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
}