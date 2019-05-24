using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppEnviosREST.Models
{
    public class ce_envios
    {
        public int IdEnvios { get; set; }
        public int IdVenta { get; set; }
        [StringLength(20)]
        public string CodigoRastreo { get; set; }
        [StringLength(20)]
        public string IdPersonaQuienEnvia { get; set; }
        public int IdDomicilioEntrega { get; set; }
        [StringLength(50)]
        public string NombreQuienRecibe { get; set; }
        [StringLength(20)]
        public string TelefonoQuienRecibe { get; set; }
        public int NumPaquetes { get; set; }

        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        public ce_cat_mensajerias ce_cat_mensajerias { get; set; }

        public int IdMensajeria { get; set; }
    }

        public class ce_cat_mensajerias
        {
            public int IdMensajeria { get; set; }
            [StringLength(20)]
            public string DesMensajeria { get; set; }
            public ce_tipo_mensajeria ce_tipo_mensajeria { get; set; }
            public int IdTipoMensajeria { get; set; }
            public int IdDomicilio { get; set; }

            [StringLength(1)]
            public string Activo { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
            public Nullable<DateTime> FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }
        }


        public class ce_envios_estatus
        {
            public int IdStatus { get; set; }
        public ce_envios ce_envios { get; set; }
        public int IdEnvios { get; set; }
            [StringLength(50)]
            public string Actual { get; set; }
            [StringLength(255)]
            public string Observacion { get; set; }

            [StringLength(1)]
            public string Activo { get; set; }
            [StringLength(1)]
            public string Borrado { get; set; }
            public Nullable<DateTime> FechaReg { get; set; }
            [StringLength(20)]
            public string UsuarioReg { get; set; }
            public Nullable<DateTime> FechaUltMod { get; set; }
            [StringLength(20)]
            public string UsuarioMod { get; set; }


        }

        public class ce_tipo_mensajeria
        {
            public int IdTipoMensajeria { get; set; }
            [StringLength(20)]
            public string Tipo { get; set; }
            [StringLength(50)]
            public string TiempoDeEnvio { get; set; }
            [StringLength(1)]
            public string nacional { get; set; }
            [StringLength(1)]
            public string internacional { get; set; }

        }
        public class FicModEnvios
        {

        }
    }

