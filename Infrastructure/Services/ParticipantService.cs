using DefaultNamespace;
using Domain.Dtos.Participant;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ParticipantService
{
    private readonly DataContext _context;

    public ParticipantService(DataContext context)
    {
        _context = context;
    }
    public async Task<List<GetParticipant>> GetParticipants()
    {
        return await  _context.Participants.Select(c => new GetParticipant()
        {
            Id = c.Id,
            FullName = c.FullName,
            Email = c.Email,
            Phone = c.Phone,
            Password = c.Password,
            LocationId = c.LocationId,
            GroupId = c.GroupId,
            CreatedAt = c.CreatedAt

            
        }).ToListAsync();
    }
    public async Task<GetParticipant>GetParticipantById(int Id)
    {
        var find = await _context.Participants.FindAsync(Id);
        return new GetParticipant()
        {
            Id = find.Id,
            FullName = find.FullName,
            Email = find.Email,
            Phone = find.Phone,
            Password = find.Password,
            LocationId = find.LocationId,
            GroupId = find.GroupId,
            CreatedAt = find.CreatedAt
        };
    }
    public async Task< AddParticipant> AddParticipant(AddParticipant group)
    {
        await  _context.Participants.AddAsync(new Participant()
        {
            Id = group.Id,
            FullName = group.FullName,
            Email = group.Email,
            Phone = group.Phone,
            Password = group.Password,
            LocationId = group.LocationId,
            GroupId = group.GroupId,
            CreatedAt = group.CreatedAt
        });
        await _context.SaveChangesAsync();
        return group;
    }
    public async Task<AddParticipant> UpdateParticipant(AddParticipant group)
    {
        var find =await _context.Participants.FindAsync(group.Id);
        find.Id = group.Id;
        find.FullName = group.FullName;
        find.Email = group.Email;
        find.Phone = group.Phone;
        find.Password = group.Password;
        find.LocationId = group.LocationId;
        find.GroupId = group.GroupId;
        find.CreatedAt = group.CreatedAt;
        await _context.SaveChangesAsync();
        return group;
    }
    public async Task<bool> Delete (int Id)
    {
        var find = await _context.Participants.FindAsync(Id);
        if (find!=null)
        {
            _context.Participants.Remove(find);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
}