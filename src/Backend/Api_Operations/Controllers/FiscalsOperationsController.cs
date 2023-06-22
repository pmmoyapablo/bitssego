using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Http;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Authorization;
using Api_Operations.Models;
using Api_Clients.Models;
using System.Security.Cryptography;
using System.Text;

namespace Api_Operations.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class FiscalsOperationsController : ControllerBase
    {
        private readonly OperationsContext _context;

        public FiscalsOperationsController(OperationsContext context)
        {
            _context = context;
        }

        #region GET: api/FiscalsOperations
        [HttpGet]
        public IEnumerable<FiscalOperationModel> GetSisg_FiscalsOperations()
        {
            try
            {
                foreach (FiscalOperationModel fo in _context.Sisg_FiscalsOperations.ToList())
                {      
                    fo.provider = _context.Sisg_Providers.Where(pro => pro.id == fo.ProviderId).FirstOrDefault();
                    fo.distributor = _context.Sisg_Distributors.Where(d => d.id == fo.DistributorId).FirstOrDefault();
                    fo.finalClient = _context.Sisg_FinalsClients.Where(fc => fc.id == fo.FinalClientId).FirstOrDefault();
                    fo.technician = _context.Sisg_Technicians.Where(t => t.id == fo.TechnicianId).FirstOrDefault();
                }

                return _context.Sisg_FiscalsOperations;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region GET api/FiscalsOperations/ByProviderId/1
        [HttpGet("ByProviderId/{id}")]
        public IEnumerable<FiscalOperationModel> GetFiscalOperationsByProviderId([FromRoute] int id)
        {
            try
            {
                var operations = _context.Sisg_FiscalsOperations.Where(o => o.ProviderId == id).ToList();

                foreach (FiscalOperationModel fo in operations)
                {
                    fo.provider = _context.Sisg_Providers.Where(pro => pro.id == fo.ProviderId).FirstOrDefault();
                    fo.distributor = _context.Sisg_Distributors.Where(d => d.id == fo.DistributorId).FirstOrDefault();
                    fo.finalClient = _context.Sisg_FinalsClients.Where(fc => fc.id == fo.FinalClientId).FirstOrDefault();
                    fo.technician = _context.Sisg_Technicians.Where(t => t.id == fo.TechnicianId).FirstOrDefault();
                }

                return operations;

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region GET: api/FiscalsOperations/BySerial/Z1B4444557
        [HttpGet("BySerial/{serial}")]
        public IEnumerable<FiscalOperationModel> GetSisg_FiscalsOperationsBySerial([FromRoute] string serial)
        {
            try
            {
                var operations = _context.Sisg_FiscalsOperations.Where(o => o.Serial == serial).ToList();

                foreach (FiscalOperationModel fo in operations)
                {
                    fo.provider = _context.Sisg_Providers.Where(pro => pro.id == fo.ProviderId).FirstOrDefault();
                    fo.distributor = _context.Sisg_Distributors.Where(d => d.id == fo.DistributorId).FirstOrDefault();
                    fo.finalClient = _context.Sisg_FinalsClients.Where(fc => fc.id == fo.FinalClientId).FirstOrDefault();
                    fo.technician = _context.Sisg_Technicians.Where(t => t.id == fo.TechnicianId).FirstOrDefault();
                }

                return operations;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region GET: api/FiscalsOperations/IsNewMachine/Z1B4444557
        [HttpGet("isNewMachine/{serial}")]
        public async Task<Boolean> IsNewMachine([FromRoute] string serial)
        {
            try
            {
                bool isVieja = false;
                bool hay = false;

                //Consultamos existencia Serial Vendido de Maquina Fiscal si con Modelos Viejos
                var serialfp = await _context.Sisg_SerialsProducts.Where(s => s.Serial == serial).OrderByDescending(s=> s.DateSale).FirstOrDefaultAsync();

                if(serialfp != null)
                {
                    if (serial.Substring(0,3) == "ZZA" || serial.Substring(0, 3) == "ZZB" || serial.Substring(0, 3) == "ZZC" || serial.Substring(0, 3) == "DED" || serial.Substring(0, 3) == "Z2A" || serial.Substring(0, 3) == "Z1A")
                    {   
                       isVieja = true;
                    }
                    else if(serial.Substring(0, 3) == "ZZD" || serial.Substring(0, 3) == "ZZE")
                    {
                        DateTime dateLim = Convert.ToDateTime("2013-01-01 00:00:00");

                        if (serialfp.DateSale < dateLim)
                        {
                            isVieja = true;
                        }
                    }
                }else
                {
                    return true;
                }

                if (isVieja)
                {
                    return false;
                }
                else
                {  //Verificamos si tiene antecedentes de Cambio MEFI
                    var operations = _context.Sisg_FiscalsOperations.Where(o => o.SerialRetative == serial && o.FiscalOperation == "CAMBIO MEFIS").ToList();

                    if (operations.Count > 0)
                    {
                        return false;
                    }

                    //Consultamos sus datos de operaciones Fiscalizacion  primeras positiva
                    operations = _context.Sisg_FiscalsOperations.Where(o => o.Serial == serial && o.FiscalOperation == "FISCALIZACION" && o.FiscalResult == 1).ToList();

                    if(operations.Count > 0)
                    {
                        if (operations.FirstOrDefault().FiscalMode == "REMOTO")
                        {
                            return false;
                        }
                        
                        DateTime dateToday = DateTime.Now;

                        if (dateToday.Day == operations.FirstOrDefault().Creation_Date.Day)
                        { //Verifico que hayan pasado mas de 24 horas
                            int nHours = dateToday.Hour - operations.FirstOrDefault().Creation_Date.Hour;

                            int difHours = nHours - 12;

                            if (difHours <= 24)
                            { hay = true; }
                            else
                            { hay = false; }
                        }else
                        {
                            return false;
                        }

                    }
                    else
                    {  //Para los casos de Firmwares viejos
                        var alienation = await _context.Sisg_Alienations.Where(a => a.Serial == serial).FirstOrDefaultAsync();

                        if (alienation == null)
                        { hay = true; }
                        else
                        { hay = false; }
                    }

                    return hay;
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region GET api/FiscalsOperations/FinalClient/J314310895
        [HttpGet("FinalClient/{rif}")]
        public async Task<IEnumerable<FiscalOperationModel>> GetFiscalOperationsByFinald([FromRoute] string rif)
        {
            try
            {
                var finalclient = _context.Sisg_FinalsClients.Where(fc => fc.rif == rif).FirstOrDefault();

                if (finalclient != null)
                {
                    var operations = await _context.Sisg_FiscalsOperations.Where(o => o.FinalClientId == finalclient.id).ToListAsync();

                    foreach (FiscalOperationModel fo in operations)
                    {
                        fo.provider = _context.Sisg_Providers.Where(pro => pro.id == fo.ProviderId).FirstOrDefault();
                        fo.distributor = _context.Sisg_Distributors.Where(d => d.id == fo.DistributorId).FirstOrDefault();
                        fo.finalClient = _context.Sisg_FinalsClients.Where(fc => fc.id == fo.FinalClientId).FirstOrDefault();
                        fo.technician = _context.Sisg_Technicians.Where(t => t.id == fo.TechnicianId).FirstOrDefault();
                    }

                    return operations;
                }
                else
                { //Lista Vacia
                    return new List<FiscalOperationModel>();
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }

        #endregion

        #region GET api/FiscalsOperations/Distributor/J312171197
        [HttpGet("Distributor/{rif}")]
        public async Task<IEnumerable<FiscalOperationModel>> GetFiscalOperationsByDistr([FromRoute] string rif)
        {
            try
            {
                var distributor = _context.Sisg_Distributors.Where(d => d.rif == rif).FirstOrDefault();

                if (distributor != null)
                {
                    var operations = await _context.Sisg_FiscalsOperations.Where(o => o.DistributorId == distributor.id).ToListAsync();

                    foreach (FiscalOperationModel fo in operations)
                    {
                        fo.provider = _context.Sisg_Providers.Where(pro => pro.id == fo.ProviderId).FirstOrDefault();
                        fo.distributor = _context.Sisg_Distributors.Where(d => d.id == fo.DistributorId).FirstOrDefault();
                        fo.finalClient = _context.Sisg_FinalsClients.Where(fc => fc.id == fo.FinalClientId).FirstOrDefault();
                        fo.technician = _context.Sisg_Technicians.Where(t => t.id == fo.TechnicianId).FirstOrDefault();
                    }

                    return operations;
                }
                else
                { //Lista Vacia
                    return new List<FiscalOperationModel>();
                }

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }

        #endregion

        #region GET api/FiscalsOperations/Technical/V145264614
        [HttpGet("Technical/{rif}")]
        public async Task<IEnumerable<FiscalOperationModel>> GetFiscalOperationsByTechn([FromRoute] string rif)
        {
            try
            {
                var technical = _context.Sisg_Technicians.Where(t => t.rif == rif).FirstOrDefault();

                if (technical != null)
                {
                    var operations = await _context.Sisg_FiscalsOperations.Where(o => o.TechnicianId == technical.id).ToListAsync();

                    foreach (FiscalOperationModel fo in operations)
                    {
                        fo.provider = _context.Sisg_Providers.Where(pro => pro.id == fo.ProviderId).FirstOrDefault();
                        fo.distributor = _context.Sisg_Distributors.Where(d => d.id == fo.DistributorId).FirstOrDefault();
                        fo.finalClient = _context.Sisg_FinalsClients.Where(fc => fc.id == fo.FinalClientId).FirstOrDefault();
                        fo.technician = _context.Sisg_Technicians.Where(t => t.id == fo.TechnicianId).FirstOrDefault();
                    }

                    return operations;
                }
                else
                { //Lista Vacia
                    return new List<FiscalOperationModel>();
                }

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }

        #endregion

        #region GET api/FiscalsOperations/ByDate/2020-01-01
        [HttpGet("ByDate/{date}")]
        public async Task<IEnumerable<FiscalOperationModel>> GetFiscalOperationsByDate([FromRoute] string date)
        {
            try
            {
                DateTime datePeriod = Convert.ToDateTime(date);

                var operations = await _context.Sisg_FiscalsOperations.Where(o => o.Creation_Date >= datePeriod).ToListAsync();

                if (operations != null)
                {
                    foreach (FiscalOperationModel fo in operations)
                    {
                        fo.provider = _context.Sisg_Providers.Where(pro => pro.id == fo.ProviderId).FirstOrDefault();
                        fo.distributor = _context.Sisg_Distributors.Where(d => d.id == fo.DistributorId).FirstOrDefault();
                        fo.finalClient = _context.Sisg_FinalsClients.Where(fc => fc.id == fo.FinalClientId).FirstOrDefault();
                        fo.technician = _context.Sisg_Technicians.Where(t => t.id == fo.TechnicianId).FirstOrDefault();
                    }

                    return operations;

                }
                else
                { //Lista Vacia
                    return new List<FiscalOperationModel>();
                }

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }

        #endregion

        #region GET: api/FiscalsOperations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFiscalOperationModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fiscalOper = await _context.Sisg_FiscalsOperations.FindAsync(id);

            if (fiscalOper == null)
            {
                return NotFound();
            }
            else
            {
                fiscalOper.provider = _context.Sisg_Providers.Where(pro => pro.id == fiscalOper.ProviderId).FirstOrDefault();
                fiscalOper.distributor = _context.Sisg_Distributors.Where(d => d.id == fiscalOper.DistributorId).FirstOrDefault();
                fiscalOper.finalClient = _context.Sisg_FinalsClients.Where(fc => fc.id == fiscalOper.FinalClientId).FirstOrDefault();
                fiscalOper.technician = _context.Sisg_Technicians.Where(t => t.id == fiscalOper.TechnicianId).FirstOrDefault();

                if (fiscalOper == null)
                {
                    return NotFound();
                }
            }
                return Ok(fiscalOper);
            }
        #endregion

        #region PUT: api/FiscalsOperations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFiscalOperationModel([FromRoute] int id, [FromBody] FiscalOperationModel fiscalOperationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fiscalOperationModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(fiscalOperationModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                if (fiscalOperationModel.Serial.Length == 10)
                {//Es una  Maquina Fiscal hay que enajenarla si no lo esta
                    var alienation = await _context.Sisg_Alienations.Where(a => a.Serial == fiscalOperationModel.Serial).FirstOrDefaultAsync();

                    if (alienation == null)
                    {
                        alienation = new Alienation();

                        if (fiscalOperationModel.FiscalOperation == "FISCALIZACION")
                        { alienation.Observations = "Enajenación Automatica por Fiscalización"; }
                        else
                        { alienation.Observations = "Registro de Enajenación por Desbloqueo"; }

                        alienation.Serial = fiscalOperationModel.Serial;
                        alienation.Status = "PROCESADO";
                        alienation.ProviderId = fiscalOperationModel.ProviderId;
                        alienation.DistributorId = fiscalOperationModel.DistributorId;
                        alienation.FinalClientId = fiscalOperationModel.FinalClientId;
                        alienation.AlienationDate = fiscalOperationModel.Creation_Date;
                        alienation.Creation_Date = DateTime.Now;

                        _context.Sisg_Alienations.Add(alienation);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FiscalOperationModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        #endregion

        #region POST: api/FiscalsOperations
        [HttpPost]
        public async Task<IActionResult> PostFiscalOperationModel([FromBody] ParametersOperation paramOperation)
        {
            var response = new ResponceCode();

            try {

                if(paramOperation == null)
                {
                    return BadRequest("Parametros Vacios");
                }

                FiscalOperationModel operationFiscal = new FiscalOperationModel();
                bool bandera = false;
                int autenticate = 0;

                if (paramOperation.mode == "AUXILIAR")
                {
                    autenticate = 1;
                    var technical = _context.Sisg_Technicians.Where(t => t.rif == paramOperation.rifTechnical).FirstOrDefault();

                    if(technical != null)
                    {
                        operationFiscal.TechnicianId = technical.id;
                    }
                }
                else
                {  //Verifico la Autenticacion y Status del Tecnico de Distribuidor
                    string encpass = EncrypterPassword(paramOperation.password);
                    var resultadoLogin = _context.Sisg_Users.Where(u => u.username == paramOperation.login && u.password == encpass).FirstOrDefault();
                    
                    if(resultadoLogin != null)
                    {
                        if (resultadoLogin.enable == 0)
                        {
                            autenticate = -3;
                        }
                        else
                        {
                            var resultTechnicalUser = await _context.Sisg_TechniciansUsers.Where(tu => tu.userId == resultadoLogin.id).FirstOrDefaultAsync();

                            if (resultTechnicalUser != null)
                            {
                                var technical = _context.Sisg_Technicians.Find(resultTechnicalUser.techniciansId);

                                if (technical != null)
                                {
                                    if (technical.rif.Equals(paramOperation.rifTechnical))
                                    { //Verifico el Status del Distribuidor Padre de la Maquina Fiscal
                                        var serialfp = await _context.Sisg_SerialsProducts.Where(s => s.Serial == paramOperation.serial).FirstOrDefaultAsync();

                                        if (serialfp != null)
                                        {
                                            var distributor = _context.Sisg_Distributors.Find(serialfp.DistributorId);

                                            if(distributor.enable == 0)
                                            {
                                                autenticate = -4;
                                            }else
                                            {
                                                autenticate = 1;
                                                operationFiscal.TechnicianId = technical.id;
                                            }
                                        }
                                        else
                                        {
                                            autenticate = -5;
                                        }
                                    }
                                    else
                                    {
                                        autenticate = -1;
                                    }
                                }
                                else
                                {
                                    autenticate = -1;
                                }
                            }
                        }
                    
                    }

                }

                if (autenticate > 0)
                {                   
                   // Consultamos cliente Final
                        var clientFinal = await _context.Sisg_FinalsClients.Where(cf => cf.rif == paramOperation.rifFinal).FirstOrDefaultAsync();

                        if(clientFinal == null)
                        { //Registramos al Nuevo Cliente Final
                            clientFinal = new Finalsclients();
                            clientFinal.rif = paramOperation.rifFinal;
                            clientFinal.description = paramOperation.contributorFinal;
                            clientFinal.fiscalAddress = paramOperation.addressFiscal;
                            clientFinal.creation_date = DateTime.Now;

                            _context.Sisg_FinalsClients.Add(clientFinal);
                            await _context.SaveChangesAsync();                      
                        }

                        operationFiscal.FinalClientId = clientFinal.id;

                        //Consultamos existencia Serial Vendido de Maquina Fiscal 
                        var serialfp = await _context.Sisg_SerialsProducts.Where(s => s.Serial == paramOperation.serial).FirstOrDefaultAsync();

                        if (serialfp != null)
                        {                  
                            operationFiscal.DistributorId = serialfp.DistributorId;
                            operationFiscal.ProviderId = serialfp.ProviderId;

                            //Valido Enajenacion anterior
                            bool isEna = true;
                            var alieneation = await _context.Sisg_Alienations.Where(a => a.Serial == paramOperation.serial).FirstOrDefaultAsync();

                            if (alieneation != null)
                            {
                                if (alieneation.FinalClientId != operationFiscal.FinalClientId)
                                { isEna = false; }
                            }

                            if (isEna)
                            {
                                bandera = true;
                            }
                            else
                            {
                                response.isValid = false;
                                response.codeGenerate = null;
                                response.message = "El Serial de Máquina suministrado fue enajenado previamente con otro contribuyente distinto al que colocas. Verifique su denominación o comuniquese con su proveedor.";
                            }

                        }
                        else
                        {
                            bandera = false;
                            response.isValid = false;
                            response.codeGenerate = null;
                            response.message = "El serial suministrado no esta registrado en nuestra base de datos. Verifique su denominación.";
                        }                   

                    if (bandera)
                    { //Gereramos el codigo de operacion fiscal
                        string codeEnd = this.GenerateCode(paramOperation.type, paramOperation.serial, paramOperation.precode);
                     //Registramos la Operacion en BD
                        operationFiscal.Creation_Date = DateTime.Now;
                        operationFiscal.CodeOperation = codeEnd;
                        operationFiscal.Serial = paramOperation.serial;
                        operationFiscal.InitSeal = paramOperation.iniSeal;
                        operationFiscal.FinalSeal = paramOperation.endSeal;
                        operationFiscal.FiscalAddress = paramOperation.addressFiscal;
                        operationFiscal.FiscalResult = 0;
                        operationFiscal.SerialRetative = "";
                        operationFiscal.FiscalOperation = paramOperation.type;
                        operationFiscal.FiscalMode = paramOperation.mode;

                        _context.Sisg_FiscalsOperations.Add(operationFiscal);

                        await _context.SaveChangesAsync();

                        response.isValid = true;
                        response.idOperation = operationFiscal.Id;
                        response.codeGenerate = codeEnd;
                        response.message = "Código de Operación Generado";
                    }
                }
                else if(autenticate == -1 || autenticate == 0)
                {
                    response.isValid = false;
                    response.codeGenerate = null;
                    response.message = "Usuario o clave inválida, verificar sus datos de autenticación.";
                }
                else if(autenticate == -2)
                {
                    response.isValid = false;
                    response.codeGenerate = null;
                    response.message = "Esta versión de la aplicación ha caducado. Debe descargar la nueva versión del Fiscalizador (V.3.5.9.20 o superior).";
                }
                else if(autenticate == -3)
                {
                    response.isValid = false;
                    response.codeGenerate = null;
                    response.message = "Su perfil de usuario Técnico se encuentra Inactivo para realizar operaciones fiscales. Comuniquese con su distribuidor o proveedor padre.";
                }
                else if(autenticate == -4)
                {
                    response.isValid = false;
                    response.codeGenerate = null;
                    response.message = "El representante Distribuidor que Enajenó la Máquina Fiscal se encuentra Inactivo. Comuniquese con el departamento de soporte The Factory HKA para mas información.";
                }
                else if (autenticate == -5)
                {
                    response.isValid = false;
                    response.codeGenerate = null;
                    response.message = "El serial suministrado no esta registrado en nuestra base de datos. Verifique su denominación.";
                }

                return Ok(response);
            }
            catch(Exception ex)
            {
                response.isValid = false;
                response.message = ex.Message;

                return StatusCode(500, response);
            }
        }
        #endregion

        #region POST: api/FiscalsOperations/ValidateMemfisc
        [HttpPost("ValidateMemfisc")]
        public async Task<IActionResult> PostValidateMemfisc([FromBody] ParametersMefi paramMefi)
        {
         ResponceMefi responce = new ResponceMefi();
         try {
                if (paramMefi == null)
                {
                    return BadRequest("Parametros Vacios");
                }

                bool bandera = false;
                FiscalOperationModel operationFiscal = new FiscalOperationModel();
                // Consultamos cliente Final
                var clientFinal = await _context.Sisg_FinalsClients.Where(cf => cf.rif == paramMefi.rifFinal).FirstOrDefaultAsync();

                if (clientFinal == null)
                {
                    responce.isValid = false;
                    responce.message = "No se encontra el Contribuyente Final con el RIF " + paramMefi.rifFinal;
                }else
                {
                    operationFiscal.FinalClientId = clientFinal.id;

                    //Consultar Distribuidor  
                    var distributor = _context.Sisg_Distributors.Where(d => d.rif == paramMefi.rifDistributor).FirstOrDefault();

                    if (distributor != null)
                    {
                        operationFiscal.DistributorId = distributor.id;

                        //Consultar el Tecnico
                        var technical = _context.Sisg_Technicians.Where(t => t.rif == paramMefi.rifTechnical).FirstOrDefault();

                        if (technical != null)
                        {
                            operationFiscal.TechnicianId = technical.id;
                            //Consultamos serial de Repuesto (Memoria Fiscal)

                            var serialMefi = await _context.Sisg_SerialsReplacements.Where(s => s.Serial == paramMefi.serialMefi).OrderByDescending(s => s.DateSale).FirstOrDefaultAsync();

                            if(serialMefi != null)
                            {
                                operationFiscal.ProviderId = serialMefi.ProviderId;
                                var replacement = _context.Sisg_Replacements.Find(serialMefi.ReplacementId);

                                if (serialMefi.DistributorId != operationFiscal.DistributorId)
                                {
                                    responce.isValid = false;
                                    responce.message = "El serial de Memoria Fiscal suministrado esta registrado con otro distribuidor. Verifique su correcta descripción o comuniquese con el proveedor.";
                                }
                                else
                                {
                                    var serialprod = await _context.Sisg_SerialsProducts.Where(s => s.Serial == paramMefi.serialMachine).FirstOrDefaultAsync();

                                    if(serialprod != null)
                                    {
                                        var product = _context.Sisg_Products.Find(serialprod.ProductId);

                                      if(product.ModelId == replacement.ModelId)
                                        {
                                            //Compruebe repeticion de uso
                                            var operations = await _context.Sisg_FiscalsOperations.Where(o => o.Serial == paramMefi.serialMefi && o.FiscalResult == 1).OrderByDescending(o => o.Id).ToListAsync();

                                            if (operations.Count > 0)
                                            {
                                                DateTime dateToday = DateTime.Now;

                                                int nHours = dateToday.Hour - operations.FirstOrDefault().Creation_Date.Hour;
                                                int difHours = nHours - 12;

                                                if(operations.FirstOrDefault().FinalClientId != operationFiscal.FinalClientId)
                                                {
                                                    responce.isValid = false;
                                                    responce.message = "El serial de Memoria Fiscal suministrado ya fue utilizado en un proceso de Fiscalización con otro contribuyente. Verifique su correcta descripción o comuniquese con el proveedor.";
                                                }else if(paramMefi.serialMachine != operations.FirstOrDefault().Serial)
                                                {
                                                    responce.isValid = false;
                                                    responce.message = "El serial de Memoria Fiscal suministrado ya fue utilizado en un proceso de Fiscalización con otro Nro. de Registro de Máquina. Verifique su correcta descripción o comuniquese con el proveedor.";
                                                }
                                                else if(difHours <= 24)
                                                {
                                                    if (operations.FirstOrDefault().FiscalMode == "REMOTO")
					                                {
                                                        responce.isValid = false;
                                                        responce.message = "El serial de Memoria Fiscal suministrado ya fue utilizado en un proceso de Fiscalización anterior. Verifique su correcta descripción o comuniquese con el proveedor.";
                                                    }
                                                }
                                                else
                                                {
                                                    bandera = true;
                                                    
                                                }
                                            }
                                            else
                                            {
                                                bandera = true;
                                            }
                                        }
                                        else
                                        {
                                            responce.isValid = false;
                                            responce.message = "El tipo de serial de Memoria Fiscal es válido pero no esta vinculado con el modelo de Numero de Registro de Máquina suministrado. Verifique los datos suministrados.";
                                        }
                                    }
                                    else
                                    {
                                        responce.isValid = false;
                                        responce.message = "El Serial de Máquina Fiscal suministrado no se encuentra en la base de datos de proveedor.";
                                    }
                                }
                            }
                            else
                            {
                                responce.isValid = false;
                                responce.message = "El serial de Memoria Fiscal suministrado no se encuentra en base de dato de proveedor. Verifique su correcta descripción o comuniquese con el proveedor.";
                            }
                        }
                        else
                        {
                            responce.isValid = false;
                            responce.message = "El RIF del Técnico suministrado no se encuentra registrado en el SGO. Verifiquelo las relaciones con los Distribuidor responsables.";
                        }
                    }
                    else
                    {
                        responce.isValid = false;
                        responce.message = "El RIF de Distribuidor suministrado no coincide con el que esta registrado en su perfil el el SGO. Verifiquelo en administración de cliente.";
                    }

                }

                if(bandera)
                {
                    operationFiscal.FiscalOperation = "CAMBIO MEFIS";
                    operationFiscal.Creation_Date = DateTime.Now;
                    operationFiscal.Serial = paramMefi.serialMefi;
                    operationFiscal.SerialRetative = paramMefi.serialMachine;
                    operationFiscal.FiscalMode = paramMefi.mode;
                    operationFiscal.FiscalAddress = "";
                    operationFiscal.CodeOperation = "";
                    operationFiscal.InitSeal = "000";
                    operationFiscal.FinalSeal = "000";

                    _context.Sisg_FiscalsOperations.Add(operationFiscal);

                    await _context.SaveChangesAsync();

                    responce.isValid = true;
                    responce.message = "Serial de Memoria Fiscal validado exitosamente";
                }

                return Ok(responce);
             }
             catch (Exception ex)
             {
                responce.isValid = false;
                responce.message = ex.Message;

                return StatusCode(500, responce);
             }
        }

        #endregion

        #region DELETE: api/FiscalsOperations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFiscalOperationModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fiscalOperationModel = await _context.Sisg_FiscalsOperations.FindAsync(id);
            if (fiscalOperationModel == null)
            {
                return NotFound();
            }

            _context.Sisg_FiscalsOperations.Remove(fiscalOperationModel);
            await _context.SaveChangesAsync();

            return Ok(fiscalOperationModel);
        }

        private bool FiscalOperationModelExists(int id)
        {
            return _context.Sisg_FiscalsOperations.Any(e => e.Id == id);
        }
        #endregion

        #region Metodos Privados

        private string GenerateCode(string word, string serial, string precode)
        {

            ulong lAux = CalcHash(precode);
            lAux = (lAux << 3) ^ CalcHash(serial);
            lAux = (lAux << 7) ^ CalcHash(word);
            lAux = (lAux % 999999999);

            string code = lAux.ToString("000000000");

            return code;

        }

        private ulong CalcHash(string cBuf)
        {
            int max, i;

            ulong lAux = 0, lAux2, lAux3;

            max = cBuf.Length;

            for (i = 0; i < max; i++)
            {
                lAux2 = cBuf[i];
                lAux3 = cBuf[max - i - 1];
                lAux = (lAux << 3) ^ lAux2;
                lAux = (lAux << 4) ^ lAux3;
                lAux = (lAux % 999999);
            }

            return lAux;
        }

        private string EncrypterPassword(string pOriginPassword)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();

            byte[] inputBytes = (new UnicodeEncoding()).GetBytes(pOriginPassword);
            byte[] hash = sha1.ComputeHash(inputBytes);

            return Convert.ToBase64String(hash);
        }

        #endregion

        #region Clases Requeridas
        [Serializable]
        internal class HttpResponseException : Exception
        {
            public HttpResponseException()
            {
            }

            public HttpResponseException(string message) : base(message)
            {
            }

            public HttpResponseException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected HttpResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }

        #endregion
    }
}