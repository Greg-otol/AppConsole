using AppConsole.Servicos.Alunos;
using AppConsole.Servicos.Disciplinas;
using AppConsole.Servicos.Notas;
using AppConsole.Servicos.Notas.Modelos.Comandos;
using AppConsole.Visualizacoes.Menus;

namespace AppConsole.Visualizacoes.Notas
{
    public class CadastroNota
    {
        private ConsoleColor _branco = ConsoleColor.White;
        private ConsoleColor _azul = ConsoleColor.Blue;

        private readonly Menu _menu;

        private readonly NotaServico _notaServico;
        private readonly AlunoServico _alunoServico;
        private readonly DisciplinaServico _disciplinaServico;

        public CadastroNota(NotaServico notaServico, Menu menu, AlunoServico alunoServico, DisciplinaServico disciplinaServico)
        {
            _notaServico = notaServico;
            _menu = menu;
            _alunoServico = alunoServico;
            _disciplinaServico = disciplinaServico;
        }

        public void AdicionarNota()
        {
            Console.ForegroundColor = _branco;

            bool alunoInvalido = true;
            bool disciplinaInvalido = true;
            bool notaInvalida = true;

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

            _menu.MenuNotaDisciplina(idAluno);

            Console.Write("Digite o código da Disciplina: ");
            string inputIdDisciplina = Console.ReadLine();

            var disciplinas = _disciplinaServico.Listar();
            if (!Utilitarios.Utilitarios.ValidarDisciplinaNota(disciplinas, inputIdAluno, inputIdDisciplina))
            {
                while (disciplinaInvalido)
                {
                    Console.Clear();

                    if (!Utilitarios.Utilitarios.ValidarDisciplinaNota(disciplinas, inputIdAluno, inputIdDisciplina))
                    {
                        _menu.MenuNotaDisciplina(idAluno);

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

            Console.Clear();

            for (var i = 1; i < 5; i++)
            {
                Console.ForegroundColor = _branco;
                Console.Write($"Digite a {i}ª nota: ");
                string inputNota = Console.ReadLine();

                if (!Utilitarios.Utilitarios.ValidarNota(inputNota))
                {
                    while (notaInvalida)
                    {
                        Console.Clear();

                        if (!Utilitarios.Utilitarios.ValidarNota(inputNota))
                        {
                            Console.ForegroundColor = _azul;
                            Console.WriteLine("Nota inválida!");
                            Console.WriteLine();
                            Console.ForegroundColor = _branco;
                            Console.Write($"Digite novamente a {i}ª nota: ");
                            inputNota = Console.ReadLine();
                        }
                        else
                        {
                            notaInvalida = false;
                        }
                    }
                }

                decimal.TryParse(inputNota, out decimal nota);
                var comando = new NotaComando(idAluno, idDisciplina, nota);
                _notaServico.Criar(comando);

                notaInvalida = true;

                Console.Clear();
            }

            Console.Clear();
            Console.ForegroundColor = _azul;
            Console.WriteLine("Notas cadastradas com sucesso.");
            Console.WriteLine();
            Console.ForegroundColor = _branco;
            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadLine();
        }
    }
}
