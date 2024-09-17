using AppConsole.Servicos.Alunos;
using AppConsole.Servicos.Disciplinas;
using AppConsole.Visualizacoes.Alunos;
using AppConsole.Visualizacoes.Disciplinas;
using AppConsole.Visualizacoes.Menus;
using AppConsole.Visualizacoes.Notas;

namespace AppConsole.Visualizacoes
{
    public class TelaPrincipal
    {
        private ConsoleColor _branco = ConsoleColor.White;
        private ConsoleColor _azul = ConsoleColor.Blue;

        private readonly Menu _menu;

        private readonly ListagemAluno _listagemAluno;
        private readonly CadastroAluno _cadastroAluno;
        private readonly CadastroDisciplina _cadastroDisciplina;
        private readonly CadastroNota _cadastroNota;
        private readonly ListagemNota _listagemNota;

        private readonly AlunoServico _alunoServico;
        private readonly DisciplinaServico _disciplinaServico;

        public TelaPrincipal(AlunoServico alunoServico, DisciplinaServico disciplinaServico, ListagemAluno listagemAluno, CadastroAluno cadastroAluno, CadastroDisciplina cadastroDisciplina, Menu menu, CadastroNota cadastroNota, ListagemNota listagemNota)
        {
            _alunoServico = alunoServico;
            _disciplinaServico = disciplinaServico;
            _listagemAluno = listagemAluno;
            _cadastroAluno = cadastroAluno;
            _cadastroDisciplina = cadastroDisciplina;
            _menu = menu;
            _cadastroNota = cadastroNota;
            _listagemNota = listagemNota;
        }

        public void Menu()
        {
            bool continuar = true;

            while (continuar)
            {
                _menu.MenuOpcao();

                Console.Write("Digite uma opção: ");

                string opcao = Console.ReadLine();
                Console.WriteLine();
                Console.Clear();

                switch (opcao)
                {
                    case "1":
                        _cadastroAluno.AdicionarAluno();
                        break;
                    case "2":
                        _listagemAluno.ListarAlunos();
                        break;
                    case "3":
                        if (_alunoServico.Listar().Count == 0)
                        {
                            Console.ForegroundColor = _azul;
                            Console.WriteLine("Para cadastrar uma disciplina, é necessário ter alunos cadastrados.");
                            Console.WriteLine();
                            Console.ForegroundColor = _branco;
                            Console.WriteLine("Pressione Enter para digitar outra opção...");
                            Console.ReadLine();

                            break;
                        }

                        _cadastroDisciplina.AdicionarDisciplina();
                        break;
                    case "4":
                        if (_alunoServico.Listar().Count == 0 && _disciplinaServico.Listar().Count == 0)
                        {
                            Console.ForegroundColor = _azul;
                            Console.WriteLine("Para cadastrar uma nota, é necessário ter alunos e disciplinas cadastrados.");
                            Console.WriteLine();
                            Console.ForegroundColor = _branco;
                            Console.WriteLine("Pressione Enter para digitar outra opção...");
                            Console.ReadLine();

                            break;
                        }

                        _cadastroNota.AdicionarNota();
                        break;
                    case "5":
                        _listagemNota.ListarNotasPorAluno();
                        break;
                    case "6":
                        continuar = false;
                        break;
                    default:
                        Console.ForegroundColor = _azul;
                        Console.WriteLine("Opção inválida!");
                        Console.WriteLine();

                        Console.ForegroundColor = _branco;
                        Console.WriteLine("Pressione Enter para digitar outra opção...");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
