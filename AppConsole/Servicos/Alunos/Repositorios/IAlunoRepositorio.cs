using AppConsole.Servicos.Alunos.Modelos;

namespace AppConsole.Servicos.Alunos.Repositorios
{
    public interface IAlunoRepositorio
    {
        void Criar(Aluno aluno);
        List<Aluno> Listar();
    }
}
