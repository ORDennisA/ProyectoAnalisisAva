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
        public ActionResult GetEmpleado(int id)
        {
            // Busca el empleado correspondiente en tu modelo de datos
            tbl_Empleados empleado = db.tbl_Empleados.Find(id);

            // Si el empleado no se encuentra, devuelve un error
            if (empleado == null)
            {
                return HttpNotFound();
            }

            // Crea un objeto anónimo con los datos del empleado y devuelve una respuesta JSON
            var empleadoJson = new
            {
                id_Empleados = empleado.id_Empleados,
                Nombres = empleado.Nombres,
                Apellidos = empleado.Apellidos,
                DNI = empleado.DNI,
                Domicilio = empleado.Domicilio,
                Fecha_de_nacimiento = empleado.Fecha_de_nacimiento,
                Antiguedad = empleado.Antiguedad
            };
            return Json(empleadoJson, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveEditedEmpleado(int id, string NombreEmpleado, string ApellidosEmpleado, string DNIempleado,
            string DomicilioEmpleado, DateTime FechaDeNacimientoEmpleado, DateTime AntiguedadEmpleado)
        {
            if (id != null)
            {
                tbl_Empleados emp = db.tbl_Empleados.Find(id);

                emp.Nombres = NombreEmpleado;
                emp.Apellidos = ApellidosEmpleado;
                emp.DNI = DNIempleado;
                emp.Domicilio = DomicilioEmpleado;
                emp.Fecha_de_nacimiento = FechaDeNacimientoEmpleado;
                emp.Antiguedad = AntiguedadEmpleado;

                db.SaveChanges();
            }
            return Json("");
        }

        public ActionResult DeleteEmpleado(int id)
        {
            var empleado = db.tbl_Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            db.tbl_Empleados.Remove(empleado);
            db.SaveChanges();
            return Json("");
        }

        public ActionResult GetVenta(int id)
        {
            // Busca la venta correspondiente en tu modelo de datos
            tbl_Ventas venta = db.tbl_Ventas.Find(id);

            // Si la venta no se encuentra, devuelve un error
            if (venta == null)
            {
                return HttpNotFound();
            }

            // Crea un objeto anónimo con los datos de la venta y devuelve una respuesta JSON
            var ventaJson = new
            {
                id_Venta = venta.id_Venta,
                Total = venta.Total,
                Fecha = venta.Fecha,
                Hora = venta.Hora,
                id_Empleado = venta.id_Empleados//,
                //id_VentaLibros = venta.id_Venta_Libros
            };
            return Json(ventaJson, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveEditedVenta(int id, int Total, DateTime Fecha, TimeSpan Hora, int idEmpleado, int idVentaLibro)
        {
            if (id != null)
            {
                tbl_Ventas emp = db.tbl_Ventas.Find(id);

                emp.Total = Total;
                emp.Fecha = Fecha;
                emp.Hora = Hora;
                emp.id_Empleados = idEmpleado;
                emp.id_Venta = idVentaLibro;

                db.SaveChanges();
            }
            return Json("");
        }


        public ActionResult DeleteVenta(int id)
        {
            var venta = db.tbl_Ventas.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            db.tbl_Ventas.Remove(venta);
            db.SaveChanges();
            return Json("");
        }

        public ActionResult GetUsuario(int id)
        {
            // Busca al usuario correspondiente en tu modelo de datos
            tbl_Usuarios venta = db.tbl_Usuarios.Find(id);

            // Si el usuario no se encuentra, devuelve un error
            if (venta == null)
            {
                return HttpNotFound();
            }

            // Crea un objeto anónimo con los datos de la venta y devuelve una respuesta JSON
            var usuarioJson = new
            {
                id__Usuarios = venta.id_Usuarios,
                Nombres = venta.Nombres,
                Apellidos = venta.Apellidos,
                DNI = venta.DNI,
                Domicilio = venta.Domicilio,
                Fecha_de_Nacimiento = venta.Fecha_de_nacimiento
            };
            return Json(usuarioJson, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveEditedUsuario(int id, string Nombres, string Apellidos, string DNI, string Domicilio, DateTime Fecha_de_nacimiento)
        {
            if (id != null)
            {
                tbl_Usuarios emp = db.tbl_Usuarios.Find(id);

                emp.Nombres = Nombres;
                emp.Apellidos = Apellidos;
                emp.DNI = DNI;
                emp.Domicilio = Domicilio;
                emp.Fecha_de_nacimiento = Fecha_de_nacimiento;

                db.SaveChanges();
            }
            return Json("");
        }
        public ActionResult DeleteUsuario(int id)
        {
            var usuario = db.tbl_Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            db.tbl_Usuarios.Remove(usuario);
            db.SaveChanges();
            return Json("");
        }

        public ActionResult GetVentaLibro(int id)
        {
            // Busca al usuario correspondiente en tu modelo de datos
            tbl_Venta_Libros vl = db.tbl_Venta_Libros.Find(id);

            // Si el usuario no se encuentra, devuelve un error
            if (vl == null)
            {
                return HttpNotFound();
            }

            // Crea un objeto anónimo con los datos de la venta y devuelve una respuesta JSON
            var vlJson = new
            {
                id__Venta_Libros = vl.id_Venta_Libros,
                id_Libro = vl.id_Libro
            };
            return Json(vlJson, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveEditedVL(int id, int idLibros)
        {
            if (id != null)
            {
                tbl_Venta_Libros emp = db.tbl_Venta_Libros.Find(id);

                emp.id_Libro = idLibros;

                db.SaveChanges();
            }
            return Json("");
        }
        public ActionResult DeleteVentaLibros(int id)
        {
            var ventaL = db.tbl_Venta_Libros.Find(id);
            if (ventaL == null)
            {
                return HttpNotFound();
            }
            db.tbl_Venta_Libros.Remove(ventaL);
            db.SaveChanges();
            return Json("");
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

        public ActionResult FormularioUsuarios()
        {
            return View();
        }

        public ActionResult listaUsuarios()
        {
            var lst = db.tbl_Usuarios.ToList();
            return View(lst);
        }

        public JsonResult guardarUsuarios(string Nombres, string Apellidos, string DNI, string Domicilio, DateTime Fecha_de_nacimiento)
        {
            tbl_Usuarios d = new tbl_Usuarios();
            d.Nombres = Nombres;
            d.Apellidos = Apellidos;
            d.DNI = DNI;
            d.Domicilio = Domicilio;
            d.Fecha_de_nacimiento = Fecha_de_nacimiento;
            db.tbl_Usuarios.Add(d);
            db.SaveChanges();
            return Json("");
        }

        public ActionResult FormularioVentaLibros()
        {
            return View();
        }
        public ActionResult listaVentaLibros()
        {
            var lst = db.tbl_Venta_Libros.ToList();
            return View(lst);
        }
        public JsonResult guardarVentaLibros(int idLibros)
        {
            tbl_Venta_Libros d = new tbl_Venta_Libros();
            d.id_Libro = idLibros;
            db.tbl_Venta_Libros.Add(d);
            db.SaveChanges();
            return Json("");
        }
        public ActionResult FormularioPrestamo()
        {
            ViewBag.TipoLibros = db.tbl_Prestamos.ToList();
            return View();
        }


        public ActionResult listaPrestamo()
        {
            var lst = db.tbl_Prestamos.ToList();
            return View(lst);
        }

        public JsonResult guardarPrestamo(DateTime FechaSalida, DateTime FechaMaxDev, DateTime FechaDev, int idUsuarios, int idTipoDePrestamos)
        {
            tbl_Prestamos d = new tbl_Prestamos();
            d.Fecha_de_Salida = FechaSalida;
            d.Fecha_maxima_de_devolucion = FechaMaxDev;
            d.Fecha_de_devolucion = FechaDev;
            d.id_Usuarios = idUsuarios;
            d.id_Tipos_de_prestamos = idTipoDePrestamos;
            db.tbl_Prestamos.Add(d);
            db.SaveChanges();
            return Json("");
        }

        public ActionResult DeletePrestamo(int id)
        {
            var Prestamo = db.tbl_Prestamos.Find(id);
            if (Prestamo == null)
            {
                return HttpNotFound();
            }
            db.tbl_Prestamos.Remove(Prestamo);
            db.SaveChanges();
            return Json("");
        }

        public ActionResult GetPrestamo(int id)
        {
            // Busca el libro correspondiente en tu modelo de datos
            tbl_Prestamos libro = db.tbl_Prestamos.Find(id);

            // Si el libro no se encuentra, devuelve un error
            if (libro == null)
            {
                return HttpNotFound();
            }

            // Crea un objeto anónimo con los datos del libro y devuelve una respuesta JSON
            var libroJSON = new
            {
                idPrestamo = libro.id_Prestamo,
                FechaSalida = libro.Fecha_de_Salida,
                FechaMaxDev = libro.Fecha_maxima_de_devolucion,
                FechaDev = libro.Fecha_de_devolucion,
                idTipoDePrestamos= libro.id_Tipos_de_prestamos,
                idUsuarios = libro.id_Usuarios
            };
            return Json(libroJSON, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveEditedPrestamo(int idPrestamos,DateTime FechaSalida, DateTime FechaMaxDev, DateTime FechaDev, int idUsuarios, int idTipoDePrestamos)
        {
            if (idPrestamos != null)
            {
                tbl_Prestamos prestamos = db.tbl_Prestamos.Find(idPrestamos);

                prestamos.id_Prestamo = idPrestamos;
                prestamos.Fecha_de_Salida = FechaSalida;
                prestamos.Fecha_maxima_de_devolucion = FechaMaxDev;
                prestamos.Fecha_de_devolucion = FechaDev;
                prestamos.id_Usuarios = idUsuarios;
                prestamos.id_Tipos_de_prestamos = idTipoDePrestamos;

                db.SaveChanges();
            }
            return Json("");
        }
    }
}
