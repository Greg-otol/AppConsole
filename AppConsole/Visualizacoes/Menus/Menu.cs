using AppConsole.Infra.Disciplinas.Dados;
using AppConsole.Servicos.Alunos;
using AppConsole.Servicos.Disciplinas;

namespace AppConsole.Visualizacoes.Menus
{
    public class Menu
    {
        private ConsoleColor _branco = ConsoleColor.White;
        private ConsoleColor _azul = ConsoleColor.Blue;

        private readonly AlunoServico _alunoServico;
        private readonly DisciplinaServico _disciplinaServico;

        public Menu(AlunoServico alunoServico, DisciplinaServico disciplinaServico)
        {
            _alunoServico = alunoServico;
            _disciplinaServico = disciplinaServico;
        }

        public void MenuOpcao()
        {
            Console.ForegroundColor = _branco;
            Console.Clear();
            Console.WriteLine("*************** Menu ***************");
            Console.WriteLine();

            Console.ForegroundColor = _azul;

            Console.WriteLine("Cadastrar Alunos            [ 1 ]");
            Console.WriteLine("Listar Alunos               [ 2 ]");
            Console.WriteLine("Cadastrar Disciplinas       [ 3 ]");
            Console.WriteLine("Cadastrar Notas             [ 4 ]");
            Console.WriteLine("Listar Notas por Aluno      [ 5 ]");
            Console.WriteLine("Sair                        [ 6 ]");

            Console.ForegroundColor = _branco;
            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.WriteLine();
        }

        public void MenuAluno()
        {
            Console.Clear();
            Console.ForegroundColor = _branco;
            Console.WriteLine("********* Alunos *********");
            Console.WriteLine();

            Console.ForegroundColor = _branco;
            Console.WriteLine("Código     Aluno");
            var alunos = _alunoServico.Listar();
            foreach (var aluno in alunos)
            {
                Console.ForegroundColor = _azul;
                Console.WriteLine($"{aluno.Id}          {aluno.Nome}");
            }

            Console.WriteLine();
            Console.ForegroundColor = _branco;
            Console.WriteLine("==========================");
            Console.WriteLine();
        }

        public void MenuDisciplina()
        {
            Console.Clear();
            Console.ForegroundColor = _branco;
            Console.WriteLine("********* Disciplinas *********");
            Console.WriteLine();

            Console.ForegroundColor = _branco;
            Console.WriteLine("Código     Disciplina");
            var disciplinas = TabelaDisciplina.Disciplinas();
            foreach (var disciplina in disciplinas)
            {
                Console.ForegroundColor = _azul;
                Console.WriteLine($"{disciplina.Id}          {disciplina.Nome}");
            }

            Console.WriteLine();
            Console.ForegroundColor = _branco;
            Console.WriteLine("===============================");
            Console.WriteLine();
        }

        public void MenuNotaDisciplina(int idAluno)
        {
            Console.Clear();
            Console.ForegroundColor = _branco;
            Console.WriteLine("********* Disciplinas *********");
            Console.WriteLine();

            Console.ForegroundColor = _branco;
            Console.WriteLine("Código     Disciplina");
            var disciplinas = _disciplinaServico.Listar().Where(d => d.IdAluno == idAluno);
            foreach (var disciplina in disciplinas)
            {
                Console.ForegroundColor = _azul;
                Console.WriteLine($"{disciplina.Id}          {disciplina.Nome}");
            }

            Console.WriteLine();
            Console.ForegroundColor = _branco;
            Console.WriteLine("===============================");
            Console.WriteLine();
        }
    }
}
