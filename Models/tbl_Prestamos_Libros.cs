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
    
    public partial class tbl_Prestamos_Libros
    {
        public int id_Prestamos_Libros { get; set; }
        public Nullable<int> id_Libro { get; set; }
        public Nullable<int> id_Prestamo { get; set; }
    
        public virtual tbl_Libros tbl_Libros { get; set; }
        public virtual tbl_Prestamos tbl_Prestamos { get; set; }
    }
}
