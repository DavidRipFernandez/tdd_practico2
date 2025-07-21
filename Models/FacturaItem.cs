using Microsoft.EntityFrameworkCore;

namespace ProyectoIdentity.Models
{
    public class FacturaItem
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public Factura Factura { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public int Cantidad { get; set; }
        [Precision(10,2)]
        public decimal PrecioUnitario { get; set; }
        [Precision(10, 2)]
        public decimal DescuentoAplicado { get; set; } // Porcentaje aplicado
    }
}
