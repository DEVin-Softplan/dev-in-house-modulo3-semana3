using filme.Entity;

namespace filme.Service
{
    public interface IFilmeRepository 
    {
        public List<FilmeEntity> listarFilmes();
        FilmeEntity encontrarFilme(int id);
        void salvarFilme(FilmeEntity filme);
        FilmeEntity atualizarFilme(FilmeEntity filme, int id);
    }
}