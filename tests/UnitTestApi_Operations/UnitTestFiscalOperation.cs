using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestApi_Operations
{

    [TestClass]
    public class UnitTestFiscalOperation
    {
        private string URL = "http://localhost/ApisSgo/";


        #region GET api/FiscalsOperations
        [TestMethod]
            public void TestGetFiscalsOperations()
            {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'pmoya@thefactoryhka.com',
                                    'password':'Tfhka2019'
                                }";
                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                string json1 = clientHttp.GetObjetcsAll("api-operations/FiscalsOperations");

                List<FiscalOperationModel> list = TypeModel<FiscalOperationModel>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region GET api/FiscalsOperations/4

        [TestMethod]
        public void TestGetFiscalsOperationsDetails()
        {

            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'pmoya@thefactoryhka.com',
                                    'password':'Tfhka2019'
                                }";
                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                string json1 = clientHttp.GetObjetc("api-operations/FiscalsOperations", "4");
                FiscalOperationModel fiscalOperation = TypeModel<FiscalOperationModel>.DeserializeInObject(json1);

                Assert.IsTrue(fiscalOperation != null);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        #endregion

        #region GET api/FiscalsOperations/ByProviderId/1

        [TestMethod]
        public void TestGetFiscalsOperationsByProviderId()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'pmoya@thefactoryhka.com',
                                    'password':'Tfhka2019'
                                }";
                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                string json1 = clientHttp.GetObjetcsAll("api-operations/FiscalsOperations/ByProviderId/1");


                List<FiscalOperationModel> list = TypeModel<FiscalOperationModel>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
        #endregion

        #region GET api/FiscalsOperations/BySerial/Z1B4444557

        [TestMethod]
        public void TestGetFiscalsOperationsBySerial()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'pmoya@thefactoryhka.com',
                                    'password':'Tfhka2019'
                                }";
                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                string json1 = clientHttp.GetObjetc("api-operations/FiscalsOperations/BySerial/", "Z1B4444555");

                FiscalOperationModel fiscalOperation = TypeModel<FiscalOperationModel>.DeserializeInObject(json1);

                Assert.IsTrue(fiscalOperation != null);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region GET: api/FiscalOperation/IsNewMachine/Z1B4444557  FALTA

        #endregion   

        #region GET api/fiscalsOperations/FinalClient/J314310895

        [TestMethod]
        public void TestGetFiscalsOperationsByClientFinal()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'pmoya@thefactoryhka.com',
                                    'password':'Tfhka2019'
                                }";
                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                string json1 = clientHttp.GetObjetcsAll("api-operations/fiscalsOperations/FinalClient/J314310895");


                List<FiscalOperationModel> list = TypeModel<FiscalOperationModel >.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        #endregion

        #region GET api/FiscalsOperations/Distributor/J293904862
        [TestMethod]
        public void TestGetFiscalsOperationsByDistributorRif()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'pmoya@thefactoryhka.com',
                                    'password':'Tfhka2019'
                                }";
                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                string json1 = clientHttp.GetObjetcsAll("api-operations/FiscalsOperations/Distributor/J293904862");

                List<FiscalOperationModel> list = TypeModel<FiscalOperationModel>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region GET api/fiscalsOperations/Technical/V205405662

        [TestMethod]
        public void TestGetFiscalOperationsByTechn()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'pmoya@thefactoryhka.com',
                                    'password':'Tfhka2019'
                                }";
                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                string json1 = clientHttp.GetObjetcsAll("api-operations/fiscalsOperations/Technicians/V205405662");


                List<FiscalOperationModel> list = TypeModel<FiscalOperationModel>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        #endregion

        #region GET api/FiscalsOperations/ByDate/2020-04-01
        [TestMethod]
        public void GetFiscalsOperationsByDate()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'pmoya@thefactoryhka.com',
                                    'password':'Tfhka2019'
                                }";
                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                string json1 = clientHttp.GetObjetcsAll("api-operations/FiscalsOperations/ByDate/2020-04-01");

                List<FiscalOperationModel> list = TypeModel<FiscalOperationModel>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
        #endregion

        #region POST api/FiscalsOperations   FALTA

        #endregion

        #region POST: api/FiscalOperation/ValidateMemfisc  FALTA

        #endregion

        #region PUT api/FiscalsOperations
        [TestMethod]
        public void TestPutFiscalsOperations()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);

                String json = @"{   'username':'pmoya@thefactoryhka.com',
                                    'password':'Tfhka2019'
                                }";

                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                String json1 = @"{   
	                'id': 6,
                    'serial': 'Z1B4447778',
                    'providerId': 2,
                    'distributorId': 74,
                    'finalClientId': 22,
                    'status': 'activo',
                    'observations': 'Producto the factory hka actualizado',
                    'alienationDate': '2020-03-27T13:44:24'
                    }";

                String response1 = clientHttp.PutObjetc("api-operations/FiscalsOperations", "6", json1);

                if (response1.Equals("NoContent"))
                {
                    Assert.IsTrue(true);
                }
                else
                {
                    Assert.IsTrue(false);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
        #endregion

        #region DELETE api/FiscalsOperations

        [TestMethod]
        public void TestDeleteFiscalsOperations()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'pmoya@thefactoryhka.com',
                                    'password':'Tfhka2019'
                                }";

                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);
                string response1 = clientHttp.DeleteObjetc("api-operations/FiscalsOperations", "6");

                if (response1.Equals("OK"))
                {
                    Assert.IsTrue(true);
                }
                else
                {
                    Assert.IsTrue(false);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        #endregion

        #region Clases Requeridas

        public class FiscalOperationModel
        {
            public int Id { get; set; }
            public string FiscalOperation { get; set; }
            public string FiscalMode { get; set; }
            public int ProviderId { get; set; }
            public int DistributorId { get; set; }
            public int TechnicianId { get; set; }
            public int FinalClientId { get; set; }
            public string Serial { get; set; }
            public string InitSeal { get; set; }
            public string FinalSeal { get; set; }
            public string FiscalAddress { get; set; }
            public int FiscalResult { get; set; }
            public string SerialRetative { get; set; }
            public string CodeOperation { get; set; }
            public DateTime Creation_Date { get; set; }

            public Provider provider { get; set; }
            public Distributor distributor { get; set; }
            public Technician technician { get; set; }
            public Finalsclients finalClient { get; set; }
        }

        public class Technician
        {
            public int id { get; set; }
            public string rif { get; set; }
            public string description { get; set; }
            public string address { get; set; }
            public string phone { get; set; }
            public string email { get; set; }
            public int enable { get; set; }
            public DateTime creation_date { get; set; }
        }

        public class Finalsclients
        {
            public int id { get; set; }
            public string rif { get; set; }
            public string description { get; set; }
            public string name { get; set; }
            public string lastName { get; set; }
            public string phone { get; set; }
            public string email { get; set; }
            public string fiscalAddress { get; set; }
            public int enable { get; set; }
            public DateTime creation_date { get; set; }
        }
        #endregion
    }
}
