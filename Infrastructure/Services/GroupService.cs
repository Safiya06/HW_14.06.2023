using DefaultNamespace;
using Domain.Dtos.Group;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class GroupService
{
    
    private readonly DataContext _context;

    public GroupService(DataContext context)
    {
        _context = context;
    }
    public async Task<List<GetGroup>> GetGroups()
    {
        return await  _context.Groups.Select(c => new GetGroup()
        {
            Id = c.Id,
            GroupNick = c.GroupNick,
            ChallengeId = c.ChallengeId,
            MinimumNumberOfMembers = c.MinimumNumberOfMembers,
            TeamSlogan = c.TeamSlogan,
            CreatedAt = c.CreatedAt
            
        }).ToListAsync();
    }
    public async Task<GetGroup>GetGroupById(int Id)
    {
        var find = await _context.Groups.FindAsync(Id);
        return new GetGroup()
        {
            Id = find.Id,
            GroupNick = find.GroupNick,
            ChallengeId = find.ChallengeId,
            MinimumNumberOfMembers = find.MinimumNumberOfMembers,
            TeamSlogan = find.TeamSlogan,
            CreatedAt = find.CreatedAt
        };
    }
    public async Task< AddGroup> AddGroup(AddGroup group)
    {
        await  _context.Groups.AddAsync(new Group()
        {
            Id = group.Id,
            GroupNick = group.GroupNick,
            ChallengeId = group.ChallengeId,
            MinimumNumberOfMembers = group.MinimumNumberOfMembers,
            TeamSlogan = group.TeamSlogan,
            CreatedAt = group.CreatedAt
        });
        await _context.SaveChangesAsync();
        return group;
    }
    public async Task<AddGroup> UpdateGroup(AddGroup group)
    {
        var find =await _context.Groups.FindAsync(group.Id);
        find.Id = group.Id;
       find.GroupNick = group.GroupNick;
        find.ChallengeId = group.ChallengeId;
        find.MinimumNumberOfMembers = group.MinimumNumberOfMembers;
        find.TeamSlogan = group.TeamSlogan;
        find.CreatedAt = group.CreatedAt;
        await _context.SaveChangesAsync();
        return group;

    }
    public async Task<bool> Delete (int Id)
    {
        var find = await _context.Groups.FindAsync(Id);
        if (find!=null)
        {
            _context.Groups.Remove(find);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
}