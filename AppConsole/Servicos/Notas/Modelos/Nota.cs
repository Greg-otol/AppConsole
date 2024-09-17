namespace AppConsole.Servicos.Notas.Modelos
{
    public class Nota
    {
        public int Id { get; set; }
        public int IdAluno { get; set; }
        public int IdDisciplina { get; set; }
        public decimal Valor { get; set; }

        public Nota(int idAluno, int idDisciplina, decimal valor)
        {
            Id = Utilitarios.Utilitarios.GerarId();
            IdAluno = idAluno;
            IdDisciplina = idDisciplina;
            Valor = valor;
        }
    }
}
