using DefaultNamespace;
using Domain.Dtos.Challenge;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ChallengeService
{
    private readonly DataContext _context;

    public ChallengeService(DataContext context)
    {
        _context = context;
    }
    public async Task<List<GetChallenge>> GetChallenges()
    {
      return await  _context.Challenges.Select(c => new GetChallenge()
        {
            Id = c.Id,
            Description = c.Description,
            Title = c.Title
                

        }).ToListAsync();
    }
    public async Task<GetChallenge>GetChallengeById(int Id)
    {
        var find = await _context.Challenges.FindAsync(Id);
        return new GetChallenge()
        {
            Id = find.Id,
            Title = find.Title,
            Description = find.Description
        };
    }
    public async Task< AddChallenge> AddChallenge(AddChallenge challenge)
    {
        await  _context.Challenges.AddAsync(new Challenge()
        {
            Id = challenge.Id,
            Title = challenge.Title,
            Description = challenge.Description
        });
       await _context.SaveChangesAsync();
        return challenge;
    }
    public async Task<AddChallenge> UpdateChallenge(AddChallenge challenge)
    {
        var find =await _context.Challenges.FindAsync(challenge.Id);
        find.Title = challenge.Title;
        find.Description = challenge.Description;
        await _context.SaveChangesAsync();
        return challenge;

    }
    public async Task<bool> Delete (int Id)
    {
        var find = await _context.Challenges.FindAsync(Id);
        if (find!=null)
        {
            _context.Challenges.Remove(find);
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }
}