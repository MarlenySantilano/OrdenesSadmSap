﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrdenesSadm2.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class OrdenReporteEntities1 : DbContext
    {
        public OrdenReporteEntities1()
            : base("name=OrdenReporteEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Modulo> Moduloes { get; set; }
        public virtual DbSet<Operacione> Operaciones { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<RolOperacion> RolOperacions { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    
        public virtual int SP_Delete_Usuario(Nullable<int> id_value)
        {
            var id_valueParameter = id_value.HasValue ?
                new ObjectParameter("id_value", id_value) :
                new ObjectParameter("id_value", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Delete_Usuario", id_valueParameter);
        }
    
        public virtual int SP_Insert_Usuario(string nombre_val, string email_val, string password)
        {
            var nombre_valParameter = nombre_val != null ?
                new ObjectParameter("nombre_val", nombre_val) :
                new ObjectParameter("nombre_val", typeof(string));
    
            var email_valParameter = email_val != null ?
                new ObjectParameter("email_val", email_val) :
                new ObjectParameter("email_val", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_Insert_Usuario", nombre_valParameter, email_valParameter, passwordParameter);
        }
    
        public virtual ObjectResult<SP_Select_Usuarios_Result> SP_Select_Usuarios()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Select_Usuarios_Result>("SP_Select_Usuarios");
        }
    
        public virtual ObjectResult<SP_Select_Usuarios_Detalle_Result> SP_Select_Usuarios_Detalle(Nullable<int> id_value)
        {
            var id_valueParameter = id_value.HasValue ?
                new ObjectParameter("id_value", id_value) :
                new ObjectParameter("id_value", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Select_Usuarios_Detalle_Result>("SP_Select_Usuarios_Detalle", id_valueParameter);
        }
    
        public virtual ObjectResult<SP_Update_Usuario_Result> SP_Update_Usuario(Nullable<int> id_value, string nombre_value, string email_value, string password_value)
        {
            var id_valueParameter = id_value.HasValue ?
                new ObjectParameter("id_value", id_value) :
                new ObjectParameter("id_value", typeof(int));
    
            var nombre_valueParameter = nombre_value != null ?
                new ObjectParameter("nombre_value", nombre_value) :
                new ObjectParameter("nombre_value", typeof(string));
    
            var email_valueParameter = email_value != null ?
                new ObjectParameter("email_value", email_value) :
                new ObjectParameter("email_value", typeof(string));
    
            var password_valueParameter = password_value != null ?
                new ObjectParameter("password_value", password_value) :
                new ObjectParameter("password_value", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Update_Usuario_Result>("SP_Update_Usuario", id_valueParameter, nombre_valueParameter, email_valueParameter, password_valueParameter);
        }
    }
}
