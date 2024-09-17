namespace AppConsole.Servicos.Alunos.Modelos
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Aluno(string nome)
        {
            Id = Utilitarios.Utilitarios.GerarId();
            Nome = nome;
        }
    }
}
