using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppEnviosREST.Models;
using Microsoft.EntityFrameworkCore;
namespace AppEnviosREST.Data
{
    public class FicDBContext : DbContext
    {
        public FicDBContext(DbContextOptions<FicDBContext> options)
            : base(options)
        {

        }//constructor

        protected async override void OnConfiguring(DbContextOptionsBuilder FicPaOptionsBuilder)
        {
            try
            {

            }
            catch (Exception e)
            {

            }
        }//CONFIGURACION DE LA CONEXION || OnConfiguring 
        #region ENVIOS
        public DbSet<ce_envios> ce_envios { get; set; }
            public DbSet<ce_cat_mensajerias> ce_cat_mensajerias { get; set; }
            public DbSet<ce_envios_estatus> ce_envios_estatus { get; set; }
            public DbSet<ce_tipo_mensajeria> ce_tipo_mensajeria { get; set; }
        #endregion
        protected async override void OnModelCreating(ModelBuilder modelBuilder)
            {
                try
                {
                    #region ENVIOS
                    //CREACION DE LLAVES PRIMARIAS
                    modelBuilder.Entity<ce_envios>()
                        .HasKey(c => new { c.IdEnvios });

                    modelBuilder.Entity<ce_cat_mensajerias>()
                        .HasKey(c => new { c.IdMensajeria });

                    modelBuilder.Entity<ce_envios_estatus>()
                        .HasKey(c => new { c.IdStatus, c.IdEnvios });

                    modelBuilder.Entity<ce_tipo_mensajeria>()
                        .HasKey(c => new { c.IdTipoMensajeria });


                    /*CREACION DE LLAVES FORANEAS*/
                    modelBuilder.Entity<ce_envios>()
                    .HasOne(s => s.ce_cat_mensajerias).
                    WithMany().HasForeignKey(s => new { s.IdMensajeria });


                    modelBuilder.Entity<ce_envios_estatus>()
                    .HasOne(s => s.ce_envios).
                    WithMany().HasForeignKey(s => new { s.IdEnvios });

                    modelBuilder.Entity<ce_cat_mensajerias>()
                    .HasOne(s => s.ce_tipo_mensajeria).
                    WithMany().HasForeignKey(s => new { s.IdTipoMensajeria });

                #endregion
            }//try
            catch (Exception e) { }//catch
        }//OnModelCreating

    }//class
}