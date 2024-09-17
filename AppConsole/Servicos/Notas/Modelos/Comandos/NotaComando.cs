namespace AppConsole.Servicos.Notas.Modelos.Comandos
{
    public class NotaComando
    {
        public int IdAluno { get; set; }
        public int IdDisciplina { get; set; }
        public decimal Valor { get; set; }

        public NotaComando(int idAluno, int idDisciplina, decimal valor)
        {
            IdAluno = idAluno;
            IdDisciplina = idDisciplina;
            Valor = valor;
        }
    }
}
