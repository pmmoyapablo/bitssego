using Api_Utilities.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UnitTestApi_Utilities
{
    [TestClass]
    public class UnitTestUtilities
    {
        //DEV
        private string URL = "https://localhost:44330/";
        //IIS Local
        //private string URL = "http://localhost/ApisSgo/";
        //Ambiente de TEST en Servidor Local
        //private string URL = "http://192.168.0.73/ApisSgo/";

        //CasesSoftwareHouses
        #region Get CasesSoftwareHouses
        [TestMethod]
        public void TestGetCasesSoftwareHouses()
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
                string json1 = clientHttp.GetObjetcsAll("api-utilities/CasesSoftwareHouses");
                List<CasesSoftwareHouse> list = TypeModel<CasesSoftwareHouse>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Get CasesSoftwareHouse
        [TestMethod]
        public void TestGetCasesSoftwareHouse()
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

                string json1 = clientHttp.GetObjetc("api-utilities/CasesSoftwareHouses", "2");
                CasesSoftwareHouse casesSoftwareHouse = TypeModel<CasesSoftwareHouse>.DeserializeInObject(json1);

                Assert.IsTrue(casesSoftwareHouse != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Post CasesSoftwareHouse
        [TestMethod]
        public void TestPostCasesSoftwareHouse()
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
                                  'id': 0,
                                  'contactShape': 'correo',
                                  'page': 'www.pruebaunitaria.com',
                                  'systemAdmin': 'PruebaUnitaria',
                                  'versionSystemAdmin': '5.0.1',
                                  'descriptionCase': 'cambios de contacos Prueba Unitaria',
                                  'otherLanguage': 'c++',
                                  'employeeId': 1,
                                  'developersClientsId': 1,
                                  'systemOperId': 2,
                                  'statusId': 2,
                                  'programLanguageId': 4,
                                  'dateRegister': '2021 - 01 - 26T14: 22:36.165Z',
                                  'dateLastContact': '2021-01-26T14:22:36.165Z',
                                  'clientType': 2
                               }";

                String response1 = clientHttp.PostObjetc("api-utilities/CasesSoftwareHouses", json1);

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

        #region Put CasesSoftwareHouse
        [TestMethod]
        public void TestPutCasesSoftwareHouse()
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
                                  'id': 2,
                                  'contactShape': 'Correo',
                                  'page': 'www.pruebaunitaria53.com',
                                  'systemAdmin': 'PruebaUnitaria53',
                                  'versionSystemAdmin': '5.0.1',
                                  'descriptionCase': 'cambios de contactos Prueba Unitaria53',
                                  'otherLanguage': 'c++',
                                  'employeeId': 1,
                                  'developersClientsId': 1,
                                  'systemOperId': 2,
                                  'statusId': 2,
                                  'programLanguageId': 2,
                                  'dateRegister': '2021 - 01 - 26T14: 22:36.165Z',
                                  'dateLastContact': '2021-01-26T14:22:36.165Z',
                                    'clientType': 2
                               }";

                String response1 = clientHttp.PutObjetc("api-utilities/CasesSoftwareHouses", "2", json1);

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

        #region Delete CasesSoftwareHouse
        [TestMethod]
        public void TestDeleteCasesSoftwareHouse()
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

                string response1 = clientHttp.DeleteObjetc("api-utilities/CasesSoftwareHouses", "5");

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

        //CasesProducts
        #region Get CasesProducts
        [TestMethod]
        public void TestGetCasesProducts()
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
                string json1 = clientHttp.GetObjetcsAll("api-utilities/CasesProducts");
                List<CasesSoftwareHouse> list = TypeModel<CasesSoftwareHouse>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Get CasesProduct
        [TestMethod]
        public void TestGetCasesProduct()
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

                string json1 = clientHttp.GetObjetc("api-utilities/CasesProducts", "2");
                CasesSoftwareHouse casesSoftwareHouse = TypeModel<CasesSoftwareHouse>.DeserializeInObject(json1);

                Assert.IsTrue(casesSoftwareHouse != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Post CasesProducts
        [TestMethod]
        public void TestPostCasesProducts()
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
                                    'id': 0,
                                    'caseSoftwareHouseId' 1,
                                    'productId': 1,
                               }";

                String response1 = clientHttp.PostObjetc("api-utilities/CasesProducts", json1);

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

        #region Put CasesProducts
        [TestMethod]
        public void TestPutCasesProducts()
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
                                    'id': 1,
                                    'caseSoftwareHouseId' 2,
                                    'productId': 2,
                               }";

                String response1 = clientHttp.PutObjetc("api-utilities/CasesProducts", "2", json1);

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

        #region Delete CasesProducts
        [TestMethod]
        public void TestDeleteCasesProducts()
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

                string response1 = clientHttp.DeleteObjetc("api-utilities/CasesProducts", "5");

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

        //ProgramLenguages
        #region Get ProgramLenguages
        [TestMethod]
        public void TestGetProgramLenguages()
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
                string json1 = clientHttp.GetObjetcsAll("api-utilities/ProgramLenguages");
                List<ProgramLenguage> list = TypeModel<ProgramLenguage>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Get ProgramLenguage
        [TestMethod]
        public void TestGetProgramLenguage()
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

                string json1 = clientHttp.GetObjetc("api-utilities/ProgramLenguages", "2");
                ProgramLenguage programLenguage = TypeModel<ProgramLenguage>.DeserializeInObject(json1);

                Assert.IsTrue(programLenguage != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Post ProgramLenguage
        [TestMethod]
        public void TestPostProgramLenguage()
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
                                  'id': 0,
                                  'name': 'DMC++',
                                  'visible': 1
                               }";

                String response1 = clientHttp.PostObjetc("api-utilities/ProgramLenguages", json1);

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

        #region Put ProgramLenguage
        [TestMethod]
        public void TestPutProgramLenguage()
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
                                  'id': 7,
                                  'name': 'DMC --',
                                  'visible': 1                             
                               }";

                String response1 = clientHttp.PutObjetc("api-utilities/ProgramLenguages", "7", json1);

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

        #region Delete ProgramLenguage
        [TestMethod]
        public void TestDeleteProgramLenguage()
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
                string response1 = clientHttp.DeleteObjetc("api-utilities/ProgramLenguages", "655");

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

        //StatusIntegrations
        #region Get StatusIntegrations
        [TestMethod]
        public void TestGetStatusIntegrations()
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
                string json1 = clientHttp.GetObjetcsAll("api-utilities/StatusIntegrations");
                List<StatusIntegration> list = TypeModel<StatusIntegration>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Get StatusIntegration
        [TestMethod]
        public void TestGetStatusIntegration()
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

                string json1 = clientHttp.GetObjetc("api-utilities/StatusIntegrations", "2");
                StatusIntegration statusIntegration = TypeModel<StatusIntegration>.DeserializeInObject(json1);

                Assert.IsTrue(statusIntegration != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Post StatusIntegration
        [TestMethod]
        public void TestPostStatusIntegrations()
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
                                  'id': 0,
                                  'name': 'StatusTest',
                                  'visible': 1
                               }";

                String response1 = clientHttp.PostObjetc("api-utilities/StatusIntegrations", json1);

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

        #region Put StatusIntegration
        [TestMethod]
        public void TestPutStatusIntegration()
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
                                  'id': 7,
                                  'name': 'statusON',
                                  'visible': 1                             
                               }";

                String response1 = clientHttp.PutObjetc("api-utilities/StatusIntegrations", "7", json1);

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

        #region Delete StatusIntegration
        [TestMethod]
        public void TestDeleteStatusIntegration()
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
                string response1 = clientHttp.DeleteObjetc("api-utilities/StatusIntegrations", "7");

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

        //SystemOpers
        #region Get SystemOpers
        [TestMethod]
        public void TestGetSystemOpers()
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
                string json1 = clientHttp.GetObjetcsAll("api-utilities/SystemOpers");
                List<SystemOper> list = TypeModel<SystemOper>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Get SystemOper
        [TestMethod]
        public void TestGetSystemOper()
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

                string json1 = clientHttp.GetObjetc("api-utilities/SystemOpers", "2");
                SystemOper systemOper = TypeModel<SystemOper>.DeserializeInObject(json1);

                Assert.IsTrue(systemOper != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Post SystemOper
        [TestMethod]
        public void TestPostSystemOper()
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
                                  'id': 0,
                                  'name': 'Windows53',
                                  'visible': 1
                               }";

                String response1 = clientHttp.PostObjetc("api-utilities/SystemOpers", json1);

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

        #region Put SystemOper
        [TestMethod]
        public void TestPutSystemOper()
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
                                  'name': 'Windows53_SM_200',
                                  'visible': 1                             
                               }";

                String response1 = clientHttp.PutObjetc("api-utilities/SystemOpers", "6", json1);

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

        #region Delete SystemOper
        [TestMethod]
        public void TestDeleteSystemOper()
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
                string response1 = clientHttp.DeleteObjetc("api-utilities/SystemOpers", "39");

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
        class TokenStruct
        {
            public bool authenticated = false;
            public string created = string.Empty,
                     expiration = string.Empty,
                     accessToken = string.Empty,
                     message = "";
            public User userData;
        }
        #endregion

    }
}
