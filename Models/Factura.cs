namespace ProyectoIdentity.Models
{
    public class Factura
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int CondicionPagoId { get; set; }
        public CondicionPago CondicionPago { get; set; }

        public int MetodoPagoId { get; set; }
        public MetodoPago MetodoPago { get; set; }

        public ICollection<FacturaItem> Items { get; set; }
    }
}
