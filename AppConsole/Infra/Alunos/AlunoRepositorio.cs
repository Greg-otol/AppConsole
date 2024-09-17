using AppConsole.Infra.Dados;
using AppConsole.Servicos.Alunos.Modelos;
using AppConsole.Servicos.Alunos.Repositorios;

namespace AppConsole.Infra.Alunos
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        public void Criar(Aluno aluno)
        {
            BancoDados.TabelaAluno(aluno);
        }

        public List<Aluno> Listar()
        {
            return BancoDados.TabelaAluno().ToList();
        }
    }
}
