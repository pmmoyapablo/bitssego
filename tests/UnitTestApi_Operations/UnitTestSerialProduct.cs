using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestApi_Operations
{
    [TestClass]
    public class UnitTestSerialProduct
    {
        //private string URL = "https://localhost:44330/";

        private string URL = "http://localhost/ApisSgo/";

        #region GET  api-operations/SerialsProducts
        [TestMethod]
        public void TestGetSerialsProducts()
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

                string json1 = clientHttp.GetObjetcsAll("api-operations/SerialsProducts");
                List<SerialProduct> list = TypeModel<SerialProduct>.DeserializeInArray(json1);

                Assert.IsTrue(list.Count > 0);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }


        #endregion

        #region GET api-operations/SerialsProducts/4

        [TestMethod]
        public void TestGetSerialsProductsDetails()
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

                string json1 = clientHttp.GetObjetc("api-operations/SerialsProducts", "4");
                SerialProduct serial = TypeModel<SerialProduct>.DeserializeInObject(json1);

                Assert.IsTrue(serial != null);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        #endregion

        #region GET api-operations/SerialsProducts/BySerial/Z1B8100007

        [TestMethod]
        public void TestGetSerialsProductsByRe()
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

                string json1 = clientHttp.GetObjetc("api-operations/SerialsProducts/BySerial", "Z1B8100007");
                SerialProduct serial = TypeModel<SerialProduct>.DeserializeInObject(json1);

                Assert.IsTrue(serial != null);

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        #endregion

        #region POST api-operations/SerialsProducts

        [TestMethod]
        public void TestPostSerialsProducts()
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
                                    'serial': 'Z1B4444555',
                                    'productId': 1,
                                    'distributorId': 7,
                                    'providerId': 1,
                                    'dateSale': '2020-03-09T14:52:00'
                              }";

                String response1 = clientHttp.PostObjetc("api-operations/SerialsProducts", json1);

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

        #region PUT  api-operations/SerialsProducts

        [TestMethod]
        public void TestPutSerialsProducts()
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
                                    'id': 4,
                                    'serial': 'Z1B4444545',
                                    'productId': 1,
                                    'distributorId': 15,
                                    'providerId': 1,
                                    'dateSale': '2020-03-09T14:52:00',
                                    'creation_Date': '2020-03-12T08:45:06.3427379-04:00'
                               }";

                String response1 = clientHttp.PutObjetc("api-operations/SerialsProducts", "4", json1);

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


        #region DELETE   api-operations/SerialsProducts
        [TestMethod]
        public void TestDeleteSerialsProducts()
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

                string response1 = clientHttp.DeleteObjetc("api-operations/SerialsProducts", "4");

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

    public class User
    {
        public int id { get; set; }
        public int rolId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int enable { get; set; }
        public DateTime creation_date { get; set; }

        public Rol rol { get; set; }
    }


    public class SerialProduct
    {
        public int Id { get; set; }
        public string Serial { get; set; }
        public int ProductId { get; set; }
        public int DistributorId { get; set; }
        public int ProviderId { get; set; }
        public DateTime DateSale { get; set; }
        public DateTime Creation_Date { get; set; }

        public Product product { get; set; }
        public Provider provider { get; set; }
        public Distributor distributor { get; set; }
    }


    public class SerialReplacement
    {
        public int Id { get; set; }
        public string Serial { get; set; }
        public int ReplacementId { get; set; }
        public int DistributorId { get; set; }
        public int ProviderId { get; set; }
        public DateTime DateSale { get; set; }
        public string Observations { get; set; }
        public DateTime Creation_Date { get; set; }

        public Replacement replacement { get; set; }
        public Provider provider { get; set; }
        public Distributor distributor { get; set; }
    }


    public class Rol
    {
        public int id { get; set; }
        public string description { get; set; }
        public int accessId { get; set; }
        public int profileId { get; set; }
        public DateTime creation_date { get; set; }
        //public Access access { get; set; }
        //public Profile profile { get; set; }
    }

    public class Replacement
    {
        public int Id { get; set; }
        public int PrefixId { get; set; }
        public int ModelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string Parts { get; set; }
        public int State { get; set; }
        public string ImageUrl { get; set; }
        public DateTime creation_date { get; set; }
        public Model Model { get; set; }
        public Prefix Prefix { get; set; }
    }



    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MarkId { get; set; }
        public DateTime creation_date { get; set; }
        public Mark Mark { get; set; }
    }


    public class Prefix
    {
        public int id { get; set; }
        public string initCorrelative { get; set; }
        public string initAlphaNum { get; set; }
        public DateTime creation_date { get; set; }
    }


    public class Mark
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime creation_date { get; set; }
    }


    public class Distributor
    {
        public int id { get; set; }
        public int idSA { get; set; }
        public string rif { get; set; }
        public string description { get; set; }
        public string represent { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string nit { get; set; }
        public string codeZone { get; set; }
        public string nameSeller { get; set; }
        public string rifSeller { get; set; }
        public string phoneSeller { get; set; }
        public string typeAgreement { get; set; }
        public int enable { get; set; }
        public DateTime creation_date { get; set; }
    }

    public class Provider
    {
        public int id { get; set; }
        public string rif { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string image { get; set; }
        public DateTime creation_date { get; set; }
    }


    public class Product
    {
        public int Id { get; set; }
        public int PrefixId { get; set; }
        public int CategoryId { get; set; }
        public int ModelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int State { get; set; }
        public string ImageUrl { get; set; }
        public DateTime creation_date { get; set; }
        public Category Category { get; set; }
        public Model Model { get; set; }
        public Prefix Prefix { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime creation_date { get; set; }

    }

    #endregion

}
