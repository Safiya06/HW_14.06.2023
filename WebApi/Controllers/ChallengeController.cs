using DefaultNamespace;
using Domain.Dtos.Challenge;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class ChallengeController: ControllerBase
{
    private readonly ChallengeService _challengeService;

    public ChallengeController(ChallengeService challengeService)
    {
        _challengeService = challengeService;
    }

    [HttpGet("getchallenges")]
    public async Task<List<GetChallenge>> GetChallenges()
    {
        return await  _challengeService.GetChallenges();
    }

    [HttpGet("GetChallengeById")]
    public async Task<GetChallenge> GetChallengeById(int Id)
    {
        return await _challengeService.GetChallengeById(Id);
    }

    [HttpPost("AddChallenge")]
    public async Task<AddChallenge> AddChallenge(AddChallenge addchallenge)
    {
        return await _challengeService.AddChallenge(addchallenge);
    }
    [HttpPut("UpdateChallenge")]
    public async Task<AddChallenge> UpdateChallenge(AddChallenge addchallenge)
    {
        return await _challengeService.UpdateChallenge(addchallenge);
    }
    
    [HttpDelete("DeleteChallenge")]
    public async Task<bool> DeleteChallenge(int Id)
    {
        return await _challengeService.Delete(Id);
    }   
}