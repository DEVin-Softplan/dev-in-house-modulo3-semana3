using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using filme.Controllers;
using filme.Entity;
using filme.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Filme.Api.Test
{
    public class FilmeControllerUnitTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {
            FilmeEntity filme = new FilmeEntity();
            filme.Id=0;
            filme.Diretor ="A";
            filme.Titulo ="A";
            List<FilmeEntity> filmes = new List<FilmeEntity>();
            filmes.Add(filme);

            var repositoryMock = new Mock<IFilmeRepository>();
            repositoryMock
                .Setup(r=> r.listarFilmes())
                .Returns(filmes);

            FilmeController controller = new FilmeController(repositoryMock.Object);

            var result = controller.retornaFilmes();

            repositoryMock.Verify(r=>r.listarFilmes());
            Assert.AreEqual(filmes, result);
        }
    }
}