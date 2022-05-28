using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using filme.Entity;
using filme.Repository;

namespace filme.Controllers
{
    [ApiController]
    [Route("filme")]
    public class FilmeController : Controller
    {
        private readonly ILogger<FilmeController> _logger;
        private IFilmeRepository _service;

        public FilmeController( IFilmeRepository service)
        {
            // _logger = logger;
            _service = service;
        }

        [HttpGet]
        public List<FilmeEntity> retornaFilmes(){
            List<FilmeEntity> filmes = _service.listarFilmes();
            return filmes;
        }

    // /filme/{id} => /filme/1
        [HttpGet("{id}")]
        public FilmeEntity procuraFilme([FromRoute] int id){
            FilmeEntity filmes = _service.encontrarFilme(id);
            return filmes;
        }

        [HttpPost]
        public IActionResult adicionaFilme([FromBody]FilmeEntity filme){
            _service.salvarFilme(filme);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult atualizaFilme(
            [FromBody]FilmeEntity filme, 
            [FromRoute]int id
        ){
            var response = _service.atualizarFilme(filme, id);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public FilmeEntity deletaFilme( 
            [FromRoute]int id
        ){
            var response = _service.deletarFilme(id);
            return response;
        }

        [HttpPatch("{id}")]
        public IActionResult atualizaTituloFilme(
            [FromBody]String titulo, 
            [FromRoute]int id
        ){
            var response = _service.altualizarTituloFilme(titulo, id);
            return Ok(response);
        }
    }
}