using filme.Entity;

namespace filme.Service
{
    public interface IFilmeService 
    {
        public List<Filme> listarFilmes();
        Filme encontrarFilme(int id);
        void salvarFilme(Filme filme);
        Filme atualizarFilme(Filme filme, int id);
    }
}