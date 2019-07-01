using System.Net;
using NUnit.Framework;
using RestSharp;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using Aubit.Vulcan.API.Models;

namespace Aubit.Vulcan.Tests
{
  public class UserTests
  {
    private RestClient client;

    [SetUp]
    public void Setup()
    {
      client = new RestClient("http://localhost:5000/api");
    }

    [Test]
    public void GetUsers()
    {
      var request = new RestRequest("users");
      var response = client.Execute(request);

      Assert.That(response.Content, Is.Not.Empty, response.Content);
    }

    [Test]
    public void PostUser()
    {
      var user = new CreateUserDto()
      {
        FirstName = "John",
        LastName = "Smith",
        Email = "john.smith@Aubit.vulcan"
      };

      var request = new RestRequest("users", Method.POST);
      request.AddJsonBody(user);
      var response = client.Execute(request);
      
      Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
    }

    [Test]
    public void PatchUser()
    {
      var id = 1;
      UserDto user;

      // get user
      var request = new RestRequest($"users/{id}");
      var response = client.Execute<UserDto>(request);

      Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Hello");
      user = response.Data;
      
      request = new RestRequest($"users/{id}", Method.PATCH);

      var patch = new JsonPatchDocument();
      patch.Replace("/firstName", "Bob");
      patch.Replace("/lastName", "Marley");
      var json = JsonConvert.SerializeObject(patch);

      request.AddHeader("Content-Type", "application/json-patch+json");
      request.AddParameter("", json, ParameterType.RequestBody);

      response = client.Execute<UserDto>(request);

      Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
      Assert.That(response.Data.FirstName, Is.EqualTo("Bob"));
      Assert.That(response.Data.LastName, Is.EqualTo("Marley"));
    }
  }
}