using filme.Entity;

namespace filme.Repository
{
    public interface IFilmeRepository 
    {
        public List<FilmeEntity> listarFilmes();
        FilmeEntity encontrarFilme(int id);
        void salvarFilme(FilmeEntity filme);
        FilmeEntity atualizarFilme(FilmeEntity filme, int id);
        FilmeEntity deletarFilme(int id);
        FilmeEntity altualizarTituloFilme(string titulo, int id);
    }
}