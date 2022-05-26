using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using filme.Entity;
using filme.Helper;

namespace filme.Repository
{
    public class FilmeRepository : IFilmeRepository
    {
        private FilmeContext _context;

        public FilmeRepository(FilmeContext context)
        {
            _context = context;
        }

        public List<FilmeEntity> listarFilmes(){
            return _context.Filmes.ToList();
        }

        public FilmeEntity encontrarFilme(int id){
            return _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        }

        public void salvarFilme(FilmeEntity filme)
        {
            // id += 1;
            // filme.Id = id;
            _context.Filmes.Add(filme);
            _context.SaveChanges();
        }

        public FilmeEntity atualizarFilme(FilmeEntity filme, int id)
        {
            var filmeEncontrado = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filmeEncontrado == null){
                return null;
            }

            filmeEncontrado.Diretor = filme.Diretor;
            filmeEncontrado.Titulo = filme.Titulo;

            _context.SaveChanges();
            return filmeEncontrado;
        }

        public FilmeEntity deletarFilme(int id)
        {
            var filmeEncontrado = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filmeEncontrado == null){
                return null;
            }
            _context.Remove(filmeEncontrado);
            _context.SaveChanges();
            return filmeEncontrado;
        }

        public FilmeEntity altualizarTituloFilme(string titulo, int id)
        {
             var filmeEncontrado = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filmeEncontrado == null){
                return null;
            }

            filmeEncontrado.Titulo = titulo;

            _context.SaveChanges();
            return filmeEncontrado;
        }
    }
}