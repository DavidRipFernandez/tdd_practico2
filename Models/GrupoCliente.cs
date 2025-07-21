using Microsoft.EntityFrameworkCore;

namespace ProyectoIdentity.Models
{
    public class GrupoCliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [Precision(10, 2)]
        public decimal? PorcentajeDescuento { get; set; }
        public ICollection<Cliente> Clientes { get; set; }
    }
}
