using AppConsole.Servicos.Notas.Modelos;

namespace AppConsole.Servicos.Notas.Repositorios
{
    public interface INotaRepositorio
    {
        void Criar(Nota nota);
        List<Nota> Listar();
    }
}
