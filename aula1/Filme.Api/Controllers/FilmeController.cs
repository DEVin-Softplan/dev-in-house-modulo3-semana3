using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using filme.Entity;
using filme.Service;

namespace filme.Controllers
{
    [ApiController]
    [Route("filme")]
    public class FilmeController : Controller
    {
        private readonly ILogger<FilmeController> _logger;
        private IFilmeService _service;

        public FilmeController(ILogger<FilmeController> logger, IFilmeService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IActionResult retornaFilmes(){
            List<Filme> filmes = _service.listarFilmes();
            return Ok(filmes);
        }

    // /filme/{id} => /filme/1
        [HttpGet("{id}")]
        public IActionResult procuraFilme([FromRoute] int id){
            Filme filmes = _service.encontrarFilme(id);
            return Ok(filmes);
        }

        [HttpPost]
        public IActionResult adicionaFilme([FromBody]Filme filme){
            _service.salvarFilme(filme);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult atualizaFilme(
            [FromBody]Filme filme, 
            [FromRoute]int id
        ){
            var response = _service.atualizarFilme(filme, id);
            if (response==null){
                return NotFound();
            }
            return Ok(response);
        }
    }
}