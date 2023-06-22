using Api_Access.Models;
using Api_Products.Models;
using Api_Clients.Models;
using Api_Employees.Models;
using Api_WorksOrders.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace UnitTestApi_WorksOrders
{
    [TestClass]
    public class UnitTestWorksOrders
    {
        //DEV
        //private string URL = "https://localhost:44330/";
        //IIS Local
        private string URL = "http://localhost:81/";
        //Ambiente de TEST en Servidor Local
        //private string URL = "http://192.168.0.73:81/";

        //StatesOrder

        #region Get StatesOrder
        [TestMethod]
            public void TestGetStatesOrder()
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
                    string json1 = clientHttp.GetObjetcsAll("api-worksorders/statesorder");
                    List<StatesOrder> list = TypeModel<StatesOrder>.DeserializeInArray(json1);

                    Assert.IsTrue(list.Count > 0);
                }
                catch (Exception ex)
                {
                    Assert.Fail(ex.Message);
                }
            }
            #endregion

        #region Get StateOrder
        [TestMethod]
        public void TestGetStateOrder()
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

                string json1 = clientHttp.GetObjetc("api-worksorders/statesorder", "1");
                StatesOrder stateOrder = TypeModel<StatesOrder>.DeserializeInObject(json1);

                Assert.IsTrue(stateOrder != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Post StateOrder
        [TestMethod]
        public void TestPostStateOrder()
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
                                  'description': 'nombre de un estado de orden de taller'      
                                  }";

                String response1 = clientHttp.PostObjetc("api-worksorders/statesorder", json1);

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

        #region Put StateOrder
        [TestMethod]
        public void TestPutStateOrder()
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
                                  'id': 14,                
                                  'description': 'modificando nombre de estado de orden de taller'      
                                  }";

                String response1 = clientHttp.PutObjetc("api-worksorders/statesorder", "14", json1);

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

        #region Delete StateOrder
        [TestMethod]
        public void TestDeleteStateOrder()
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
                string response1 = clientHttp.DeleteObjetc("api-worksorders/statesorder", "14");

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

        //TypeFailures

        #region Get TypeFailures
        [TestMethod]
        public void TestGetTypeFailures()
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
                string json1 = clientHttp.GetObjetcsAll("api-worksorders/typefailures");
                List<TypeFailure> list = TypeModel<TypeFailure>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Get TypeFailure
        [TestMethod]
        public void TestGetTypeFailure()
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

                string json1 = clientHttp.GetObjetc("api-worksorders/typefailures", "1");
                TypeFailure typeFailure = TypeModel<TypeFailure>.DeserializeInObject(json1);

                Assert.IsTrue(typeFailure != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Post TypeFailure
        [TestMethod]
        public void TestPostTypeFailure()
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
                                  'description': 'nombre de un tipo de falla'      
                                  }";

                String response1 = clientHttp.PostObjetc("api-worksorders/typefailures", json1);

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

        #region Put TypeFailure
        [TestMethod]
        public void TestPutTypeFailure()
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
                                  'id': 43,                
                                  'description': 'modificando nombre de un tipo de falla'      
                                  }";

                String response1 = clientHttp.PutObjetc("api-worksorders/typefailures", "43", json1);

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

        #region Delete TypeFailure
        [TestMethod]
        public void TestDeleteTypeFailure()
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
                string response1 = clientHttp.DeleteObjetc("api-worksorders/typefailures", "43");

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

        //AccessoriesOrders

        #region Get AccessoriesOrders
        [TestMethod]
        public void TestGetAccessoriesOrders()
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
                string json1 = clientHttp.GetObjetcsAll("api-worksorders/accessoryorder");
                List<AccessoryOrder> list = TypeModel<AccessoryOrder>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Get AccessoryOrder
        [TestMethod]
        public void TestGetAccessoryOrder()
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

                string json1 = clientHttp.GetObjetc("api-worksorders/accessoryorder", "1");
                AccessoryOrder accessoryOrder = TypeModel<AccessoryOrder>.DeserializeInObject(json1);

                Assert.IsTrue(accessoryOrder != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region GET api/AccessoryOrder/byOrder/123B
        [TestMethod]
        public void TestGetAccessorybyOrder()
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

                string json1 = clientHttp.GetObjetc("api-worksorders/accessoryorder/byOrder", "123B");

                List<AccessoryOrder> list = TypeModel<AccessoryOrder>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);
            }
            catch (Exception ex)

            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Post AccessoryOrder
        [TestMethod]
        public void TestPostAccessoryOrder()
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
                                  'orderId': 1, 
                                  'accesoryId': 3     
                                  }";

                String response1 = clientHttp.PostObjetc("api-worksorders/accessoryorder", json1);

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

        #region Put AccessoryOrder
        [TestMethod]
        public void TestPutAccessoryOrder()
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
                                  'orderId': 1, 
                                  'accesoryId': 3     
                                  }";

                String response1 = clientHttp.PutObjetc("api-worksorders/accessoryorder", "2", json1);

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

        #region Delete AccessoryOrder
        [TestMethod]
        public void TestDeleteAccessoryOrder()
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
                string response1 = clientHttp.DeleteObjetc("api-worksorders/accessoryorder", "2");

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

        //DeliveryOrder

        #region Get DeliveryOrders
        [TestMethod]
        public void TestGetDeliveryOrders()
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
                string json1 = clientHttp.GetObjetcsAll("api-worksorders/deliveryorder");
                List<DeliveryOrder> list = TypeModel<DeliveryOrder>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Get DeliveryOrder
        [TestMethod]
        public void TestGetDeliveryOrder()
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

                string json1 = clientHttp.GetObjetc("api-worksorders/deliveryorder", "1");
                DeliveryOrder deliveryOrder = TypeModel<DeliveryOrder>.DeserializeInObject(json1);

                Assert.IsTrue(deliveryOrder != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Post DeliveryOrder
        [TestMethod]
        public void TestPostDeliveryOrder()
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
                                  'deliveryMode': 1, 
                                  'liableId': 20540566,
                                  'liableName': 'nombre responsable',
                                  'liablePhone': '+58 212 3541161',
                                  'guideNumber': 'nro guia', 
                                  'companyName': 'MRV',
                                  'address': 'direccion', 
                                  'observation': 'observaciones',
                                  'dispatchDate': '2020-03-27T13:44:24'
                                  }";

                String response1 = clientHttp.PostObjetc("api-worksorders/deliveryorder", json1);

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

        #region Put DeliveryOrder
        [TestMethod]
        public void TestPutDeliveryOrder()
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
                                  'deliveryMode': 1, 
                                  'liableId': 20540566,
                                  'liableName': 'actualizado nombre responsable',
                                  'liablePhone': '+58 212 3541161',
                                  'guideNumber': 'nro guia', 
                                  'companyName': 'MRV',
                                  'address': 'direccion', 
                                  'observation': 'observaciones',
                                  'dispatchDate': '2020-03-27T13:44:24'
                                  }";

                String response1 = clientHttp.PutObjetc("api-worksorders/deliveryorder", "1", json1);

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

        #region Delete DeliveryOrder
        [TestMethod]
        public void TestDeleteDeliveryOrder()
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
                string response1 = clientHttp.DeleteObjetc("api-worksorders/deliveryorder", "4");

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

        //PhotographsOrder

        #region Get PhotographsOrders
        [TestMethod]
        public void TestGetPhotographsOrders()
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
                string json1 = clientHttp.GetObjetcsAll("api-worksorders/photographorder");
                List<PhotographOrder> list = TypeModel<PhotographOrder>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Get PhotographsOrder
        [TestMethod]
        public void TestGetPhotographsOrder()
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

                string json1 = clientHttp.GetObjetc("api-worksorders/photographorder", "1");
                PhotographOrder photographOrder = TypeModel<PhotographOrder>.DeserializeInObject(json1);

                Assert.IsTrue(photographOrder != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Post PhotographsOrder
        [TestMethod]
        public void TestPostPhotographsOrder()
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
                                  'orderId': 1, 
                                  'ImageUrl': 'ruta de la imagen', 
                                  'dispatchDate': '2020-03-27T13:44:24'
                                  }";

                String response1 = clientHttp.PostObjetc("api-worksorders/photographorder", json1);

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

        #region Put PhotographsOrder
        [TestMethod]
        public void TestPutPhotographsOrder()
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
                                  'orderId': 1, 
                                  'ImageUrl': 'Actualizada ruta de la imagen', 
                                  'dispatchDate': '2020-03-27T13:44:24'
                                  }";

                String response1 = clientHttp.PutObjetc("api-worksorders/photographorder", "2", json1);

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

        #region Delete PhotographsOrder
        [TestMethod]
        public void TestDeletePhotographsOrder()
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
                string response1 = clientHttp.DeleteObjetc("api-worksorders/photographorder", "2");

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

        //ReplacementsOrders

        #region Get ReplacementsOrders
        [TestMethod]
        public void TestGetReplacementsOrders()
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
                string json1 = clientHttp.GetObjetcsAll("api-worksorders/replacementorder");
                List<ReplacementOrder> list = TypeModel<ReplacementOrder>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Get ReplacementOrder
        [TestMethod]
        public void TestGetReplacementorder()
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

                string json1 = clientHttp.GetObjetc("api-worksorders/replacementorder", "1");
                ReplacementOrder replacementOrder = TypeModel<ReplacementOrder>.DeserializeInObject(json1);

                Assert.IsTrue(replacementOrder != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region GET api/ReplacementOrder/byOrder/123B
        [TestMethod]
        public void TestGetReplacementbyOrder()
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

                string json1 = clientHttp.GetObjetc("api-worksorders/replacementorder/byOrder", "123B");

                List<ReplacementOrder> list = TypeModel<ReplacementOrder>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Post ReplacementOrder
        [TestMethod]
        public void TestPostReplacementOrder()
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
                                  'orderId': 1, 
                                  'replacementId': 2     
                                  }";

                String response1 = clientHttp.PostObjetc("api-worksorders/replacementorder", json1);

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

        #region Put ReplacementOrder
        [TestMethod]
        public void TestPutReplacementOrder()
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
                                  'orderId': 1, 
                                  'replacementId': 4     
                                  }";

                String response1 = clientHttp.PutObjetc("api-worksorders/replacementorder", "2", json1);

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

        #region Delete ReplacementOrder
        [TestMethod]
        public void TestDeleteReplacementOrder()
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
                string response1 = clientHttp.DeleteObjetc("api-worksorders/replacementorder", "2");

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

        //WorkshopOrders

        #region Get WorkshopOrders
        [TestMethod]
        public void TestGetWorkshopOrders()
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
                string json1 = clientHttp.GetObjetcsAll("api-worksorders/workshoporder");
                List<WorkshopOrder> list = TypeModel<WorkshopOrder>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Get WorkshopOrder
        [TestMethod]
        public void TestGetWorkshopOrder()
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

                string json1 = clientHttp.GetObjetc("api-worksorders/workshoporder", "1");
                WorkshopOrder workshopOrder = TypeModel<WorkshopOrder>.DeserializeInObject(json1);

                Assert.IsTrue(workshopOrder != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Post WorkshopOrder
        [TestMethod]
        public void TestPostWorkshopOrder()
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
                                'numerOrder': '123C',
                                'kindEquipment': 1,
                                'equipment': 1,
                                'serial': 'Z1B8100007',
                                'warranty': null,
                                'firmwareVersion': null,
                                'deliverDate': null,
                                'receptionDate': null,
                                'alienationDate': null,
                                'expirationDate': null,
                                'address': 'Av. Lecuna esquina el conde',
                                'contact': 'Mauren Garcia',
                                'insertionOrigin': 1,
                                'workDone': null,
                                'customerReview': 'Solamente se envio la impresora',
                                'observationTechnical': null,
                                'creation_date': '2020-08-20T15:25:12',
                                'phone': null,
                                'distributorId': 8,                              
                                'typeFailurId': 6,                               
                                'stateOrderId': 1,                            
                                'deliveryOrderId': null,                             
                                'employeeId': 17,                             
                                'photoOrderId': null,
                                'photographOrder': null
                              }";

                String response1 = clientHttp.PostObjetc("api-worksorders/workshoporder", json1);

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

        #region Put WorkshopOrder
        [TestMethod]
        public void TestPutWorkshopOrder()
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
                                'numerOrder': '321C',
                                'kindEquipment': 1,
                                'equipment': 1,
                                'serial': 'Z1B8100007',
                                'warranty': null,
                                'firmwareVersion': null,
                                'deliverDate': null,
                                'receptionDate': null,
                                'alienationDate': null,
                                'expirationDate': null,
                                'address': 'direccion actualizada',
                                'contact': 'Mauren Garcia',
                                'insertionOrigin': 1,
                                'workDone': null,
                                'customerReview': 'Solamente se envio la impresora',
                                'observationTechnical': null,
                                'creation_date': '2020-08-20T15:25:12',
                                'phone': null,
                                'distributorId': 8,                              
                                'typeFailurId': 6,                               
                                'stateOrderId': 1,                            
                                'deliveryOrderId': null,                             
                                'employeeId': 17,                             
                                'photoOrderId': null,
                                'photographOrder': null
                            }";

                String response1 = clientHttp.PutObjetc("api-worksorders/workshoporder", "2", json1);

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

        #region Delete WorkshopOrder
        [TestMethod]
        public void TestDeleteWorkshopOrderr()
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
                string response1 = clientHttp.DeleteObjetc("api-worksorders/workshoporder", "2");

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

        //WorkshopBinnacle

        #region GET: api/WorkshopBinnacle
        [TestMethod]
        public void TestGetWorkshopBinnacles()
        {
          try
          {
            ClientHttpREST clientHttp = new ClientHttpREST(URL);
            String json = @"{       'username':'pmoya@thefactoryhka.com',
                                            'password':'Moneda32'
                                    }";

            string bodyResp = string.Empty;

            String response = clientHttp.PostObjetc("api-access/Login", json, out bodyResp);

            TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(bodyResp);

            string token = "Bearer " + tokenObj.accessToken;

            clientHttp = new ClientHttpREST(URL, token);
            string json1 = clientHttp.GetObjetcsAll("api-worksorders/WorkshopBinnacle");
            List<WorkshopBinnacle> list = TypeModel<WorkshopBinnacle>.DeserializeInArray(json1);
            Assert.IsTrue(list.Count > 0);
          }
          catch (Exception ex)
          {
            Assert.Fail(ex.Message);
          }
        }
        #endregion

        #region GET: api/WorkshopBinnacle/1
        [TestMethod]
        public void TestGetWorkshopBinnacle()
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

            string json1 = clientHttp.GetObjetc("api-worksorders/WorkshopBinnacle", "1");
            WorkshopBinnacle workshopBinnacle = TypeModel<WorkshopBinnacle>.DeserializeInObject(json1);

            Assert.IsTrue(workshopBinnacle != null);
          }
          catch (Exception ex)
          {
            Assert.Fail(ex.Message);
          }
        }
    #endregion

        #region GET: api/WorkshopBinnacle/ByOrderId/1
        [TestMethod]
        public void TestGetWorkshopBinnacleByOrderId()
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

            string json1 = clientHttp.GetObjetcsAll("api-worksorders/WorkshopBinnacle/ByOrderId", "1");
            List<WorkshopBinnacle> list = TypeModel<WorkshopBinnacle>.DeserializeInArray(json1);
            Assert.IsTrue(list.Count > 0);
          }
          catch (Exception ex)
          {
            Assert.Fail(ex.Message);
          }
        }
        #endregion

        #region POST:api/WorkshopBinnacle
        [TestMethod]
            public void TestPostWorkshopBinnacle()
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
                                    'Id': 0,
                                    'orderId': 95,    
                                    'statusId': 3,
                                    'userId': 8
                                          }";

                String response1 = clientHttp.PostObjetc("api-worksorders/WorkshopBinnacle", json1);

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

        #region PUT:api/WorkshopBinnacle
        [TestMethod]
        public void TestPutWorkshopBinnacle()
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
                                'Id': 6,
                                'orderId': 95,    
                                'statusId': 8,
                                'userId': 8 
                                      }";

            String response1 = clientHttp.PutObjetc("api-worksorders/WorkshopBinnacle", "6", json1);

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

        #region DELETE:api/WorkshopBinnacle
        [TestMethod]
        public void TestDeleteWorkshopBinnacle()
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
            string response1 = clientHttp.DeleteObjetc("api-worksorders/WorkshopBinnacle", "6");

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
