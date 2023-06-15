using DefaultNamespace;
using Domain.Dtos.Participant;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class ParticipantController
{
    private readonly ParticipantService _participantService;

    public ParticipantController(ParticipantService participantService)
    {
        _participantService = participantService;
    }

    [HttpGet("getparticipants")]
    public async Task<List<GetParticipant>> GetParticipants()
    {
        return await  _participantService.GetParticipants();
    }

    [HttpGet("GetParticipantById")]
    public async Task<GetParticipant> GetParticipantById(int Id)
    {
        return await _participantService.GetParticipantById(Id);
    }

    [HttpPost("AddParticipant")]
    public async Task<AddParticipant> AddParticipant(AddParticipant addparticipant)
    {
        return await _participantService.AddParticipant(addparticipant);
    }
    [HttpPut("UpdateParticipant")]
    public async Task<AddParticipant> UpdateParticipant(AddParticipant addparticipant)
    {
        return await _participantService.UpdateParticipant(addparticipant);
    }
    
    [HttpDelete("DeleteParticipant")]
    public async Task<bool> DeleteParticipant(int Id)
    {
        return await _participantService.Delete(Id);
    }
    
}