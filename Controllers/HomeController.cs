﻿using MV_P1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Security.Policy;
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


        // LIBROS

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
        public ActionResult EditarLibros()
        {
            var lst = db.tbl_Libros.ToList();
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


        // CHECADAS EMPLEADOS

        public ActionResult listaChecadasEmpleados()
        {
            var lst = db.tbl_Checadas_Empleados.ToList();
            return View(lst);
        }
        public ActionResult FormularioChecadasEmpleados()
        {
            return View();
        }
        public ActionResult EditarChecadasEmpleados()
        {
            var lst = db.tbl_Checadas_Empleados.ToList();
            return View(lst);
        }
        public JsonResult guardarChecadas(/* int id_Checadas_empleados, */ DateTime Fecha, TimeSpan Entrada, TimeSpan Salida, int id_Empleados)
        {
            tbl_Checadas_Empleados b = new tbl_Checadas_Empleados();
            // b.id_Checadas_empleados = id_Checadas_empleados;
            b.Fecha = Fecha;
            b.Entrada = Entrada;
            b.Salida = Salida;
            b.id_Empleados = id_Empleados;
            db.tbl_Checadas_Empleados.Add(b);
            db.SaveChanges();
            return Json("");
        }

        public ActionResult DeleteChecadaEmpleado(int id)
        {
            var checada = db.tbl_Checadas_Empleados.Find(id);
            if (checada == null)
            {
                return HttpNotFound();
            }
            db.tbl_Checadas_Empleados.Remove(checada);
            db.SaveChanges();
            return Json("");
        }

        public ActionResult GetChecadaEmpleado(int id)
        {
            // Busca el empleado correspondiente en tu modelo de datos
            tbl_Checadas_Empleados checada = db.tbl_Checadas_Empleados.Find(id);

            // Si el empleado no se encuentra, devuelve un error
            if (checada == null)
            {
                return HttpNotFound();
            }

            // Crea un objeto anónimo con los datos del empleado y devuelve una respuesta JSON
            var checadaJson = new
            {
                id_Checadas_empleados = checada.id_Checadas_empleados,
                Fecha = checada.Fecha,
                Entrada = checada.Entrada,
                Salida = checada.Salida,
                id_Empleados = checada.id_Empleados
            };
            return Json(checadaJson, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveEditedChecada(int id_Checadas_empleados, DateTime Fecha, TimeSpan Entrada, TimeSpan Salida, int id_Empleados)
        {
            if (id_Checadas_empleados != null)
            {
                tbl_Checadas_Empleados checada = db.tbl_Checadas_Empleados.Find(id_Checadas_empleados);

                checada.id_Checadas_empleados = id_Checadas_empleados;
                checada.Fecha = Fecha;
                checada.Entrada = Entrada;
                checada.Salida = Salida;
                checada.id_Empleados = id_Empleados;

                db.SaveChanges();
            }
            return Json("");
        }


        // EMPLEADOS

        public ActionResult listaEmpleados()
        {
            var lst = db.tbl_Empleados.ToList();
            return View(lst);
        }
        public ActionResult FormularioEmpleados()
        {
            return View();
        }
        public ActionResult EditarEmpleado()
        {
            var lst = db.tbl_Empleados.ToList();
            return View(lst);
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


        // TIPOS LIBROS

        public ActionResult listaTiposLibros()
        {
            var lst = db.tbl_Tipos_Libros.ToList();
            return View(lst);
        }
        public ActionResult FormularioTiposLibros()
        {
            return View();
        }
        public ActionResult EditarTiposLibros()
        {
            var lst = db.tbl_Tipos_Libros.ToList();
            return View(lst);
        }
        public JsonResult guardarTipoLibros(/* int IdTiposLibros, */ string EstanteLibros, string TematicaLibros)
        {
            tbl_Tipos_Libros d = new tbl_Tipos_Libros();
            // d.id_TipoLibro = IdTiposLibros;
            d.Estante = EstanteLibros;
            d.Tematica = TematicaLibros;
            db.tbl_Tipos_Libros.Add(d);
            db.SaveChanges();
            return Json("");
        }

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

        // VENTAS

        public ActionResult FormularioVentas() 
        {
            return View();
        }

        public ActionResult listaVentas()
        {
            var lst = db.tbl_Ventas.ToList();
            return View(lst);
        }

        public ActionResult EditarVentas()
        {
            var lst = db.tbl_Ventas.ToList();
            return View(lst);
        }
        
        public JsonResult guardarVentas(/* int idVentaLibro,*/ int Total, DateTime Fecha, TimeSpan Hora, int idEmpleado) 
        {
            tbl_Ventas d = new tbl_Ventas();

            // d.id_Venta = idVentaLibro;
            d.Total = Total;
            d.Fecha = Fecha;
            d.Hora = Hora;
            d.id_Empleados = idEmpleado;

            db.tbl_Ventas.Add(d);
            db.SaveChanges();
            
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

        public ActionResult GetVenta(int id)
        {
            // Busca el empleado correspondiente en tu modelo de datos
            tbl_Ventas venta = db.tbl_Ventas.Find(id);

            // Si el empleado no se encuentra, devuelve un error
            if (venta == null)
            {
                return HttpNotFound();
            }

            // Crea un objeto anónimo con los datos del empleado y devuelve una respuesta JSON
            var ventaJson = new
            {
                id_Venta = venta.id_Venta,
                Total = venta.Total,
                Fecha = venta.Fecha,
                Hora = venta.Hora,
                id_Empleados = venta.id_Empleados
            };
            return Json(ventaJson, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveEditedVenta(int idVenta, int Total, DateTime Fecha, TimeSpan Hora, int idEmpleado)
        {
            if (idVenta != null)
            {
                tbl_Ventas venta = db.tbl_Ventas.Find(idVenta);

                venta.id_Venta = idVenta;
                venta.Total = Total;
                venta.Fecha = Fecha;
                venta.Hora = Hora;
                venta.id_Empleados = idEmpleado;

                db.SaveChanges();
            }
            return Json("");
        }


        // USUARIOS

        public ActionResult FormularioUsuarios()
        {
            return View();
        }

        public ActionResult listaUsuarios()
        {
            var lst = db.tbl_Usuarios.ToList();
            return View(lst);
        }

        public ActionResult EditarUsuarios()
        {
            var lst = db.tbl_Usuarios.ToList();
            return View(lst);
        }

        public JsonResult guardarUsuarios(string Nombres, string Apellidos, string DNI, string Domicilio, DateTime FechaNacimiento)
        {
            tbl_Usuarios user = new tbl_Usuarios();

            user.Nombres = Nombres;
            user.Apellidos = Apellidos;
            user.DNI = DNI;
            user.Domicilio = Domicilio;
            user.Fecha_de_nacimiento = FechaNacimiento;

            db.tbl_Usuarios.Add(user);
            db.SaveChanges();

            return Json("");
        }

        public ActionResult DeleteUsuarios(int id)
        {
            var user = db.tbl_Usuarios.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            db.tbl_Usuarios.Remove(user);
            db.SaveChanges();
            return Json("");
        }

        public ActionResult GetUsuarios(int id)
        {
            // Busca el usuario correspondiente en tu modelo de datos
            tbl_Usuarios user = db.tbl_Usuarios.Find(id);

            // Si el usuario no se encuentra, devuelve un error
            if (user == null)
            {
                return HttpNotFound();
            }

            // Crea un objeto anónimo con los datos del usuario y devuelve una respuesta JSON
            var userJson = new
            {
                id_Usuarios = user.id_Usuarios,
                Nombres = user.Nombres,
                Apellidos = user.Apellidos,
                DNI = user.DNI,
                Domicilio = user.Domicilio,
                FechaNac = user.Fecha_de_nacimiento
            };
            return Json(userJson, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveEditedUsuarios(int id_Usuarios, string Nombres, string Apellidos, string DNI, string Domicilio, DateTime FechaNacimiento)
        {
            if (id_Usuarios != null)
            {
                tbl_Usuarios user = db.tbl_Usuarios.Find(id_Usuarios);

                user.id_Usuarios = id_Usuarios;
                user.Nombres = Nombres;
                user.Apellidos = Apellidos;
                user.DNI = DNI;
                user.Domicilio = Domicilio;
                user.Fecha_de_nacimiento = FechaNacimiento;

                db.SaveChanges();
            }
            return Json("");
        }


        // PRESTAMO

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

        public ActionResult EditarPrestamo()
        {
            var lst = db.tbl_Prestamos.ToList();
            return View(lst);
        }

        public JsonResult guardarPrestamo(DateTime FechaSal, DateTime FechaMaxDev, DateTime FechaDev, int idUsuario, int idTipoPrestamo)
        {
            tbl_Prestamos d = new tbl_Prestamos();
            d.Fecha_de_Salida = FechaSal;
            d.Fecha_maxima_de_devolucion = FechaMaxDev;
            d.Fecha_de_devolucion = FechaDev;
            d.id_Usuarios = idUsuario;
            d.id_Tipos_de_prestamos = idTipoPrestamo;
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
            // Busca el prestamo correspondiente en tu modelo de datos
            tbl_Prestamos prestamo = db.tbl_Prestamos.Find(id);

            // Si el prestamo no se encuentra, devuelve un error
            if (prestamo == null)
            {
                return HttpNotFound();
            }

            // Crea un objeto anónimo con los datos del libro y devuelve una respuesta JSON
            var prestamoJson = new
            {
                id_Prestamo = prestamo.id_Prestamo,
                FechaSal = prestamo.Fecha_de_Salida,
                FechaMaxDev = prestamo.Fecha_maxima_de_devolucion,
                FechaDev = prestamo.Fecha_de_devolucion,
                idUsuario = prestamo.id_Usuarios,
                idTipoPrestamo = prestamo.id_Tipos_de_prestamos,
            };
            return Json(prestamoJson, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveEditedPrestamo(int id_Prestamo, DateTime FechaSal, DateTime FechaMaxDev, DateTime FechaDev, int idUsuario, int idTipoPrestamo)
        {
            if (id_Prestamo != null)
            {
                tbl_Prestamos prestamos = db.tbl_Prestamos.Find(id_Prestamo);

                prestamos.id_Prestamo = id_Prestamo;
                prestamos.Fecha_de_Salida = FechaSal;
                prestamos.Fecha_maxima_de_devolucion = FechaMaxDev;
                prestamos.Fecha_de_devolucion = FechaDev;
                prestamos.id_Usuarios = idUsuario;
                prestamos.id_Tipos_de_prestamos = idTipoPrestamo;

                db.SaveChanges();
            }
            return Json("");
        }


        // REPORTES

        public ActionResult Reportes()
        {
            return View();
        }

        public JsonResult getReporte(string tipoReporte, DateTime fechaInicio, DateTime fechaFinal)
        {
            switch (tipoReporte)
            {
                case "ventas":
                    var reporteVentas = from v in db.tbl_Ventas
                                        where v.Fecha >= fechaInicio && v.Fecha <= fechaFinal
                                        select new
                                        {
                                            // Select only the columns that you need to avoid circular reference errors during the creation of this json object
                                            id_Venta = v.id_Venta.ToString(),
                                            Total = v.Total,
                                            Fecha = v.Fecha,
                                            Hora = v.Hora,
                                            id_Empleado = v.id_Empleados.ToString(),
                                        };

                    return Json(reporteVentas, JsonRequestBehavior.AllowGet);

                case "prestamos":
                    break;
            }
            return Json("");
        }
    }
}
