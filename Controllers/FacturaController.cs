using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoIdentity.Datos;
using ProyectoIdentity.Models;

namespace ProyectoIdentity.Controllers
{
    public class FacturaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacturaController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Registrar()
        {
            var model = new FacturaViewModel();
            model.Items = new List<FacturaItemViewModel>
            {
                new FacturaItemViewModel()
            };
            //por defecto, agregamos un item para que el usuario no vea el formulario vacio 

            ViewBag.Clientes = new SelectList(_context.Clientes, "Id", "Nombre");
            ViewBag.CondicionesPago = new SelectList(_context.CondicionesPago, "Id", "Descripcion");
            ViewBag.MetodosPago = new SelectList(_context.MetodosPago, "Id", "Nombre");
            ViewBag.Productos = new SelectList(_context.Productos, "Id", "Nombre");
            ViewBag.ProductosList = _context.Productos.ToList(); // <--- Para JS
            return View(model);
        }

        [HttpPost]
        public IActionResult Registrar(FacturaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Clientes = new SelectList(_context.Clientes, "Id", "Nombre");
                ViewBag.CondicionesPago = new SelectList(_context.CondicionesPago, "Id", "Descripcion");
                ViewBag.MetodosPago = new SelectList(_context.MetodosPago, "Id", "Nombre");
                ViewBag.Productos = new SelectList(_context.Productos, "Id", "Nombre");
                return View(model);
            }
            // Aquí puedes mapear el ViewModel al modelo de dominio y persistir la factura y sus ítems
            // Ejemplo básico:
            var factura = new Factura
            {
                ClienteId = model.ClienteId,
                CondicionPagoId = model.CondicionPagoId,
                MetodoPagoId = model.MetodoPagoId,
                Fecha = model.Fecha,
                Items = model.Items.Select(i => new FacturaItem
                {
                    ProductoId = i.ProductoId,
                    Cantidad = i.Cantidad,
                    PrecioUnitario = i.PrecioUnitario,
                    DescuentoAplicado = i.DescuentoAplicado
                }).ToList()
            };
            _context.Facturas.Add(factura);
            _context.SaveChanges();
            return RedirectToAction("Index"); // o a donde quieras redirigir
        }
    }
}
