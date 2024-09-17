using AppConsole.Infra.Disciplinas.Dados;
using AppConsole.Servicos.Alunos;
using AppConsole.Servicos.Disciplinas;
using AppConsole.Servicos.Disciplinas.Modelos.Comandos;
using AppConsole.Visualizacoes.Menus;

namespace AppConsole.Visualizacoes.Disciplinas
{
    public class CadastroDisciplina
    {
        private readonly Menu _menu;

        private ConsoleColor _branco = ConsoleColor.White;
        private ConsoleColor _azul = ConsoleColor.Blue;

        private readonly DisciplinaServico _disciplinaServico;
        private readonly AlunoServico _alunoServico;

        public CadastroDisciplina(AlunoServico alunoServico, DisciplinaServico disciplinaServico, Menu menu)
        {
            _alunoServico = alunoServico;
            _disciplinaServico = disciplinaServico;
            _menu = menu;
        }

        public void AdicionarDisciplina()
        {
            Console.ForegroundColor = _branco;

            bool alunoInvalido = true;
            bool disciplinaInvalido = true;

            _menu.MenuAluno();

            Console.Write("Digite o código do aluno: ");
            string inputIdAluno = Console.ReadLine();

            var alunos = _alunoServico.Listar();
            if (!Utilitarios.Utilitarios.ValidarAluno(alunos, inputIdAluno))
            {
                while (alunoInvalido)
                {
                    Console.Clear();

                    if (!Utilitarios.Utilitarios.ValidarAluno(alunos, inputIdAluno))
                    {
                        _menu.MenuAluno();

                        Console.ForegroundColor = _azul;
                        Console.WriteLine("Código inválido!");
                        Console.WriteLine();
                        Console.ForegroundColor = _branco;
                        Console.Write("Digite novamente o código do Aluno: ");
                        inputIdAluno = Console.ReadLine();
                    }
                    else
                    {
                        alunoInvalido = false;
                    }
                }
            }

            int.TryParse(inputIdAluno, out int idAluno);

            _menu.MenuDisciplina();

            Console.Write("Digite o código da Disciplina: ");
            string inputIdDisciplina = Console.ReadLine();

            if (!Utilitarios.Utilitarios.ValidarDisciplina(inputIdDisciplina))
            {
                while (disciplinaInvalido)
                {
                    Console.Clear();

                    if (!Utilitarios.Utilitarios.ValidarDisciplina(inputIdDisciplina))
                    {
                        _menu.MenuDisciplina();

                        Console.ForegroundColor = _azul;
                        Console.WriteLine("Código inválido!");
                        Console.WriteLine();
                        Console.ForegroundColor = _branco;
                        Console.Write("Digite novamente o código da Disciplina: ");
                        inputIdDisciplina = Console.ReadLine();
                    }
                    else
                    {
                        disciplinaInvalido = false;
                    }
                }
            }

            int.TryParse(inputIdDisciplina, out int idDisciplina);
            var nomeDisciplina = TabelaDisciplina.Disciplinas().Find(d => d.Id == idDisciplina);

            var comando = new DisciplinaComando(idAluno, nomeDisciplina.Nome);
            var resultado = _disciplinaServico.Criar(comando);

            Console.Clear();
            Console.ForegroundColor = _azul;
            Console.WriteLine($"{resultado}");
            Console.WriteLine();
            Console.ForegroundColor = _branco;
            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadLine();
        }
    }
}
