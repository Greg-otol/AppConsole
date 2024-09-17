using AppConsole.Servicos.Disciplinas.Modelos;

namespace AppConsole.Servicos.Disciplinas.Repositorios
{
    public interface IDisciplinaRepositorio
    {
        void Criar(Disciplina disciplina);
        List<Disciplina> Listar();
    }
}
