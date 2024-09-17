namespace AppConsole.Servicos.Disciplinas.Modelos
{
    public class Disciplina
    {
        public int Id { get; set; }
        public int IdAluno { get; set; }
        public string Nome { get; set; }

        public Disciplina(int idAluno, string nome)
        {
            Id = Utilitarios.Utilitarios.GerarId();
            IdAluno = idAluno;
            Nome = nome;
        }
    }
}
