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
        public void RetornaFilmesTest()
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

        [Test]
        public void RetornaFilmeTest()
        {
            FilmeEntity filme = new FilmeEntity();
            filme.Id=0;
            filme.Diretor ="A";
            filme.Titulo ="A";

            var repositoryMock = new Mock<IFilmeRepository>();
            repositoryMock
                .Setup(r=> r.encontrarFilme(0))
                .Returns(filme);

            FilmeController controller = new FilmeController(repositoryMock.Object);

            var result = controller.procuraFilme(0);

            repositoryMock.Verify(r=> r.encontrarFilme(0));
            Assert.AreEqual(filme, result);
        }

        [Test]
        public void AdicionaFilmeTest()
        {
            //given / dado
            FilmeEntity filme = new FilmeEntity();
            filme.Id=0;
            filme.Diretor ="A";
            filme.Titulo ="A";
            
            var repositoryMock = new Mock<IFilmeRepository>();
            repositoryMock
                .Setup(r=> r.salvarFilme(filme));

            FilmeController controller = new FilmeController(repositoryMock.Object);

            Assert.DoesNotThrow(()=>controller.adicionaFilme(filme));
            repositoryMock.Verify(r=>r.salvarFilme(filme));
        }

        [Test]
        public void AlteraFilmeTest()
        {
            //given / dado
            FilmeEntity filme = new FilmeEntity();
            filme.Id=0;
            filme.Diretor ="A";
            filme.Titulo ="A";
            
            var repositoryMock = new Mock<IFilmeRepository>();
            repositoryMock
                .Setup(r=> r.atualizarFilme(filme, 0))
                .Returns(filme);

            FilmeController controller = new FilmeController(repositoryMock.Object);
            
            //when / quando
            IActionResult result = controller.atualizaFilme(filme, 0);
            var okResult = result as OkObjectResult;

            //then / então
            repositoryMock.Verify(r=>r.atualizarFilme(filme, 0));
            Assert.AreEqual(filme, okResult.Value);
        }

        [Test]
        public void DeletaFilmeTest()
        {
            //given / dado
            FilmeEntity filme = new FilmeEntity();
            filme.Id=0;
            filme.Diretor ="A";
            filme.Titulo ="A";
        
            var repositoryMock = new Mock<IFilmeRepository>();
            repositoryMock
                .Setup(r=> r.deletarFilme(0))
                .Returns(filme);

            FilmeController controller = new FilmeController(repositoryMock.Object);
            
            //when / quando
            var result = controller.deletaFilme(0);

            //then / então
            repositoryMock.Verify(r=>r.deletarFilme(0));
            Assert.AreEqual(filme, result);
        }
    

        [Test]
        public void AtualizaTituloFilmeTest()
        {
            //given / dado
            FilmeEntity filme = new FilmeEntity();
            filme.Id=0;
            filme.Diretor ="A";
            filme.Titulo ="B";
            
            var repositoryMock = new Mock<IFilmeRepository>();
            repositoryMock
                .Setup(r=> r.altualizarTituloFilme("B", 0))
                .Returns(filme);

            FilmeController controller = new FilmeController(repositoryMock.Object);
            
            //when / quando
            IActionResult result = controller.atualizaTituloFilme("B",0);
            var okResult = result as OkObjectResult;

            //then / então
            repositoryMock.Verify(r=>r.altualizarTituloFilme("B", 0));
            Assert.AreEqual(filme, okResult.Value);
        }
    }
}