using AppConsole.Servicos.Alunos;
using AppConsole.Servicos.Disciplinas;
using AppConsole.Servicos.Notas;

namespace AppConsole.Visualizacoes.Notas
{
    public class ListagemNota
    {
        private ConsoleColor _branco = ConsoleColor.White;
        private ConsoleColor _azul = ConsoleColor.Blue;

        private readonly AlunoServico _alunoServico;
        private readonly DisciplinaServico _disciplinaServico;
        private readonly NotaServico _notaServico;

        public ListagemNota(AlunoServico alunoServico, DisciplinaServico disciplinaServico, NotaServico notaServico)
        {
            _alunoServico = alunoServico;
            _disciplinaServico = disciplinaServico;
            _notaServico = notaServico;
        }

        public void ListarNotasPorAluno()
        {
            Console.ForegroundColor = _branco;

            Console.Clear();
            Console.WriteLine("******** Notas dos Alunos cadastrados ********");
            Console.WriteLine();

            var alunos = _alunoServico.Listar();

            if (alunos.Count > 0 && alunos != null)
            {
                Console.WriteLine("Aluno");
                foreach (var aluno in alunos)
                {
                    var disciplinas = _disciplinaServico.Listar().Where(d => d.IdAluno == aluno.Id).ToList();
                    if (disciplinas.Count(d => d.IdAluno == aluno.Id) == 0)
                        continue;

                    Console.ForegroundColor = _azul;
                    Console.WriteLine($"{aluno.Nome}");
                    Console.WriteLine();
                    foreach (var disciplina in disciplinas)
                    {
                        int bimestre = 0;
                        var notas = _notaServico.Listar().Where(n => n.IdAluno == aluno.Id && n.IdDisciplina == disciplina.Id).ToList();

                        Console.WriteLine($"{disciplina.Nome}");
                        foreach (var nota in notas)
                        {
                            bimestre++;
                            Console.WriteLine($"  {bimestre}º bimestre - {nota.Valor}");
                        }

                        Console.WriteLine();
                        Console.WriteLine($"  Média {(notas.Sum(n => n.Valor) / 4):F2}");
                    }

                    var notasGeral = _notaServico.Listar().Where(n => n.IdAluno == aluno.Id).ToList();

                    Console.WriteLine();
                    Console.WriteLine($"Média Geral: {(notasGeral.Sum(n => n.Valor) / 4 / disciplinas.Count):F2}");
                    Console.WriteLine();
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
