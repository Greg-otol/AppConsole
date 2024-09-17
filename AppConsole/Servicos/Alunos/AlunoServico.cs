using AppConsole.Servicos.Alunos.Modelos;
using AppConsole.Servicos.Alunos.Modelos.Comandos;
using AppConsole.Servicos.Alunos.Repositorios;

namespace AppConsole.Servicos.Alunos
{
    public class AlunoServico
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoServico(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public string Criar(AlunoComando comando)
        {
            try
            {
                if (string.IsNullOrEmpty(comando.Nome))
                    return "Digite o nome do aluno!";

                var novoAluno = new Aluno(comando.Nome);

                _alunoRepositorio.Criar(novoAluno);

                return "Aluno cadastrado com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Não foi possível cadastrar o Aluno. Motivo: {ex.Message}";
            }
        }

        public List<Aluno> Listar()
        {
            var alunos = _alunoRepositorio.Listar();

            return alunos;
        }
    }
}
