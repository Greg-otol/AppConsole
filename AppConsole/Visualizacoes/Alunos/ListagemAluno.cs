using AppConsole.Servicos.Alunos;

namespace AppConsole.Visualizacoes.Alunos
{
    public class ListagemAluno
    {
        private ConsoleColor _branco = ConsoleColor.White;
        private ConsoleColor _azul = ConsoleColor.Blue;

        private readonly AlunoServico _alunoServico;

        public ListagemAluno(AlunoServico alunoServico)
        {
            _alunoServico = alunoServico;
        }
        public void ListarAlunos()
        {
            Console.ForegroundColor = _branco;

            Console.Clear();
            Console.WriteLine("********* Alunos cadastrados *********");
            Console.WriteLine();

            var alunos = _alunoServico.Listar();
            if (alunos.Count > 0 && alunos != null)
            {
                Console.WriteLine("Código     Aluno");
                foreach (var aluno in alunos)
                {
                    Console.ForegroundColor = _azul;
                    Console.WriteLine($"{aluno.Id}          {aluno.Nome}");
                }

                Console.WriteLine();
                Console.ForegroundColor = _branco;
                Console.WriteLine("======================================");
            }
            else
            {
                Console.ForegroundColor = _azul;
                Console.WriteLine("Nenhum registro encontrado.");
                Console.WriteLine();
            }

            Console.ForegroundColor = _branco;
            Console.WriteLine("Pressione Enter para voltar ao Menu...");
            Console.ReadLine();
        }
    }
}
