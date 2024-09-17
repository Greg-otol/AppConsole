using AppConsole.Infra.Dados;
using AppConsole.Servicos.Disciplinas.Modelos;
using AppConsole.Servicos.Disciplinas.Repositorios;

namespace AppConsole.Infra.Disciplinas
{
    public class DisciplinaRepositorio : IDisciplinaRepositorio
    {
        public void Criar(Disciplina disciplina)
        {
            BancoDados.TabelaDisciplina(disciplina);
        }

        public List<Disciplina> Listar()
        {
            return BancoDados.TabelaDisciplina().ToList();
        }
    }
}
