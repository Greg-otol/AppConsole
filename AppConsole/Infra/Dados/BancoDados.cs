using AppConsole.Servicos.Alunos.Modelos;
using AppConsole.Servicos.Disciplinas.Modelos;
using AppConsole.Servicos.Notas.Modelos;

namespace AppConsole.Infra.Dados
{
    public class BancoDados
    {
        private static Aluno[] alunos = new Aluno[0];
        private static Disciplina[] disciplinas = new Disciplina[0];
        private static Nota[] notas = new Nota[0];

        public static Aluno[] TabelaAluno(Aluno? aluno = null)
        {
            if (aluno != null)
            {
                // Cria um novo array com tamanho maior para adicionar o novo aluno
                Aluno[] novoArray = new Aluno[alunos.Length + 1];

                // Copia os alunos existentes para o novo array
                for (int i = 0; i < alunos.Length; i++)
                {
                    novoArray[i] = alunos[i];
                }

                // Adiciona o novo aluno na última posição
                novoArray[alunos.Length] = aluno;

                // Substitui o array antigo pelo novo
                alunos = novoArray;
            }

            return alunos;
        }

        public static Disciplina[] TabelaDisciplina(Disciplina? disciplina = null)
        {
            if (disciplina != null)
            {
                // Cria um novo array com tamanho maior para adicionar a nova disciplina
                Disciplina[] novoArray = new Disciplina[disciplinas.Length + 1];

                // Copia as disciplinas existentes para o novo array
                for (int i = 0; i < disciplinas.Length; i++)
                {
                    novoArray[i] = disciplinas[i];
                }

                // Adiciona a nova disciplina na última posição
                novoArray[disciplinas.Length] = disciplina;

                // Substitui o array antigo pelo novo
                disciplinas = novoArray;
            }

            return disciplinas;
        }

        public static Nota[] TabelaNota(Nota? nota = null)
        {
            if (nota != null)
            {
                // Cria um novo array com tamanho maior para adicionar a nova nota
                Nota[] novoArray = new Nota[notas.Length + 1];

                // Copia as notas existentes para o novo array
                for (int i = 0; i < notas.Length; i++)
                {
                    novoArray[i] = notas[i];
                }

                // Adiciona a nova nota na última posição
                novoArray[notas.Length] = nota;

                // Substitui o array antigo pelo novo
                notas = novoArray;
            }

            return notas;
        }
    }
}
