using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestApi_Operations
{

    [TestClass]
    public class UnitTestTechnicalsOperations
    {

        private string URL = "http://localhost/ApisSgo/";

        #region GET: api/TechnicalsOperations

        [TestMethod]
        public void TestGetSisg_TechnicalsOperations()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'sgove@tfhka.com',
                                    'password':'Moneda32'
                                }";
                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                string json1 = clientHttp.GetObjetcsAll("api-operations/TechnicalsOperations");

                List<TechnicalOperationModel> list = TypeModel<TechnicalOperationModel>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);
            } catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #region GET api/TechnicalsOperations/5

        [TestMethod]
        public void TestGetTechnicalsOperationsById()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'sgove@tfhka.com',
                                    'password':'Moneda32'
                                }";
                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                string json1 = clientHttp.GetObjetc("api-operations/TechnicalsOperations", "1");
                TechnicalOperationModel technicalOperation = TypeModel<TechnicalOperationModel>.DeserializeInObject(json1);

                Assert.IsTrue(technicalOperation != null);
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #region api/TechnicalsOperations/BySerial/Z1B4444557

        [TestMethod]
        public void TestGetTechnicalsOperationsBySerial()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'sgove@tfhka.com',
                                    'password':'Moneda32'
                                }";
                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                string json1 = clientHttp.GetObjetc("api-operations/TechnicalsOperations/BySerial/", "Z1B8100007");

                //TechnicalOperationModel technicalOperation = TypeModel<TechnicalOperationModel>.DeserializeInObject(json1);
                List<TechnicalOperationModel> technicalOperationList = TypeModel<TechnicalOperationModel>.DeserializeInArray(json1);

                Assert.IsTrue(technicalOperationList.Count > 0);
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #region GET api/TechnicalsOperations/ByProviderId/1

        [TestMethod]
        public void TestGetSisg_TechnicalsOperationsByProviderId()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'sgove@tfhka.com',
                                    'password':'Moneda32'
                                }";
                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                string json1 = clientHttp.GetObjetcsAll("api-operations/TechnicalsOperations/ByProviderId/1");

                List<TechnicalOperationModel> technicalOperationList = TypeModel<TechnicalOperationModel>.DeserializeInArray(json1);

                Assert.IsTrue(technicalOperationList.Count > 0);

            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #region  GET api/TechnicalsOperations/FinalClient/J314310895
        [TestMethod]
        public void TestGetTechnicalsOperationsByFinald()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'sgove@tfhka.com',
                                    'password':'Moneda32'
                                }";
                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                string json1 = clientHttp.GetObjetcsAll("api-operations/TechnicalsOperations/FinalClient/J401604196");

                List<TechnicalOperationModel> technicalOperationList = TypeModel<TechnicalOperationModel>.DeserializeInArray(json1);

                Assert.IsTrue(technicalOperationList.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        #endregion

        #region GET api/TechnicalsOperations/Distributor/J875212448

        [TestMethod]
        public void GetSisg_TechnicalsOperationsByDistr()
        {
            try
            {

                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'sgove@tfhka.com',
                                    'password':'Moneda32'
                                }";
                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                string json1 = clientHttp.GetObjetcsAll("api-operations/TechnicalsOperations/Distributor/J875212448");

                List<TechnicalOperationModel> technicalOperationList = TypeModel<TechnicalOperationModel>.DeserializeInArray(json1);

                Assert.IsTrue(technicalOperationList.Count > 0);
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #region GET api/TechnicalsOperations/Technical/V145264164

        [TestMethod]
        public void TestGetSisg_TechnicalsOperationsByTech()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'sgove@tfhka.com',
                                    'password':'Moneda32'
                                }";
                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                string json1 = clientHttp.GetObjetcsAll("api-operations/TechnicalsOperations/Technical/V145264614");

                List<TechnicalOperationModel> technicalOperationList = TypeModel<TechnicalOperationModel>.DeserializeInArray(json1);

                Assert.IsTrue(technicalOperationList.Count > 0);
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #region GET api/TechnicalsOperations/ByDate/2020-01-01

        [TestMethod]
        public void TestGetTechnicalsOperationsByDate()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'sgove@tfhka.com',
                                    'password':'Moneda32'
                                }";
                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                string json1 = clientHttp.GetObjetcsAll("api-operations/TechnicalsOperations/ByDate/2020-01-01");

                List<TechnicalOperationModel> technicalOperationList = TypeModel<TechnicalOperationModel>.DeserializeInArray(json1);

                Assert.IsTrue(technicalOperationList.Count > 0);
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        #endregion

        #region POST: api/TechnicalsOperations
        [TestMethod]
        public void TestPostTechnicalsOperations()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);

                String json = @"{   'username':'sgove@tfhka.com',
                                    'password':'Moneda32'
                                }";

                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                String json1 = @"{   
                    'id': 0,
                    'providerId': 1,
                    'distributorId': 7,
                    'finalClientId': 38,
                    'technicianId': 2,
                    'typeOperationTechId': 3,
                    'serial': 'Z1B8100777',
                    'status': 'DECLARADO',
                    'operation_Date': '2020-04-13T00:00:00',
                    'creation_Date': '2020-04-10T14:23:07'
                    }";

                String response1 = clientHttp.PostObjetc("api-operations/TechnicalsOperations", json1);

                if (response1.Equals("Created"))
                {
                    Assert.IsTrue(true);
                }
                else
                {
                    Assert.IsTrue(false);
                }             
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        #endregion

        #region PUT api/TechnicalsOperations
        [TestMethod]
        public void TestPutSisg_TechnicalsOperations()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);

                String json = @"{   'username':'sgove@tfhka.com',
                                    'password':'Moneda32'
                                }";

                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                String json1 = @"{   
	                'id': 5,
                    'providerId': 1,
                    'distributorId': 7,
                    'finalClientId': 38,
                    'technicianId': 2,
                    'typeOperationTechId': 3,
                    'serial': 'Z1B8100778',
                    'status': 'DECLARADO',
                    'operation_Date': '2020-04-22T00:00:00',
                    'creation_Date': '2020-04-10T14:23:07'
                    }";

                String response1 = clientHttp.PutObjetc("api-operations/TechnicalsOperations", "5", json1);

                if (response1.Equals("NoContent"))
                {
                    Assert.IsTrue(true);
                }
                else
                {
                    Assert.IsTrue(false);
                }
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region DELETE api/TechnicalsOperations

        [TestMethod]
        public void TestDeleteSisg_TechnicalsOperations()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'sgove@tfhka.com',
                                    'password':'Moneda32'
                                }";

                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);
                string response1 = clientHttp.DeleteObjetc("api-operations/TechnicalsOperations", "5");

                if (response1.Equals("OK"))
                {
                    Assert.IsTrue(true);
                }
                else
                {
                    Assert.IsTrue(false);
                }
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #region Clases Requeridas

        public class TechnicalOperationModel
        {
            public int Id { get; set; }
            public int ProviderId { get; set; }
            public int DistributorId { get; set; }
            public int FinalClientId { get; set; }
            public int TechnicianId { get; set; }
            public int TypeOperationTechId { get; set; }
            public string Serial { get; set; }
            public string Status { get; set; }
            public DateTime Operation_Date { get; set; }
            public DateTime Creation_Date { get; set; }

            public Provider provider { get; set; }
            public Distributor distributor { get; set; }
            public Finalsclients finalclient { get; set; }
            public Technician technician { get; set; }
            public TypeOperationTech typeOperationTech { get; set; }
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


        public class TypeOperationTech
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public DateTime Creation_Date { get; set; }
        }

        #endregion
    }
}
