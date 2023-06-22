using Api_Clients.Models;
using Api_Access.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UnitTestApi_Clients
{
    [TestClass]
    public class UnitTestClients
    {
        //DEV
       private string URL = "https://localhost:44330/";
        //IIS Local
        //private string URL = "http://localhost/ApisSgo/";
        //Ambiente de TEST en Servidor Local
        //private string URL = "http://192.168.0.73/ApisSgo/";

        //Providers

        #region Get Providers
        [TestMethod]
        public void TestGetProviders()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                string json = clientHttp.GetObjetcsAll("api-clients/Providers");
                List<Provider> list = TypeModel<Provider>.DeserializeInArray(json);

                Assert.IsTrue(list.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Get Provider
        [TestMethod]
        public void TestGetProvider()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                string json = clientHttp.GetObjetc("api-clients/Providers", "1");
                Provider Provider = TypeModel<Provider>.DeserializeInObject(json);

                Assert.IsTrue(Provider != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Post Provider
        [TestMethod]
        public void TestPostProviders()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);

                String json = @"{
                                  'id': 0,
                                  'rif': 'J402385358',
                                  'description': 'HKA Venezuela',
                                  'address': 'Calle Callejón Gutiérrez, Edf. Riva, Local 2-1. Planta Baja. La california Norte. Caracas – Venezuel',
                                  'phone': '(+58) 212 2020811 / 212 2375010',
                                  'email': 'atencion@hkave.com',
                                  'image': '/img/logohkave.png'
                               }";

                String response = clientHttp.PostObjetc("api-clients/Providers", json);

                if (response.Equals("Created"))
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

        #region Put Provider
        [TestMethod]
        public void TestPutProvider()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);

                String json = @"{
                                   'id': 1,
                                   'rif': 'J-29398713-0',
                                   'description': 'The Factory HKA C.A. VZLA',
                                   'address': 'Calle Callejón Gutiérrez, Edf. Riva, Local 2-1. Planta Baja. La california Norte. Caracas – Venezuel',
                                   'phone': '212 2020811 / 212 2375010 / 212 2374112 / 212 2375253 / 212 2374368 / 212 2375132',
                                   'email': 'atencion@thefactoryhka.com',
                                   'image': 'logotfhka.png'                                   
                                }";

                String response = clientHttp.PutObjetc("api-clients/Providers", "1", json);

                if (response.Equals("NoContent"))
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

        #region Delete Provider
        [TestMethod]
        public void TestDeleteProvider()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                string response = clientHttp.DeleteObjetc("api-clients/Providers", "3");

                if (response.Equals("OK"))
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

        //Distributor

        #region Get Distributors
        [TestMethod]
        public void TestGetDistributors()
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
                string json1 = clientHttp.GetObjetcsAll("api-clients/Distributors");
                List<Distributor> list = TypeModel<Distributor>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Get Distributor
        [TestMethod]
        public void TestGetDistributor()
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

                string json1 = clientHttp.GetObjetc("api-clients/Distributors", "2");
                Distributor Distributor = TypeModel<Distributor>.DeserializeInObject(json1);

                Assert.IsTrue(Distributor != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Post Distributor
        [TestMethod]
        public void TestPostDistributors()
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
                                  'idSA': 345,
                                  'rif': 'J755385359',
                                  'description': 'Importadora Post 777 C.A II',
                                  'represent': 'Luis Damiro',
                                  'address': 'Avenida Casanova, Edf. Riva, Local 2-1. Planta Baja. Los Cortijos. Caracas – Venezuela',
                                  'country': 'Venezuela',
                                  'state': 'Dtto Capital',
                                  'city': 'Caracas',
                                  'phone': '+58 212 3541161',
                                  'email': 'ldimire@gmail.com',
                                  'nit': 'N123465600',
                                  'codeZone': '145',
                                  'nameSeller': 'Luisa León',
                                  'rifSeller': 'V102385358',
                                  'phoneSeller': '0414 3541160',
                                  'typeAgreement': 'MRW',
                                  'enable': 1
                               }";

                String response1 = clientHttp.PostObjetc("api-clients/Distributors", json1);

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

        #region Post Distributor-Provider
        [TestMethod]
        public void TestPostDistributorsProviders()
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
                                   'rif': 'J293987130',
                                   'description': 'Impresoras Fiscales 421 C.A',
                                   'address': 'La California Norte, Av. Fco. Miranda, Torre Profesional La California, piso 9.',
                                   'phone': '582122354145',
                                   'email': 'contac@impresoras421.com',
                                   'image': '0'
                               }";

                String response1 = clientHttp.PostObjetc("api-clients/Distributors/4/Providers", json1);

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

        #region Post Distributor-User
        [TestMethod]
        public void TestPostDistributorsUsers()
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

                String response1 = clientHttp.PostObjetc("api-clients/Distributors/4/6", "");

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

        #region Put Distributor
        [TestMethod]
        public void TestPutDistributor()
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
                                  'idSA': 345,
                                  'rif': 'J402385358',
                                  'description': 'Remall S.A',
                                  'represent': 'Alejandro Cordona',
                                  'address': 'Avenida Lecuna, Edf. Riva, Local 2-1. Planta Baja. Los Cortijos. Caracas – Venezuel',
                                  'country': 'Venezuela',
                                  'state': 'Dtto Capital',
                                  'city': 'Caracas',
                                  'phone': '+58 212 3541160',
                                  'email': 'promasa@gmail.com',
                                  'nit': 'N1234656',
                                  'codeZone': '12345',
                                  'nameSeller': 'Luis Perez',
                                  'rifSeller': 'J402385358',
                                  'phoneSeller': '0412 3541160',
                                  'typeAgreement': 'Tealca',
                                  'enable': 1
                                }";

                String response1 = clientHttp.PutObjetc("api-clients/Distributors", "2", json1);

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

        #region Delete Distributor
        [TestMethod]
        public void TestDeleteDistributor()
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
                string response1 = clientHttp.DeleteObjetc("api-clients/Distributors", "2");

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

        #region Delete Distributor-Provider
        [TestMethod]
        public void TestDeleteDistributorsProviders()
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
              
                String response1 = clientHttp.DeleteObjetc("api-clients/Distributors/4/Providers", "2");

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

        #region Delete Distributor-User
        [TestMethod]
        public void TestDeleteDistributorsUsers()
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

                String response1 = clientHttp.DeleteObjetc("api-clients/Distributors/4/Users", "6");

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

        //Technician

        #region Get Technicians
        [TestMethod]
        public void TestGetTechnicians()
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
                string json1 = clientHttp.GetObjetcsAll("api-clients/Technicians");
                List<Technician> list = TypeModel<Technician>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #region Get Technicians of Distribuitor
        [TestMethod]
        public void TestGetTechniciansDistribuitor()
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
                string json1 = clientHttp.GetObjetcsAll("api-clients/Distributors/1/Technicians");
                List<Technician> list = TypeModel<Technician>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #region Get Technician
        [TestMethod]
        public void TestGetTechnician()
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

                string json1 = clientHttp.GetObjetc("api-clients/Technicians", "2");
                Technician Technician = TypeModel<Technician>.DeserializeInObject(json1);

                Assert.IsTrue(Technician != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #region Post Technician
        [TestMethod]
        public void TestPostTechnicians()
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
                                  'rif': 'V-88838535-1',
                                  'description': 'Veronica Gomez',
                                  'address': 'Avenida Casanova, Edf. Riva, Local 2-1. Planta Baja. Los Cortijos. Caracas – Venezuela',
                                  'phone': '+58 212 3541161',
                                  'email': 'vgomez2@tfhka.com',
                                  'enable': 1
                               }";

                String response1 = clientHttp.PostObjetc("api-clients/Technicians", json1);

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

        #region Put Technician
        [TestMethod]
        public void TestPutTechnician()
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
                                  'id': 3,
                                  'rif': 'V-88838535-9',
                                  'description': 'Veronica Gomez',
                                  'address': 'Av. Libertador, Edf. Riva, Local 3-1. Planta Baja. Los Cortijos. Caracas – Venezuela',
                                  'phone': '+58 212 3541161',
                                  'email': 'vgomez@tfhka.com',
                                  'enable': 0
                               }";

                String response1 = clientHttp.PutObjetc("api-clients/Technicians", "3", json1);

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

        #region Delete Technician
        [TestMethod]
        public void TestDeleteTechnician()
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
                string response1 = clientHttp.DeleteObjetc("api-clients/Technicians", "5");

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

        #region Post Technician-Distributor
        [TestMethod]
        public void TestPostTechniciansDistributors()
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
                                  'idSA': 345,
                                  'rif': 'J755385359',
                                  'description': 'Importadora Post 777 C.A II',
                                  'represent': 'Luis Damiro',
                                  'address': 'Avenida Casanova, Edf. Riva, Local 2-1. Planta Baja. Los Cortijos. Caracas – Venezuela',
                                  'country': 'Venezuela',
                                  'state': 'Dtto Capital',
                                  'city': 'Caracas',
                                  'phone': '+58 212 3541161',
                                  'email': 'ldimire@gmail.com',
                                  'nit': 'N123465600',
                                  'codeZone': '145',
                                  'nameSeller': 'Luisa León',
                                  'rifSeller': 'V102385358',
                                  'phoneSeller': '0414 3541160',
                                  'typeAgreement': 'MRW',
                                  'enable': 1
                               }";

                String response1 = clientHttp.PostObjetc("api-clients/Technicians/5/Distributors", json1);

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

        #region Delete Technician-Distributor
        [TestMethod]
        public void TestDeleteTechniciansDistributors()
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

                String response1 = clientHttp.DeleteObjetc("api-clients/Technicians/5/Distributors", "1");

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

        #region Post Technician-User
        [TestMethod]
        public void TestPostTechniciansUsers()
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

                String response1 = clientHttp.PostObjetc("api-clients/Technicians/4/29", "");

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

        #region Delete Technician-User
        [TestMethod]
        public void TestDeleteTechniciansUsers()
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

                String response1 = clientHttp.DeleteObjetc("api-clients/Technicians/4/Users", "29");

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

        //DevelopersClients

        #region Get DevelopersClients
        [TestMethod]
        public void TestGetDevelopersClients()
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
                string json1 = clientHttp.GetObjetcsAll("api-clients/DevelopersClients");
                List<DevelopersClients> list = TypeModel<DevelopersClients>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #region Get DeveloperClient
        [TestMethod]
        public void TestGetDeveloperClient()
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

                string json1 = clientHttp.GetObjetc("api-clients/DevelopersClients", "1");
                DevelopersClients DevelopersClients = TypeModel<DevelopersClients>.DeserializeInObject(json1);

                Assert.IsTrue(DevelopersClients != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #region Post DevelopersClients
        [TestMethod]
        public void TestPostDevelopersClients()
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
                                  'document': 'J309056017',
                                  'description': 'SISTEM CHILE C.A.',
                                  'address': 'Avenida Casanova, Edf. Riva, Local 2-1. Planta Baja. Los Cortijos. Caracas – Venezuela',
                                  'country': 'Chile',
                                  'state': 'Carabobo',
                                  'city': 'Valencia',
                                  'phone': '+58 212 3541161',
                                  'email': 'sismex@gmail.com',
                                  'enable': 1
                               }";

                String response1 = clientHttp.PostObjetc("api-clients/DevelopersClients", json1);

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

        #region Put DevelopersClients
        [TestMethod]
        public void TestPutDevelopersClients()
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
                                  'id': 3,
                                  'document': 'J309056017',
                                  'description': 'SISTEM CHILE C.A.',
                                  'address': 'Avenida Casanova, Edf. Riva, Local 2-1. Planta Baja. Los Cortijos. Caracas – Venezuela',
                                  'country': 'Chile',
                                  'state': 'Carabobo',
                                  'city': 'Valencia',
                                  'phone': '+58 212 3541161',
                                  'email': 'sismex@gmail.com',
                                  'enable': 1
                               }";

                String response1 = clientHttp.PutObjetc("api-clients/Technicians", "3", json1);

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

        #region Delete DevelopersClients
        [TestMethod]
        public void TestDeleteDevelopersClients()
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
                string response1 = clientHttp.DeleteObjetc("api-clients/DevelopersClients", "5");

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

        #region Post DevelopersClients-User
        [TestMethod]
        public void TestPostDevelopersClientsusers()
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

                String response1 = clientHttp.PostObjetc("api-clients/DevelopersClients/1/1", "");

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

        #region Delete DevelopersClients-User
        [TestMethod]
        public void TestDeleteDevelopersClientsusers()
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

                String response1 = clientHttp.DeleteObjetc("api-clients/DevelopersClients/1/Users", "1");

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
