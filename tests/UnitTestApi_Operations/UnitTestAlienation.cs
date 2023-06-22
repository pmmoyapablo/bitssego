using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestApi_Operations
{

    [TestClass]
    public class UnitTestAlienation
    {
        private string URL = "http://localhost/ApisSgo/";


        #region GET api/Alienations
            [TestMethod]
            public void TestGetAlienations()
            {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'pmoya@thefactoryhka.com',
                                    'password':'Moneda32'
                                }";
                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                string json1 = clientHttp.GetObjetcsAll("api-operations/Alienations");

                List<Alienation> list = TypeModel<Alienation>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region GET api/Alienations/1

        [TestMethod]
        public void TestGetAlienationsById()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'pmoya@thefactoryhka.com',
                                    'password':'Moneda32'
                                }";
                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                string json1 = clientHttp.GetObjetc("api-operations/Alienations", "1");
                Alienation alienation = TypeModel<Alienation>.DeserializeInObject(json1);

                Assert.IsTrue(alienation != null);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }


        #endregion

        #region GET api/Alienations/BySerial/Z1B4444557

        [TestMethod]
        public void TestGetAlienationsBySerial()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'pmoya@thefactoryhka.com',
                                    'password':'Moneda32'
                                }";
                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                string json1 = clientHttp.GetObjetc("api-operations/Alienations/BySerial/", "Z1B8100007");

                Alienation alienation = TypeModel<Alienation>.DeserializeInObject(json1);

                Assert.IsTrue(alienation != null);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }


        #endregion

        #region GET api/Alienations/ByProviderId/1

        [TestMethod]
        public void TestGetAlienationsByProviderId()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'pmoya@thefactoryhka.com',
                                    'password':'Moneda32'
                                }";
                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                //string json1 = clientHttp.GetObjetc("api-operations/Alienations/ByProviderId/", "1");
                string json1 = clientHttp.GetObjetcsAll("api-operations/Alienations/ByProviderId/1");


                List<Alienation> list = TypeModel<Alienation>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }


        #endregion

        #region GET api/Alienations/FinalClient/J314310895

        [TestMethod]
        public void TestGetAlienationsByClientFinal()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'pmoya@thefactoryhka.com',
                                    'password':'Moneda32'
                                }";
                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                //string json1 = clientHttp.GetObjetc("api-operations/Alienations/ByProviderId/", "1");
                string json1 = clientHttp.GetObjetcsAll("api-operations/Alienations/FinalClient/J314310895");


                List<Alienation> list = TypeModel<Alienation>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        #endregion

        #region GET api/Alienations/Distributor/J293904862
        [TestMethod]
        public void TestGetAlienationsByDistributorRif()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'pmoya@thefactoryhka.com',
                                    'password':'Moneda32'
                                }";
                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                //string json1 = clientHttp.GetObjetc("api-operations/Alienations/ByProviderId/", "1");
                string json1 = clientHttp.GetObjetcsAll("api-operations/Alienations/Distributor/J293904862");


                List<Alienation> list = TypeModel<Alienation>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
        #endregion

        #region GET api/Alienations/ByDate/2020-03-27
        [TestMethod]
        public void GetAlienationsByDate()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'pmoya@thefactoryhka.com',
                                    'password':'Moneda32'
                                }";
                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                //string json1 = clientHttp.GetObjetc("api-operations/Alienations/ByProviderId/", "1");
                string json1 = clientHttp.GetObjetcsAll("api-operations/Alienations/ByDate/2020-03-27");


                List<Alienation> list = TypeModel<Alienation>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
        #endregion

        #region POST api/Alienations

        [TestMethod]
        public void TestPostAlienations()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);

                String json = @"{   'username':'pmoya@thefactoryhka.com',
                                    'password':'Moneda32'
                                }";

                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                String json1 = @"{   
	                'id': 0,
                    'serial': 'Z1B8100007',
                    'providerId': 1,
                    'distributorId': 24,
                    'finalClientId': 38,
                    'status': 'PROCESADO',
                    'observations': 'Producto the factory hka',
                    'alienationDate': '2020-03-27T13:44:24'
                    }";

                String response1 = clientHttp.PostObjetc("api-operations/Alienations", json1);

                if (response1.Equals("Created"))
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

        #region PUT api/Alienations
        [TestMethod]
        public void TestPutAlienations()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);

                String json = @"{   'username':'pmoya@thefactoryhka.com',
                                    'password':'Moneda32'
                                }";

                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);

                String json1 = @"{   
	                'id': 1,
                    'serial': 'Z1B8100007',
                    'providerId': 1,
                    'distributorId': 24,
                    'finalClientId': 38,
                    'status': 'DECLARADO',
                    'observations': 'Producto The Factory HKA actualizado',
                    'alienationDate': '2020-03-27T13:44:24'
                    }";

                String response1 = clientHttp.PutObjetc("api-operations/Alienations", "1", json1);

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

        #region DELETE api/Alienations

        [TestMethod]
        public void TestDeleteAlienations()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                String json = @"{   'username':'pmoya@thefactoryhka.com',
                                    'password':'Moneda32'
                                }";

                string bodyResp = string.Empty;

                String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

                string token = "Bearer " + tokenObj.accessToken;

                clientHttp = new ClientHttpREST(URL, token);
                string response1 = clientHttp.DeleteObjetc("api-operations/Alienations", "6");

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

        public class Alienation
        {
            public int Id { get; set; }
            public string Serial { get; set; }
            public int ProviderId { get; set; }
            public int DistributorId { get; set; }
            public int FinalClientId { get; set; }
            public string Status { get; set; }
            public string Observations { get; set; }
            public DateTime AlienationDate { get; set; }
            public DateTime Creation_Date { get; set; }

            public Provider provider { get; set; }
            public Distributor distributor { get; set; }
            public Finalsclients FinalClient { get; set; }
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
