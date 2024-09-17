using AppConsole.Servicos.Notas.Modelos;
using AppConsole.Servicos.Notas.Modelos.Comandos;
using AppConsole.Servicos.Notas.Repositorios;

namespace AppConsole.Servicos.Notas
{
    public class NotaServico
    {
        private readonly INotaRepositorio _notaRepositorio;

        public NotaServico(INotaRepositorio notaRepositorio)
        {
            _notaRepositorio = notaRepositorio;
        }

        public string Criar(NotaComando comando)
        {
            try
            {
                if (comando.Valor == 0)
                    return "Digite o valor da nota!";

                var novaNota = new Nota(comando.IdAluno, comando.IdDisciplina, comando.Valor);

                _notaRepositorio.Criar(novaNota);

                return "Nota cadastrada com sucesso.";
            }
            catch (Exception ex)
            {
                return $"Não foi possível cadastrar a Nota. Motivo: {ex.Message}";
            }
        }

        public List<Nota> Listar()
        {
            var notas = _notaRepositorio.Listar();

            return notas;
        }
    }
}
