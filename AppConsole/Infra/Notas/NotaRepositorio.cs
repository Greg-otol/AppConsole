using AppConsole.Infra.Dados;
using AppConsole.Servicos.Notas.Modelos;
using AppConsole.Servicos.Notas.Repositorios;

namespace AppConsole.Infra.Notas
{
    public class NotaRepositorio : INotaRepositorio
    {
        public void Criar(Nota nota)
        {
            BancoDados.TabelaNota(nota);
        }

        public List<Nota> Listar()
        {
            return BancoDados.TabelaNota().ToList();
        }
    }
}
