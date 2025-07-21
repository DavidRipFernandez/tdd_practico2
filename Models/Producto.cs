using Microsoft.EntityFrameworkCore;

namespace ProyectoIdentity.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string CodigoSKU { get; set; }
        public string Nombre { get; set; }
        public int GrupoProductoId { get; set; }
        public GrupoProducto GrupoProducto { get; set; }
        public int AlmacenId { get; set; }  
        public Almacen Almacen { get; set; }
        [Precision(10,2)]
        public decimal PrecioCompra {  get; set; }
        [Precision(10, 2)]
        public decimal PrecioVenta { get; set; }   
    }
}
