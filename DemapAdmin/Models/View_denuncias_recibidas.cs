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
    
    public partial class View_denuncias_recibidas
    {
        public int Id { get; set; }
        public string CedulaDenunciante { get; set; }
        public string Producto { get; set; }
        public string Establecimiento { get; set; }
        public string Estado { get; set; }
        public string ImagenDenuncia { get; set; }
        public string VideoDenuncia { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string TipoProducto { get; set; }
        public string RegistroSanitario { get; set; }
    }
}
