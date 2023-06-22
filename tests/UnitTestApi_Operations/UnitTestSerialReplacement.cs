using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestApi_Operations
{
    [TestClass]
    public class UnitTestSerialReplacement
    {

        //private string URL = "https://localhost:44330/";

        private string URL = "http://localhost/ApisSgo/";

        #region GET api-operations/SerialsReplacements

        [TestMethod]
        public void TestGetSerialsReplacements()
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

                string json1 = clientHttp.GetObjetcsAll("api-operations/SerialsReplacements");

                List<SerialReplacement> list = TypeModel<SerialReplacement>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #region GET api-operations/SerialsReplacements/2

        [TestMethod]
        public void TestGetSerialsReplacementsDetails()
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

                string json1 = clientHttp.GetObjetc("api-operations/SerialsReplacements", "2");
                SerialReplacement serial = TypeModel<SerialReplacement>.DeserializeInObject(json1);

                Assert.IsTrue(serial != null);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }


        #endregion

        #region GET api-operations/SerialsReplacements/BySerial/F05E8D00F45

        [TestMethod]
        public void TestGetSerialsReplacementsByRe()
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

                string json1 = clientHttp.GetObjetc("api-operations/SerialsReplacements/BySerial", "F05E8D00F45");

                SerialReplacement serial = TypeModel<SerialReplacement>.DeserializeInObject(json1);

                Assert.IsTrue(serial != null);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        #endregion

        #region POST api-operations/SerialsReplacements
        [TestMethod]
        public void TestPostSerialsReplacements()
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
                                    'serial': 'F02A8100AC9',
                                    'replacementId': 9,
                                    'distributorId': 8,
                                    'providerId': 2,
                                    'dateSale': '2020-03-09T14:52:00',
                                    'observations': 'RPTO/P71792/RETIRA/CF'
                               }";

                String response1 = clientHttp.PostObjetc("api-operations/SerialsReplacements", json1);

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

        #region PUT api-operations/SerialsReplacements

        [TestMethod]
        public void TestPutSerialsReplacements()
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
                                    'id': 2,
                                    'serial': 'F02A8100DC7',
                                    'replacementId': 9,
                                    'distributorId': 7,
                                    'providerId': 2,
                                    'dateSale': '2020-03-09T14:52:00',
                                    'observations': 'RPTO/P71792/RETIRA/CF'
                               }";

                String response1 = clientHttp.PutObjetc("api-operations/SerialsReplacements", "2", json1);

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

        #region DELETE  api-operations/SerialsReplacements
        [TestMethod]
        public void TestDeleteSerialsReplacements()
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

                string response1 = clientHttp.DeleteObjetc("api-operations/SerialsReplacements", "2");

                if (response1.Equals("Ok"))
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

    }
}
