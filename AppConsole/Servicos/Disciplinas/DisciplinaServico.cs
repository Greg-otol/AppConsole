using AppConsole.Servicos.Disciplinas.Modelos;
using AppConsole.Servicos.Disciplinas.Modelos.Comandos;
using AppConsole.Servicos.Disciplinas.Repositorios;

namespace AppConsole.Servicos.Disciplinas
{
    public class DisciplinaServico
    {
        private readonly IDisciplinaRepositorio _disciplinaRepositorio;

        public DisciplinaServico(IDisciplinaRepositorio disciplinaRepositorio)
        {
            _disciplinaRepositorio = disciplinaRepositorio;
        }

        public string Criar(DisciplinaComando comando)
        {
            try
            {
                if (string.IsNullOrEmpty(comando.Nome))
                    return "Digite o nome da disciplina!";

                var novaDisciplina = new Disciplina(comando.IdAluno, comando.Nome);

                _disciplinaRepositorio.Criar(novaDisciplina);

                return "Disciplina cadastrada com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Não foi possível cadastrar a Disciplina. Motivo: {ex.Message}";
            }
        }

        public List<Disciplina> Listar()
        {
            var disciplinas = _disciplinaRepositorio.Listar();

            return disciplinas;
        }
    }
}
