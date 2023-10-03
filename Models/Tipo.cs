namespace AcaiBrotas.Models
{
    public class Tipo
    {
        public Guid TipoId { get; set; }
        public string Name { get; set;}

        public IEnumerable<Produto>? Produtos { get; set;}
    }
}
