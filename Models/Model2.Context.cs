﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BibliotecaEntities : DbContext
    {
        public BibliotecaEntities()
            : base("name=BibliotecaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Checadas_Empleados> Checadas_Empleados { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }
        public virtual DbSet<Prestamo> Prestamos { get; set; }
        public virtual DbSet<Prestamos_Libros> Prestamos_Libros { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tbl_Checadas_Empleados> tbl_Checadas_Empleados { get; set; }
        public virtual DbSet<tbl_Empleados> tbl_Empleados { get; set; }
        public virtual DbSet<tbl_Libros> tbl_Libros { get; set; }
        public virtual DbSet<tbl_Prestamos> tbl_Prestamos { get; set; }
        public virtual DbSet<tbl_Prestamos_Libros> tbl_Prestamos_Libros { get; set; }
        public virtual DbSet<tbl_Tipos_de_prestamos> tbl_Tipos_de_prestamos { get; set; }
        public virtual DbSet<tbl_Tipos_Libros> tbl_Tipos_Libros { get; set; }
        public virtual DbSet<tbl_Usuarios> tbl_Usuarios { get; set; }
        public virtual DbSet<tbl_Venta_Libros> tbl_Venta_Libros { get; set; }
        public virtual DbSet<tbl_Ventas> tbl_Ventas { get; set; }
        public virtual DbSet<Tipos_de_prestamos> Tipos_de_prestamos { get; set; }
        public virtual DbSet<Tipos_Libros> Tipos_Libros { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Venta_Libros> Venta_Libros { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }
    }
}