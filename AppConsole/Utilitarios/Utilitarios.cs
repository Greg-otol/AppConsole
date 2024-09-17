using AppConsole.Servicos.Alunos.Modelos;
using AppConsole.Servicos.Disciplinas.Modelos;

namespace AppConsole.Utilitarios
{
    public class Utilitarios
    {
        private static int _Id = 0;

        public static int GerarId()
        {
            _Id++;

            return _Id;
        }

        public static bool ValidarAluno(List<Aluno> alunos, string input)
        {
            int idAluno;
            if (int.TryParse(input, out idAluno))
            {
                var aluno = alunos.Find(a => a.Id == idAluno);
                return aluno != null && aluno.Id > 0;
            }

            return false;
        }

        public static bool ValidarDisciplina(string inputIdDisciplina)
        {
            return int.TryParse(inputIdDisciplina, out int idDisciplina) && idDisciplina != 0 && idDisciplina <= 8;
        }

        public static bool ValidarDisciplinaNota(List<Disciplina> disciplinas, string inputIdAluno, string inputIdDisciplina)
        {
            if (int.TryParse(inputIdAluno, out int idAluno) && int.TryParse(inputIdDisciplina, out int idDisciplina))
            {
                var disciplina = disciplinas.Find(d => d.IdAluno == idAluno && d.Id == idDisciplina);
                return disciplina != null && disciplina.Id > 0;
            }

            return false;
        }

        public static bool ValidarNota(string input)
        {
            return decimal.TryParse(input, out decimal nota) && nota != 0 && nota <= 10;
        }
    }
}
