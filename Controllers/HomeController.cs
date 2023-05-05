using MV_P1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MV_P1.Controllers
{
    public class HomeController : Controller
    {
        // DEFAULT

        ProyectoBibliotecaEntities db = new ProyectoBibliotecaEntities();
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

        //---------------------------------------------------------CODIGO DE LIBROS------------------------------------------------------/
        // ------------------------------------------------------------------------------------------------------------------------------/

        public ActionResult listaLibros()
        {
            var lst = db.tbl_Libros.ToList();
            return View(lst);
        }
        public ActionResult FormularioLibros()
        {
            ViewBag.TipoLibros = db.tbl_Tipos_Libros.ToList();
            var lst = db.tbl_Tipos_Libros.ToList();
            return View(lst);
        }

        public JsonResult guardarLibros(/* int id_Libro, */ string Nombre, string Editorial, string Autor, string Genero, string PaisOrigen,
            int NoPaginas, DateTime FechaEdicion, float Precio, int id_TipoLibro)
        {
            tbl_Libros c = new tbl_Libros();
            // c.id_Libro = id_Libro;
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
        public ActionResult EditarLibros()
        {
            var lst = db.tbl_Libros.ToList();
            return View(lst);
        }

        public ActionResult GetLibro(int id)
        {
            // Busca el libro correspondiente en tu modelo de datos
            tbl_Libros libro = db.tbl_Libros.Find(id);

            // Si el libro no se encuentra, devuelve un error
            if (libro == null)
            {
                return HttpNotFound();
            }

            // Crea un objeto anónimo con los datos del libro y devuelve una respuesta JSON
            var libroJSON = new
            {
                id_Libro = libro.id_Libro,
                Nombre = libro.Nombre,
                Editorial = libro.Editorial,
                Autor = libro.Autor,
                Genero = libro.Genero,
                PaisOrigen = libro.PaisOrigen,
                NoPaginas = libro.NoPaginas,
                FechaEdicion = libro.FechaEdicion,
                Precio = libro.Precio,
                id_TipoLibro = libro.id_TipoLibro
            };
            return Json(libroJSON, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveEditedLibro(int id_Libro, string Nombre, string Editorial, string Autor, string Genero, string PaisOrigen,
            int NoPaginas, DateTime FechaEdicion, float Precio, int id_TipoLibro)
        {
            if (id_Libro != null)
            {
                tbl_Libros libro = db.tbl_Libros.Find(id_Libro);

                libro.id_Libro = id_Libro;
                libro.Nombre = Nombre;
                libro.Editorial = Editorial;
                libro.Autor = Autor;
                libro.Genero = Genero;
                libro.PaisOrigen = PaisOrigen;
                libro.NoPaginas = NoPaginas;
                libro.FechaEdicion = FechaEdicion;
                libro.Precio = Precio;
                libro.id_TipoLibro = id_TipoLibro;

                db.SaveChanges();
            }
            return Json("");
        }
        public ActionResult DeleteLibro(int id)
        {
            var libro = db.tbl_Libros.Find(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            db.tbl_Libros.Remove(libro);
            db.SaveChanges();
            return Json("");
        }

        //--------------------------------------------------------CODIGO DE CHECADAS DE EMPLEADOS-------------------------------------------------------/
        //----------------------------------------------------------------------------------------------------------------------------------------------/




        //LISTA DE CHECADAS EMPLEADOS

        public ActionResult listaChecadasEmpleados()
        {
            var lst = db.tbl_Checadas_Empleados.ToList();
            return View(lst);
        }

        //FORMULARIO DE CHECADAS DE EMPLEADOS
        public ActionResult FormularioChecadasEmpleados()
        {
            var lst = db.tbl_Empleados.ToList();
            return View(lst);
        }

        //LINEA PARA GUARDAR CHECADAS
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


        //--------------------------------------------------------CODIGO DE EMPLEADOS------------------------------------------------------/
        // ------------------------------------------------------------------------------------------------------------------------------/

        //LINEA DE CODIGO DE LISTA DE EMPLEADOS
        public ActionResult listaEmpleados()
        {
            var lst = db.tbl_Empleados.ToList();
            return View(lst);
        }

        //LINEA DE CODIGO DE FORMULARIO DE EMPLEADOS
        public ActionResult FormularioEmpleados()
        {
            return View();
        }

        //LINEA DE CODIGO DE GUARDAR EMPLEADO
        public JsonResult guardarEmpleado(string NombreEmpleado, string ApellidosEmpleado, string DNIempleado,
            string DomicilioEmpleado, DateTime FechaDeNacimientoEmpleado, DateTime AntiguedadEmpleado)
        {
            tbl_Empleados a = new tbl_Empleados();
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

        //LINEA DE CODIGO DE EDITAR EMPLEADO
        public ActionResult EditarEmpleado()
        {
            var lst = db.tbl_Empleados.ToList();
            return View(lst);
        }

        //LINEA DE CODIGO DE LISTA DE EMPLEADO EN FORMULARIO DE EDITAR
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

        //LINEA DE CODIGO DE SALVAR EMPLEADO MODIFICADO EN FORMULARIO DE EDITAR EMPLEADO
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

        //LINEA DE CODIGO PARA BORRAR EMPLEADO
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

        


        //--------------------------------------------------------CODIGO DE TIPOS DE LIBROS------------------------------------------------------/
        // --------------------------------------------------------------------------------------------------------------------------------------/

        //LINEA DE CODIGO PARA LA LISTA DE TIPOS DE LIBROS
        public ActionResult listaTiposLibros()
        {
            var lst = db.tbl_Tipos_Libros.ToList();
            return View(lst);
        }

        //LINEA DE CODIGO PARA EL FORMULARIO DE TIPOS DE LIBROS
        public ActionResult FormularioTiposLibros()
        {
            return View();
        }

        //LINEA DE CODIGO PARA GUARDAR TIPOS DE LIBROS
        public JsonResult guardarTipoLibros(string EstanteLibros, string TematicaLibros)
        {
            tbl_Tipos_Libros d = new tbl_Tipos_Libros();
            // d.id_TipoLibro = IdTiposLibros;
            d.Estante = EstanteLibros;
            d.Tematica = TematicaLibros;
            db.tbl_Tipos_Libros.Add(d);
            db.SaveChanges();
            return Json("");
        }

        //LINEA DE CODIGO PARA EDITAR LOS TIPOS DE LIBROS
        public ActionResult EditarTiposLibros()
        {
            var lst = db.tbl_Tipos_Libros.ToList();
            return View(lst);
        }

        //LINEA DE CODIGO PARA OBTENER LA LISTA DE TIPOS DE LIBROS EN FORMULARIO EDITAR TIPOS DE LIBROS
        public ActionResult GetTipoLibro(int id)
        {
            // Busca el empleado correspondiente en tu modelo de datos
            tbl_Tipos_Libros tipo = db.tbl_Tipos_Libros.Find(id);

            // Si el empleado no se encuentra, devuelve un error
            if (tipo == null)
            {
                return HttpNotFound();
            }

            // Crea un objeto anónimo con los datos del empleado y devuelve una respuesta JSON
            var TipoLibroJson = new
            {
                id_TipoLibro = tipo.id_TipoLibro,
                Estante = tipo.Estante,
                Tematica = tipo.Tematica
            };
            return Json(TipoLibroJson, JsonRequestBehavior.AllowGet);
        }

        //LINEA DE CODIGO PARA SALVAR TIPO DE LIBRO MODIFICADO EN FORMULARIO EDITAR TIPO DE LIBRO
        public JsonResult SaveEditedTipoLibro(int IdTiposLibros, string EstanteLibros, string TematicaLibros)
        {
            if (IdTiposLibros != null)
            {
                tbl_Tipos_Libros tipo = db.tbl_Tipos_Libros.Find(IdTiposLibros);

                tipo.id_TipoLibro = IdTiposLibros;
                tipo.Estante = EstanteLibros;
                tipo.Tematica = TematicaLibros;

                db.SaveChanges();
            }
            return Json("");
        }

        //LINEA DE CODIGO PARA BORRAR TIPO DE LIBRO
        public ActionResult DeleteTipoLibro(int id)
        {
            var tipo = db.tbl_Tipos_Libros.Find(id);
            if (tipo == null)
            {
                return HttpNotFound();
            }
            db.tbl_Tipos_Libros.Remove(tipo);
            db.SaveChanges();
            return Json("");
        } 

        //--------------------------------------------------------CODIGO DE VENTAS------------------------------------------------------/
        // ------------------------------------------------------------------------------------------------------------------------------/
        
        //LINEA DE CODIGO PARA ABRIR EL FORMULARIO DE LISTA DE VENTAS
        public ActionResult listaVentas()
        {
            var lst = db.tbl_Ventas.ToList();
            return View(lst);
        }

        //LINEA DE CODIGO PARA ABRIR EL FORMULARIO DE VENTAS
        public ActionResult FormularioVentas()
        {
            var lst = db.tbl_Empleados.ToList();
            return View(lst);
        }

        //LINEA DE CODIGO PARA SALVAR LOS CAMPOS EN FORMULARIO DE VENTAS
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


        //--------------------------------------------------------CODIGO DE USUARIOS------------------------------------------------------/
        //--------------------------------------------------------------------------------------------------------------------------------/

        //LINEA DE CODIGO PARA MOSTRAR EL FORM DE LA LISTA DE USUARIOS
        public ActionResult listaUsuarios()
        {
            var lst = db.tbl_Usuarios.ToList();
            return View(lst);
        }

        //LINEA DE CODIGO PARA MOSTRAR EL FORMULARIO DE USUARIOS
        public ActionResult FormularioUsuarios()
        {
            return View();
        }

        //LINEA DE CODIGO PARA GUARDAR USUARIOS EN EL FORMULARIO DE USUARIOS
        public JsonResult guardarUsuarios(string Nombres, string Apellidos, string DNI, string Domicilio, string FechaNacimiento)
        {
            tbl_Usuarios d = new tbl_Usuarios();
            d.Nombres = Nombres;
            d.Apellidos = Apellidos;
            d.DNI = DNI;
            d.Domicilio = Domicilio;
            d.Fecha_de_nacimiento = FechaNacimiento;
            db.tbl_Usuarios.Add(d);
            db.SaveChanges();
            return Json("");
        }

        //--------------------------------------------------------CODIGO DE PRESTAMOS------------------------------------------------------/
        //---------------------------------------------------------------------------------------------------------------------------------/

        //LINEA DE CODIGO PARA GUARDAD CORRECTAMENTE EL INNER JOIN EN UNA LISTA PARA ENVIARLO A LA LISTA DE PRESTAMOS
        public class PrestamoViewModel
        {
            public int IdPrestamo { get; set; }
            public DateTime? FechaDeSalida { get; set; }
            public DateTime? FechaMaximaDeDevolucion { get; set; }
            public DateTime? FechaDeDevolucion { get; set; }
            public string Nombres { get; set; }
            public string Descripcion { get; set; }
        }

        //LISTA DE PRESTAMOS CODIGO
        public ActionResult listaPrestamo() //LINEA DE CODIGO PARA REALIZAR UN INNER JOIN EN LAS TABLAS USUARIO Y TIPOS DE PRESTAMOS
        {

            var context = new ProyectoBibliotecaEntities();

            var query = from p in context.tbl_Prestamos
                        join u in context.tbl_Usuarios on p.id_Usuarios equals u.id_Usuarios
                        join d in context.tbl_Tipos_de_prestamos on p.id_Tipos_de_prestamos equals d.id_Tipos_de_prestamos
                        select new PrestamoViewModel
                        {
                            IdPrestamo = p.id_Prestamo,
                            FechaDeSalida = p.Fecha_de_Salida,
                            FechaMaximaDeDevolucion = p.Fecha_maxima_de_devolucion,
                            FechaDeDevolucion = p.Fecha_de_devolucion,
                            Nombres = u.Nombres,
                            Descripcion = d.Descripcion
                        };

            var lst = query.ToList();
            return View(lst);
        }

        //FORMULARIO DE PRESTAMOS CODIGO
        public ActionResult FormularioPrestamo()
        {
            ViewBag.Prestamos = db.tbl_Tipos_de_prestamos.ToList(); //SE ENVIAN LOS VIEBAGS AL FORMULARIO DE PRESTAMOS PARA PODER METER LOS ID DE PRESTAMOS Y USUARIOS EN UN COMBOBOX
            ViewBag.Usuarios = db.tbl_Usuarios.ToList();
            return View();
        }
        
        //GUARDAR PRESTAMOS CODIGO
        public JsonResult guardarPrestamo(DateTime FECHADESALIDA, DateTime FECHAMAXDEV, DateTime FECHADEV, int IDUSUER, int IDTP)
        {
            tbl_Prestamos d = new tbl_Prestamos();
            d.Fecha_de_Salida = FECHADESALIDA;
            d.Fecha_maxima_de_devolucion = FECHAMAXDEV;
            d.Fecha_de_devolucion = FECHADEV;
            d.id_Usuarios = IDUSUER;
            d.id_Tipos_de_prestamos = IDTP;
            db.tbl_Prestamos.Add(d);
            db.SaveChanges();
            return Json("");
        }

        //EDITAR PRESTAMOS CODIGOS
        public ActionResult EditarPrestamo()
        {
            ViewBag.Prestamos = db.tbl_Tipos_de_prestamos.ToList();
            ViewBag.Usuarios = db.tbl_Usuarios.ToList();
            var lst = db.tbl_Prestamos.ToList();
            return View(lst);
        }


        //LINEA DE CODIGO PARA OBTENER LA LISTA DE PRESTAMOS EN EL FORMULARIO DE EDITAR
        public ActionResult GetPrestamo(int id)
        {
            // Busca el empleado correspondiente en tu modelo de datos
            tbl_Prestamos prestamo = db.tbl_Prestamos.Find(id);

            // Si el empleado no se encuentra, devuelve un error
            if (prestamo == null)
            {
                return HttpNotFound();
            }

            // Crea un objeto anónimo con los datos del empleado y devuelve una respuesta JSON
            var prestamoJson = new
            {
                id_Prestamo = prestamo.id_Prestamo,
                Fecha_de_Salida = prestamo.Fecha_de_Salida,
                Fecha_maxima_de_devolucion = prestamo.Fecha_maxima_de_devolucion,
                Fecha_de_devolucion = prestamo.Fecha_de_devolucion,
                id_Usuarios = prestamo.id_Usuarios,
                id_Tipos_de_prestamos = prestamo.id_Tipos_de_prestamos
            };
            return Json(prestamoJson, JsonRequestBehavior.AllowGet);
        }

        //LINEA DE CODIGO PARA SALVAL LOS CAMPOS EDITADOS EN EL FORMULARIO DE PRESTAMOS
        public JsonResult SaveEditedPrestamo(int id, DateTime FECHASAL, DateTime FECHAMAXDEV, DateTime FECHADEV,
            int IDUSER, int IDTIPOPRES)
        {
            if (id != null)
            {
                tbl_Prestamos emp = db.tbl_Prestamos.Find(id);

                emp.Fecha_de_Salida = FECHASAL;
                emp.Fecha_maxima_de_devolucion = FECHAMAXDEV;
                emp.Fecha_de_devolucion = FECHADEV;
                emp.id_Usuarios = IDUSER;
                emp.id_Tipos_de_prestamos = IDTIPOPRES;
                

                db.SaveChanges();
            }
            return Json("");
        }

        //LINEA DE CODIGO PARA BORRAR UN PRESTAMO SELECCIONADO
        public ActionResult DeletePrestamo(int id)
        {
            var tipo = db.tbl_Prestamos.Find(id);
            if (tipo == null)
            {
                return HttpNotFound();
            }
            db.tbl_Prestamos.Remove(tipo);
            db.SaveChanges();
            return Json("");
        }
    }
}
