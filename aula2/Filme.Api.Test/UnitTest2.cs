using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using filme.Service;
using NUnit.Framework;
using filme.Entity;
using System.Collections.Generic;
using System.Linq;
using filme.Helper;
using Moq;
// using Microsoft.EntityFrameworkCore;

namespace Filme.Api.Test;

public class Tests2
{    

    // private FilmeApiFactory factory;
    // private HttpClient _client;
        
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void Test1()
    {
        
        //given 
        var data = new List<FilmeEntity>
            {
                new FilmeEntity {Titulo = "BBB" },
                new FilmeEntity {Titulo = "ZZZ" },
                new FilmeEntity {Titulo = "AAA" },
            }.AsQueryable();

        var mockSet = new Mock<Microsoft.EntityFrameworkCore.DbSet<FilmeEntity>>();
        mockSet.As<IQueryable<FilmeEntity>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<FilmeEntity>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<FilmeEntity>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<FilmeEntity>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

        var mockContext = new Mock<FilmeContext>();
        mockContext.Setup(c => c.Filmes.ToList()).Returns(data.ToList);


        var service = new FilmeRepository(mockContext.Object);
        //when
        var response = service.listarFilmes();
    
        //then
        // Assert.AreEqual("[]", await response.Content.ReadAsStringAsync());

        Assert.AreEqual(3, response.Count);
    }
}