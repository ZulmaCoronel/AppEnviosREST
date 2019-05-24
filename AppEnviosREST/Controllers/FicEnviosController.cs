using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppEnviosREST.Models;
using AppEnviosREST.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace AppEnviosREST.Controllers
{
    [Produces("application/json")]
    //[Route("api/[controller]")]
    //  [ApiController]
    public class FicEnviosController : Controller
    {
        private readonly FicDBContext FicLoDBContext;

        public FicEnviosController(FicDBContext FicPaDBContext)
        {
            FicLoDBContext = FicPaDBContext;
        }//constructor


        //------------------------------------------------------------------METODOS GET------------------------------------------------------------------------------------------

                            //----------------------------Envios---------------------
        [HttpGet]
        [Route("api/envios/getid")]
        public async Task<IActionResult> FicApiGetListEnvios([FromQuery]int envio)
        {
            var ce_envios = (from data_envios in FicLoDBContext.ce_envios where data_envios.IdEnvios == envio select data_envios).ToList();

            if (ce_envios.Count() > 0)
            {
                ce_envios = ce_envios.ToList();
                return Ok(ce_envios);
            }
            else
            {
                ce_envios = ce_envios.ToList();
                return Ok(ce_envios);
            }
        }//FicApiGetListEnvios

        [HttpGet]
        [Route("api/envios/getcodigo")]
        public async Task<IActionResult> FicApiGetListEnvios([FromQuery]string codigo)
        {
            var ce_envios = (from data_codigos in FicLoDBContext.ce_envios where data_codigos.CodigoRastreo == codigo select data_codigos).ToList();

            if (ce_envios.Count() > 0)
            {
                ce_envios = ce_envios.ToList();
                return Ok(ce_envios);
            }
            else
            {
                ce_envios = ce_envios.ToList();
                return Ok(ce_envios);
            }
        }//FicApiGetListEnvios

        [HttpGet]
        [Route("api/envios/getall")]
        public ContentResult FicGetListCatEdificiosEspacios()
        {
            var FicResult2 = from FicCED in FicLoDBContext.ce_envios
                             select new
                             {
                                 FicCED.IdEnvios,
                                 FicCED.IdVenta,
                                 FicCED.CodigoRastreo,
                                 FicCED.IdDomicilioEntrega,
                                 FicCED.IdPersonaQuienEnvia,
                                 FicCED.NombreQuienRecibe,
                                 FicCED.TelefonoQuienRecibe,
                                 FicCED.NumPaquetes,
                                 FicCED.FechaReg,
                                 FicCED.UsuarioReg,
                                 FicCED.FechaUltMod,
                                 FicCED.UsuarioMod,
                                 FicCED.Activo,
                                 FicCED.Borrado,
                                 FicCED.IdMensajeria
                             };

            String FicSerializa = JsonConvert.SerializeObject(FicResult2);

            return Content(FicSerializa, "application/json");
        }

                         //----------------------Catalogo Mensajeria------------------
        [HttpGet]
        [Route("api/envios/getmensajeria")]
        public async Task<IActionResult> FicApiGetListEnviosCat([FromQuery]int mensajeria)
        {
            var ce_cat_mensajeria = (from data_mensajeria in FicLoDBContext.ce_cat_mensajerias where data_mensajeria.IdMensajeria == mensajeria select data_mensajeria).ToList();

            if (ce_cat_mensajeria.Count() > 0)
            {
                ce_cat_mensajeria = ce_cat_mensajeria.ToList();
                return Ok(ce_cat_mensajeria);
            }
            else
            {
                ce_cat_mensajeria = ce_cat_mensajeria.ToList();
                return Ok(ce_cat_mensajeria);
            }
        }//FicApiGetListEnvios

        [HttpGet]
        [Route("api/envios/getallmensajeria")]
        public ContentResult FicGetListCatEnvios()
        {
            var FicResult2 = from FicCED in FicLoDBContext.ce_cat_mensajerias
                             select new
                             {
                                 FicCED.IdMensajeria,
                                 FicCED.DesMensajeria,
                                 FicCED.IdTipoMensajeria,
                                 FicCED.IdDomicilio,
                                 FicCED.FechaReg,
                                 FicCED.UsuarioReg,
                                 FicCED.FechaUltMod,
                                 FicCED.UsuarioMod,
                                 FicCED.Activo,
                                 FicCED.Borrado
                             };
            String FicSerializa = JsonConvert.SerializeObject(FicResult2);

            return Content(FicSerializa, "application/json");
        }

        [HttpGet]
        [Route("api/envios/getdesmensajeria")]
        public async Task<IActionResult> FicApiGetEnvios ([FromQuery]String desmensajeria)
        {
            var ce_cat_mensajeria = (from data_mensajeria in FicLoDBContext.ce_cat_mensajerias where data_mensajeria.DesMensajeria == desmensajeria select data_mensajeria).ToList();

            if (ce_cat_mensajeria.Count() > 0)
            {
                ce_cat_mensajeria = ce_cat_mensajeria.ToList();
                return Ok(ce_cat_mensajeria);
            }
            else
            {
                ce_cat_mensajeria = ce_cat_mensajeria.ToList();
                return Ok(ce_cat_mensajeria);
            }
        }//FicApiGetListEnvios

                            //------------------Detalle Estatus----------------------------
        [HttpGet]
        [Route("api/envios/getestatus")]
        public async Task<IActionResult> FicApiGetListEnviosEstatus([FromQuery]int estatus)
        {
            var ce_envios_estatus = (from data_estatus in FicLoDBContext.ce_envios_estatus where data_estatus.IdStatus == estatus select data_estatus).ToList();

            if (ce_envios_estatus.Count() > 0)
            {
                ce_envios_estatus = ce_envios_estatus.ToList();
                return Ok(ce_envios_estatus);
            }
            else
            {
                ce_envios_estatus = ce_envios_estatus.ToList();
                return Ok(ce_envios_estatus);
            }
        }//FicApiGetListEnvios

        [HttpGet]
        [Route("api/envios/getallestatus")]
        public ContentResult FicGetListCatEnviosEstatus()
        {
            var FicResult2 = from FicCED in FicLoDBContext.ce_envios_estatus
                             select new
                             {
                                 FicCED.IdStatus,
                                 FicCED.IdEnvios,
                                 FicCED.Actual,
                                 FicCED.Observacion,
                                 FicCED.Activo,
                                 FicCED.Borrado,
                                 FicCED.FechaReg,
                                 FicCED.UsuarioReg,
                                 FicCED.FechaUltMod,
                                 FicCED.UsuarioMod,
                             };

            String FicSerializa = JsonConvert.SerializeObject(FicResult2);

            return Content(FicSerializa, "application/json");
        }


                            //---------------------Tipo Mensajeria---------------------------
        [HttpGet]
        [Route("api/envios/getipomensajeria")]
        public async Task<IActionResult> FicApiGetListEnviosTipoMens([FromQuery]int tipomen)
        {
            var ce_tipo_mensajeria = (from data_tipomen in FicLoDBContext.ce_tipo_mensajeria where data_tipomen.IdTipoMensajeria == tipomen select data_tipomen).ToList();

            if (ce_tipo_mensajeria.Count() > 0)
            {
                ce_tipo_mensajeria = ce_tipo_mensajeria.ToList();
                return Ok(ce_tipo_mensajeria);
            }
            else
            {
                ce_tipo_mensajeria = ce_tipo_mensajeria.ToList();
                return Ok(ce_tipo_mensajeria);
            }
        }//FicApiGetListEnvios

        [HttpGet]
        [Route("api/envios/getalltipo")]
        public ContentResult FicGetListCatTipoMensajeria()
        {
            var FicResult2 = from FicCED in FicLoDBContext.ce_tipo_mensajeria
                             select new
                             {
                                 FicCED.IdTipoMensajeria,
                                 FicCED.Tipo,
                                 FicCED.TiempoDeEnvio,
                                 FicCED.nacional,
                                 FicCED.internacional
                             };

            String FicSerializa = JsonConvert.SerializeObject(FicResult2);

            return Content(FicSerializa, "application/json");
        }



        //--------------------------------------------------------------------METODOS POST-----------------------------------------------------------------------------------------------
        //--------------------Envios---------------------------------
       [HttpPost]
       [Route ("api/envios/agregar")]
       public async Task<IActionResult> AgregarEnvio([FromBody] ce_envios envio)
        {
            if (ModelState.IsValid)
            {
                FicLoDBContext.ce_envios.Add(envio);
                FicLoDBContext.SaveChanges();
                return Ok(envio);
            }
            else
            {
                return BadRequest();
            }
        }

        //-------------------------Mensajeria----------------------------
        [HttpPost]
        [Route("api/envios/menpost")]
        public async Task<IActionResult> PostMensajeria([FromBody] ce_cat_mensajerias mensajeria )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FicLoDBContext.ce_cat_mensajerias.Add(mensajeria);
            await FicLoDBContext.SaveChangesAsync();

            return CreatedAtAction("GetDA", new { id = mensajeria.IdMensajeria }, mensajeria);
        }
        private bool DatoExis(int id)
        {
            return FicLoDBContext.ce_cat_mensajerias.Any(e => e.IdMensajeria == id);
        }

        //--------------------------Tipo---------------------------------

        [HttpPost]
        [Route("api/envios/tipopost")]
        public async Task<IActionResult> PostTipoMensajeria([FromBody] ce_tipo_mensajeria tipomensajeria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FicLoDBContext.ce_tipo_mensajeria.Add(tipomensajeria);
            await FicLoDBContext.SaveChangesAsync();

            return CreatedAtAction("GetDA", new { id = tipomensajeria.IdTipoMensajeria }, tipomensajeria);
        }
        private bool DatoExiste(int id)
        {
            return FicLoDBContext.ce_tipo_mensajeria.Any(e => e.IdTipoMensajeria == id);
        }

        //----------------------Estatus--------------------------------------
        [HttpPost]
        [Route("api/envios/estatuspost")]
        public async Task<IActionResult> PostEstatus([FromBody] ce_envios_estatus estatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FicLoDBContext.ce_envios_estatus.Add(estatus);
            await FicLoDBContext.SaveChangesAsync();

            return CreatedAtAction("GetDA", new { id = estatus.IdStatus }, estatus);
        }
        private bool DatoExisten(int id)
        {
            return FicLoDBContext.ce_envios_estatus.Any(e => e.IdStatus == id);
        }

        //----------------------------------------------------------------------------METODOS PUT----------------------------------------------------------------------------------------
            //-------ENVIOS----------
         [HttpPut]
         [Route("api/envios/put/{id}")]
         public async Task<IActionResult> ActualizarEnvio([FromRoute]int id,[FromBody] ce_envios envi)
        {
            if (ModelState.IsValid)
            {
                var EnvioExiste = FicLoDBContext.ce_envios.Count(c => c.IdEnvios == id) > 0;

                if (EnvioExiste)
                {
                    FicLoDBContext.Entry(envi).State = EntityState.Modified;
                    FicLoDBContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
            
        }
        //---------MENSAJERIA---------
        [HttpPut("{id}")]
        [Route("api/envios/mensajeriaput/{id}")]
        public async Task<IActionResult> PutDatos([FromRoute] int id, [FromBody] ce_cat_mensajerias mensaje )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mensaje.IdMensajeria)
            {
                return BadRequest();
            }

            FicLoDBContext.Entry(mensaje).State = EntityState.Modified;


            try
            {
                await FicLoDBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatoExiste(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(mensaje);
        }

        //------TIPO_MENSAJERIA----------------
        [HttpPut]
        [Route("api/envios/tiposmensajeriaput/{id}")]
        public async Task<IActionResult> ActualizarMensajeria([FromRoute]int id, [FromBody] ce_tipo_mensajeria envios)
        {
            if (ModelState.IsValid)
            {
                var EnvioExiste = FicLoDBContext.ce_tipo_mensajeria.Count(c => c.IdTipoMensajeria == id) > 0;

                if (EnvioExiste)
                {
                    FicLoDBContext.Entry(envios).State = EntityState.Modified;
                    FicLoDBContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }

        }

        //-------ESTATUS------
        [HttpPut("{id}")]
        [Route("api/envios/estatusput/{id}")]
        public async Task<IActionResult> PutDat([FromRoute] int id, [FromBody] ce_envios_estatus envEstatus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != envEstatus.IdStatus)
            {
                return BadRequest();
            }

            FicLoDBContext.Entry(envEstatus).State = EntityState.Modified;


            try
            {
                await FicLoDBContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatoExiste(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(envEstatus);
        }

        //---------------------------------------------------------------------METODOS DELETE--------------------------------------------------------------------------------------------
        // DELETE: ENVIOS
        [HttpDelete("{id}")]
        [Route("api/envios/delete/{id}")]
        public async Task<IActionResult> DeleteDato(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ce_envios = await FicLoDBContext.ce_envios.FirstOrDefaultAsync(m => m.IdEnvios == id);
            if (ce_envios == null)
            {
                return NotFound();
            }

            FicLoDBContext.ce_envios.Remove(ce_envios);
            await FicLoDBContext.SaveChangesAsync();

            return Ok(ce_envios);

        }

        //DELETE: MENSAJERIAS
        [HttpDelete("{id}")]
        [Route("api/mensajeria/delete/{id}")]
        public async Task<IActionResult> DeleteDat(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ce_cat_mensajeria = await FicLoDBContext.ce_cat_mensajerias.FirstOrDefaultAsync(m => m.IdMensajeria == id);
            if (ce_cat_mensajeria == null)
            {
                return NotFound();
            }

            FicLoDBContext.ce_cat_mensajerias.Remove(ce_cat_mensajeria);
            await FicLoDBContext.SaveChangesAsync();

            return Ok(ce_cat_mensajeria);

        }

        //DELETE: TIPO MENSAJERIAS
        [HttpDelete("{id}")]
        [Route("api/tipomensajeria/delete/{id}")]
        public async Task<IActionResult> DeleteDatos(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ce_tipo_mensajeria = await FicLoDBContext.ce_tipo_mensajeria.FirstOrDefaultAsync(m => m.IdTipoMensajeria == id);
            if (ce_tipo_mensajeria == null)
            {
                return NotFound();
            }

            FicLoDBContext.ce_tipo_mensajeria.Remove(ce_tipo_mensajeria);
            await FicLoDBContext.SaveChangesAsync();

            return Ok(ce_tipo_mensajeria);

        }

        //DELETE: ENVIOS STATUS

        [HttpDelete("{id}")]
        [Route("api/enviosestatus/delete/{id}")]
        public async Task<IActionResult> DeletDatos(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ce_envios_estatus = await FicLoDBContext.ce_envios_estatus.FirstOrDefaultAsync(m => m.IdStatus == id);
            if (ce_envios_estatus == null)
            {
                return NotFound();
            }

            FicLoDBContext.ce_envios_estatus.Remove(ce_envios_estatus);
            await FicLoDBContext.SaveChangesAsync();

            return Ok(ce_envios_estatus);

        }

    }
}