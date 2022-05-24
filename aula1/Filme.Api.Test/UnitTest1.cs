using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Filme.Api.Test;

public class Tests
{    

    // private FilmeApiFactory factory;
    // private HttpClient _client;
        
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public async Task Test1()
    {
        //given
        await using var factory = new FilmeApiFactory();
        var client = factory.CreateClient();
        //when
        var response = await client.GetAsync("/filme");
    
        //then
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        Assert.AreEqual("[]", await response.Content.ReadAsStringAsync());
    }
}