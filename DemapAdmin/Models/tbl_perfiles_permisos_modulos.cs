//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemapAdmin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_perfiles_permisos_modulos
    {
        public int Id { get; set; }
        public Nullable<int> PerfilUsuarioID { get; set; }
        public Nullable<int> ModuloID { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string CreadoPor { get; set; }
        public Nullable<byte> Activo { get; set; }
    
        public virtual tbl_modulos tbl_modulos { get; set; }
        public virtual tbl_perfiles_usuarios tbl_perfiles_usuarios { get; set; }
    }
}