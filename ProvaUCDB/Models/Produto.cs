namespace ProvaUCDB.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Produto()
        {
        }

        public Produto(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
