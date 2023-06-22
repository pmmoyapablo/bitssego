using Api_Clients.Models;
using Api_Access.Models;
using Api_Employees.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UnitTestApi_Employees
{
    [TestClass]
    public class UnitTestEmployees
    {
        //DEV
        private string URL = "https://localhost:44330/";
        //IIS Local
        //private string URL = "http://localhost/ApisSgo/";
        //Ambiente de TEST en Servidor Local
        //private string URL = "http://192.168.0.73/ApisSgo/";

        //Chargues

        #region Get Chargues
        [TestMethod]
        public void TestGetChargues()
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
                string json1 = clientHttp.GetObjetcsAll("api-employees/Chargues");
                List<Chargue> list = TypeModel<Chargue>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Get Chargue
        [TestMethod]
        public void TestGetChargue()
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

                string json1 = clientHttp.GetObjetc("api-employees/Chargues", "2");
                Chargue Chargue = TypeModel<Chargue>.DeserializeInObject(json1);

                Assert.IsTrue(Chargue != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Post Chargue
        [TestMethod]
        public void TestPostChargues()
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
                                  'description': 'Gerente de Servicios',
                                  'rolId': '2',                               
                               }";

                String response1 = clientHttp.PostObjetc("api-employees/Chargues", json1);

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

        #region Put Chargue
        [TestMethod]
        public void TestPutChargue()
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
                                  'id': 38,
                                  'description': 'Gerente de Servicios 2',
                                  'rolId': '2',                               
                               }";

                String response1 = clientHttp.PutObjetc("api-employees/Chargues", "38", json1);

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

        #region Delete Chargue
        [TestMethod]
        public void TestDeleteChargue()
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
                string response1 = clientHttp.DeleteObjetc("api-employees/Chargues", "38");

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

        //Departaments

        #region Get Departaments
        [TestMethod]
        public void TestGetDepartaments()
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
                string json1 = clientHttp.GetObjetcsAll("api-employees/Departaments");
                List<Chargue> list = TypeModel<Chargue>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Get Departament
        [TestMethod]
        public void TestGetDepartament()
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

                string json1 = clientHttp.GetObjetc("api-employees/Departaments", "1");
                Chargue Chargue = TypeModel<Chargue>.DeserializeInObject(json1);

                Assert.IsTrue(Chargue != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Post Departament
        [TestMethod]
        public void TestPostDepartaments()
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
                                  'description': 'Soporte',                                                           
                               }";

                String response1 = clientHttp.PostObjetc("api-employees/Departaments", json1);

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

        #region Put Departament
        [TestMethod]
        public void TestPutDepartament()
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
                                  'id': 20,
                                  'description': 'Soporte 2',                                                           
                               }";

                String response1 = clientHttp.PutObjetc("api-employees/Departaments", "20", json1);

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

        #region Delete Departament
        [TestMethod]
        public void TestDeleteDepartament()
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
                string response1 = clientHttp.DeleteObjetc("api-employees/Departaments", "2");

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

        //Employees

        #region Get Employees
        [TestMethod]
        public void TestGetEmployees()
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
                string json1 = clientHttp.GetObjetcsAll("api-employees/Employees");
                List<Employee> list = TypeModel<Employee>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Get Employee
        [TestMethod]
        public void TestGetEmployee()
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

                string json1 = clientHttp.GetObjetc("api-employees/Employees", "1");
                Employee employee = TypeModel<Employee>.DeserializeInObject(json1);

                Assert.IsTrue(employee != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Post Employee
        [TestMethod]
        public void TestPostEmployees()
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
                                    'supervitorId': 0,
                                    'rif':'V114567177',
                                    'code':'10001',
                                    'description':'Pablo Moya',
                                    'departamentId': '12',
                                    'chargueId':'27',
                                    'email':'pmoya3@thefactoryhka.com',
                                    'phone':'+57 322 8491444',
                                    'enable':1,
                               }";

                String response1 = clientHttp.PostObjetc("api-employees/Employees", json1);

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

        #region Put Employee
        [TestMethod]
        public void TestPutEmployee()
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
                                    'id': 23,
                                    'supervitorId': 0,
                                    'rif':'V114567177',
                                    'code':'10001',
                                    'description':'Pablo Mora',
                                    'departamentId': '12',
                                    'chargueId':'27',
                                    'email':'pmoya3@thefactoryhka.com',
                                    'phone':'+57 322 8491444',
                                    'enable':1,
                               }";

                String response1 = clientHttp.PutObjetc("api-employees/Employees", "23", json1);

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

        #region Delete Employee
        [TestMethod]
        public void TestDeleteEmployee()
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
                string response1 = clientHttp.DeleteObjetc("api-employees/Employees", "23");

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

        #region Post Employee-User
        [TestMethod]
        public void TestPostEmployeesUsers()
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

                String response1 = clientHttp.PostObjetc("api-employees/Employees/16/1", "");

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

        #region Delete Employee-User
        [TestMethod]
        public void TestDeleteEmployeesUsers()
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

                String response1 = clientHttp.DeleteObjetc("api-employees/Employees/4/Users", "6");

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

        #region Get EmployersToCharge
        [TestMethod]
        public void TestGetEmployersToCharge()
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
                string json1 = clientHttp.GetObjetcsAll("api-employees/Employees/1/Chargues");
                //
                //
                //
                //
                //
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
