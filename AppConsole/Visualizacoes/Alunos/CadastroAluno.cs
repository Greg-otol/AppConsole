using AppConsole.Servicos.Alunos;
using AppConsole.Servicos.Alunos.Modelos.Comandos;

namespace AppConsole.Visualizacoes.Alunos
{
    public class CadastroAluno
    {
        private ConsoleColor _branco = ConsoleColor.White;
        private ConsoleColor _azul = ConsoleColor.Blue;

        private readonly AlunoServico _alunoServico;

        public CadastroAluno(AlunoServico alunoServico)
        {
            _alunoServico = alunoServico;
        }

        public void AdicionarAluno()
        {
            Console.ForegroundColor = _branco;
            Console.WriteLine("**** Cadastrar novo aluno ****");
            Console.WriteLine();
            Console.Write("Digite o nome do aluno: ");
            string nome = Console.ReadLine();

            var comando = new AlunoComando(nome);

            var resultado = _alunoServico.Criar(comando);

            Console.Clear();
            Console.ForegroundColor = _azul;
            Console.WriteLine();
            Console.WriteLine($"{resultado}");

            Console.ForegroundColor = _branco;
            Console.WriteLine();
            Console.WriteLine("Pressione Enter para continuar...");

            Console.ReadLine();
        }
    }
}
