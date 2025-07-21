namespace ProyectoIdentity.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string CodigoCliente { get; set; }
        public string Nombre { get; set; }
        public int GrupoClienteId { get; set; }
        public GrupoCliente GrupoCliente {  get; set; }
    }
}
