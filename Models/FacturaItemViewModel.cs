namespace ProyectoIdentity.Models
{
    public class FacturaItemViewModel
    {
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario;
        public decimal DescuentoAplicado { get; set; }
        public decimal Total => Subtotal - (Subtotal * DescuentoAplicado);

    }
}
