using MV_P1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MV_P1.Controllers
{
    public class HomeController : Controller
    {
        BibliotecaEntities db = new BibliotecaEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult listaLibros()
        {
            var lst = db.tbl_Libros.ToList();
            return View(lst);
        }
        public ActionResult FormularioLibros()
        {
            ViewBag.TipoLibros = db.tbl_Tipos_Libros.ToList();
            return View();
        }
        public JsonResult guardarLibros(int id_Libro, string Nombre, string Editorial, string Autor, string Genero, string PaisOrigen,
            int NoPaginas, DateTime FechaEdicion, float Precio, int id_TipoLibro)
        {
            tbl_Libros c = new tbl_Libros();
            c.id_Libro = id_Libro;
            c.Nombre = Nombre;
            c.Editorial = Editorial;
            c.Autor = Autor;
            c.Genero = Genero;
            c.PaisOrigen = PaisOrigen;
            c.NoPaginas = NoPaginas;
            c.FechaEdicion = FechaEdicion;
            c.Precio = Precio;
            c.id_TipoLibro = id_TipoLibro;
            db.tbl_Libros.Add(c);
            db.SaveChanges();
            return Json("");
        }
        public ActionResult listaChecadasEmpleados()
        {
            var lst = db.tbl_Checadas_Empleados.ToList();
            return View(lst);
        }
        public ActionResult FormularioChecadasEmpleados()
        {
            return View();
        }
        public JsonResult guardarChecadas(int id_Checadas_empleados, DateTime Fecha, TimeSpan Entrada, TimeSpan Salida, int id_Empleados)
        {
            tbl_Checadas_Empleados b = new tbl_Checadas_Empleados();
            b.id_Checadas_empleados = id_Checadas_empleados;
            b.Fecha = Fecha;
            b.Entrada = Entrada;
            b.Salida = Salida;
            b.id_Empleados = id_Empleados;
            db.tbl_Checadas_Empleados.Add(b);
            db.SaveChanges();
            return Json("");
        }
        public ActionResult listaEmpleados()
        {
            var lst = db.tbl_Empleados.ToList();
            return View(lst);
        }
        public ActionResult FormularioEmpleados()
        {
            return View();
        }
        public JsonResult guardarEmpleado(int IdEmpleado, string NombreEmpleado, string ApellidosEmpleado, string DNIempleado,
            string DomicilioEmpleado, DateTime FechaDeNacimientoEmpleado, DateTime AntiguedadEmpleado)
        {
            tbl_Empleados a = new tbl_Empleados();
            a.id_Empleados = IdEmpleado;
            a.Nombres = NombreEmpleado;
            a.Apellidos = ApellidosEmpleado;
            a.DNI = DNIempleado;
            a.Domicilio = DomicilioEmpleado;
            a.Fecha_de_nacimiento = FechaDeNacimientoEmpleado;
            a.Antiguedad = AntiguedadEmpleado;
            db.tbl_Empleados.Add(a);
            db.SaveChanges();
            return Json("");
        }

        public ActionResult listaTiposLibros()
        {
            var lst = db.tbl_Tipos_Libros.ToList();
            return View(lst);
        }
        public ActionResult FormularioTiposLibros()
        {
            return View();
        }
        public JsonResult guardarTipoLibros(int IdTiposLibros, string EstanteLibros, string TematicaLibros)
        {
            tbl_Tipos_Libros d = new tbl_Tipos_Libros();
            d.id_TipoLibro = IdTiposLibros;
            d.Estante = EstanteLibros;
            d.Tematica = TematicaLibros;
            db.tbl_Tipos_Libros.Add(d);
            db.SaveChanges();
            return Json("");
        }

        public ActionResult FormularioVentas() 
        {
            return View();
        }

        public ActionResult listaVentas()
        {
            var lst = db.tbl_Ventas.ToList();
            return View(lst);
        }

        
        public JsonResult guardarVentas(int Total, DateTime Fecha, TimeSpan Hora, int idEmpleado, int idVentaLibro) 
        {
            tbl_Ventas d = new tbl_Ventas();
            d.Total = Total;
            d.Fecha = Fecha;
            d.Hora = Hora;
            d.id_Empleados = idEmpleado;
            d.id_Venta = idVentaLibro;
            db.tbl_Ventas.Add(d);
            db.SaveChanges();
            return Json("");
        }
    }
}