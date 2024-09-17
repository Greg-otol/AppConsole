namespace AppConsole.Infra.Disciplinas.Dados
{
    public class TabelaDisciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        private TabelaDisciplina(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static List<TabelaDisciplina> Disciplinas()
        {
            var disciplinas = new List<TabelaDisciplina>
            {
                new TabelaDisciplina(1, "Matemática"),
                new TabelaDisciplina(2, "Português"),
                new TabelaDisciplina(3, "Inglês"),
                new TabelaDisciplina(4, "Química"),
                new TabelaDisciplina(5, "Física"),
                new TabelaDisciplina(6, "Geografia"),
                new TabelaDisciplina(7, "História"),
                new TabelaDisciplina(8, "Informática")
            };

            return disciplinas;
        }
    }
}
