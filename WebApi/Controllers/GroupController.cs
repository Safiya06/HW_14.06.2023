using DefaultNamespace;
using Domain.Dtos.Group;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class GroupController
{
    private readonly GroupService _groupService;

    public GroupController(GroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpGet("getgroups")]
    public async Task<List<GetGroup>> GetGroups()
    {
        return await  _groupService.GetGroups();
    }

    [HttpGet("GetGroupById")]
    public async Task<GetGroup> GetGroupById(int Id)
    {
        return await _groupService.GetGroupById(Id);
    }

    [HttpPost("AddGroup")]
    public async Task<AddGroup> AddGroup(AddGroup addgroup)
    {
        return await _groupService.AddGroup(addgroup);
    }
    [HttpPut("UpdateGroup")]
    public async Task<AddGroup> UpdateGroup(AddGroup addgroup)
    {
        return await _groupService.UpdateGroup(addgroup);
    }
    
    [HttpDelete("DeleteGroup")]
    public async Task<bool> DeleteGroup(int Id)
    {
        return await _groupService.Delete(Id);
    }
}