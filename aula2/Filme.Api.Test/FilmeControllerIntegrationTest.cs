using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using filme.Entity;
using NUnit.Framework;

namespace Filme.Api.Test;

public class FilmeControllerIntegrationTest
{    

    // private FilmeApiFactory factory;
    // private HttpClient _client;
        
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public async Task retornaFilmesTest()
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

    [Test]
    public async Task adicionaFilmeTest()
    {
        // //given
        // var jsonFilme = "{\" Titulo \" : \" Home land\",\" Diretor \" : \" Zack Snyder \"}";
        // using var jsonContent = new StringContent(jsonFilme);
        // jsonContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

        // await using var factory = new FilmeApiFactory();
        // var client = factory.CreateClient();
        // //when
        // var response = await client.PostAsync("/filme",jsonContent);

    
        // //then
        // Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        // // Assert.AreEqual("[]", await response.Content.ReadAsStringAsync());
    }

}