//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MV_P1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Prestamo
    {
        public int id_Prestamo { get; set; }
        public Nullable<System.DateTime> Fecha_de_Salida { get; set; }
        public Nullable<System.DateTime> Fecha_maxima_de_devolucion { get; set; }
        public Nullable<System.DateTime> Fecha_de_devolucion { get; set; }
        public Nullable<int> id_Prestamos_Libros { get; set; }
        public Nullable<int> id_Usuarios { get; set; }
        public Nullable<int> id_Tipos_de_prestamos { get; set; }
    
        public virtual Prestamos_Libros Prestamos_Libros { get; set; }
        public virtual Tipos_de_prestamos Tipos_de_prestamos { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}