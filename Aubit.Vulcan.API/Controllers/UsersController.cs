using System;
using System.Collections.Generic;
using System.Linq;
using Aubit.Vulcan.API.Repository;
using Aubit.Vulcan.API.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Aubit.Vulcan.API.Models;
using AutoMapper;

namespace Aubit.Vulcan.API.Controllers
{
  [Route("api/[controller]")]
  public class UsersController : Controller
  {
    private readonly IMapper mapper;
    private readonly VulcanContext context;

    public UsersController(IMapper mapper, VulcanContext context)
    {
      this.mapper = mapper;
      this.context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
      return Ok(context.Users.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      var user = context.Users.FirstOrDefault(u => u.Id == id);

      if(user == null)
      {
        return NotFound();
      }

      return Ok(user);
    }

    [HttpPost]
    public IActionResult Post([FromBody]JObject value)
    {
      var user = value.ToObject<User>();
      var u = context.Users.Add(user);
      context.SaveChanges();

      return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }

    [HttpPatch("{id}")]
    public IActionResult Patch([FromBody]JsonPatchDocument<UserDto> patch, int id)
    {
      var user = context.Users.FirstOrDefault(u => u.Id == id);

      if(user == null)
      {
        return NotFound();
      }

      var userDto = mapper.Map<UserDto>(user);

      patch.ApplyTo(userDto);
      mapper.Map(userDto, user);
      context.Users.Update(user);
      context.SaveChanges();

      return Ok(user);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var user = context.Users.FirstOrDefault(u => u.Id == id);

      if(user == null)
      {
        return NotFound();
      }

      context.Users.Remove(user);
      context.SaveChanges();

      return NoContent();
    }
  }
}