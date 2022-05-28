using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
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
        //given
        var jsonFilme = "{\"Titulo\" : \" Home land\",\"Diretor\" : \" Zack Snyder \"}";
        using var jsonContent = new StringContent(jsonFilme, Encoding.UTF8, "application/json");
        // jsonContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

        await using var factory = new FilmeApiFactory();
        var client = factory.CreateClient();
        //when
        var response = await client.PostAsync("/filme",jsonContent);

    
        //then
        Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        // Assert.AreEqual("[]", await response.Content.ReadAsStringAsync());
    }

    [Test]
    public async Task atualizaFilmeTest()
    {
        //given
        FilmeEntity filme = new FilmeEntity();
        filme.Id=0;
        filme.Diretor ="AAA";
        filme.Titulo ="BBBB";

        var jsonFilme = "{\"Titulo\" : \" Home land\",\"Diretor\" : \" Zack Snyder \"}";
        var jsonFilme2 = "{\"Titulo\" : \"AAA\",\"Diretor\" : \"BBBB\"}";
        using var jsonContent = new StringContent(jsonFilme, Encoding.UTF8, "application/json");
        using var jsonContent2 = new StringContent(jsonFilme2, Encoding.UTF8, "application/json");
        jsonContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

        await using var factory = new FilmeApiFactory();
        var client = factory.CreateClient();
        //when
        var responsePost = await client.PostAsync("/filme",jsonContent);

        Thread.Sleep(20);
        

        var responsePut = await client.PutAsync("/filme/0",jsonContent2);

        Thread.Sleep(20);

        //then
        Assert.AreEqual(HttpStatusCode.NoContent, responsePut.StatusCode);
        // Assert.AreEqual(filme, await responsePut.Content.ReadAsStringAsync());
    }

    [Test]
    public async Task deletaFilmeTest()
    {
        //given
        var jsonFilme = "{\"Titulo\" : \" Home land\",\"Diretor\" : \" Zack Snyder \"}";
        using var jsonContent = new StringContent(jsonFilme, Encoding.UTF8, "application/json");
        // jsonContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

        await using var factory = new FilmeApiFactory();
        var client = factory.CreateClient();
        //when
        var response = await client.DeleteAsync("/filme/0");

    
        //then
        Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
        // Assert.AreEqual("[]", await response.Content.ReadAsStringAsync());
    }

    // [Test]
    // public async Task adicionaFilmeTest()
    // {
    //     //given
    //     var jsonFilme = "{\"Titulo\" : \" Home land\",\"Diretor\" : \" Zack Snyder \"}";
    //     using var jsonContent = new StringContent(jsonFilme, Encoding.UTF8, "application/json");
    //     // jsonContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

    //     await using var factory = new FilmeApiFactory();
    //     var client = factory.CreateClient();
    //     //when
    //     var response = await client.PostAsync("/filme",jsonContent);

    
    //     //then
    //     Assert.AreEqual(HttpStatusCode.NoContent, response.StatusCode);
    //     // Assert.AreEqual("[]", await response.Content.ReadAsStringAsync());
    // }
}