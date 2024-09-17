namespace AppConsole.Servicos.Disciplinas.Modelos.Comandos
{
    public class DisciplinaComando
    {
        public int IdAluno { get; set; }
        public string Nome { get; set; }

        public DisciplinaComando(int idAluno, string nome)
        {
            IdAluno = idAluno;
            Nome = nome;
        }
    }
}
