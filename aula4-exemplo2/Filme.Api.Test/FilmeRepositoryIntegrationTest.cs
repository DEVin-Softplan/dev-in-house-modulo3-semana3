using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using filme.Controllers;
using filme.Entity;
using filme.Helper;
using filme.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Filme.Api.Test
{
    public class FilmeRepositoryIntegrationTest
    {

        private readonly DbConnection _connection;
        private readonly DbContextOptions<FilmeContext> _contextOptions;

        #region ConstructorAndDispose
        public FilmeRepositoryIntegrationTest()
        {
            // Create and open a connection. This creates the SQLite in-memory database, which will persist until the connection is closed
            // at the end of the test (see Dispose below).
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            // These options will be used by the context instances in this test suite, including the connection opened above.
            _contextOptions = new DbContextOptionsBuilder<FilmeContext>()
                .UseSqlite(_connection)
                .Options;

            // Create the schema and seed some data
            using var context = new FilmeContext(_contextOptions);

            if (context.Database.EnsureCreated())
            {
                using var viewCommand = context.Database.GetDbConnection().CreateCommand();
            }

            context.AddRange(
                new FilmeEntity { Diretor = "Blog1", Titulo = "http://blog1.com" },
                new FilmeEntity { Diretor = "Blog2", Titulo = "http://blog2.com" });
            context.SaveChanges();
        }

         FilmeContext CreateContext() => new FilmeContext(_contextOptions);

        public void Dispose() => _connection.Dispose();
        #endregion

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void RetornaFilmesTest()
        {
            List<FilmeEntity> filmes = new List<FilmeEntity>();
            filmes.Add( new FilmeEntity { Id=0, Diretor = "Blog1", Titulo = "http://blog1.com" });
            filmes.Add(new FilmeEntity { Id=1, Diretor = "Blog2", Titulo = "http://blog2.com" });
            using var context = CreateContext();
            var controller = new FilmeRepository(context);

            var filmesResponse = controller.listarFilmes();

            
            Assert.AreEqual(filmes[0].Diretor, filmesResponse[0].Diretor);
        }
    }
}