using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestApi_Saint
{
    [TestClass]
    public class UnitTestSaint
    {
        //DEV
        private string URL = "https://localhost:44316/";
        //IIS Local
        //private string URL = "http://localhost/ApiSaint/";
        //Ambiente de TEST en Servidor Local
        //private string URL = "http://192.168.0.73/ApiSaint/";

        //Consulta de CLiente en SAINT The Factory HKA
        [TestMethod]
        public void TestMethodGet1()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                string json = clientHttp.GetObjetc("api/Customers", "1/J-87521244-8");
                ClientSaint clieSaint = TypeModel<ClientSaint>.DeserializeInObject(json);

                Assert.IsTrue(clieSaint.isSerializerData && clieSaint.description != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        //Consulta de CLiente en SAINT Impresoras Fiscales 421
        [TestMethod]
        public void TestMethodGet2()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                string json = clientHttp.GetObjetc("api/Customers", "2/J-98765445-5");
                ClientSaint clieSaint = TypeModel<ClientSaint>.DeserializeInObject(json);

                Assert.IsTrue(clieSaint.isSerializerData && clieSaint.description != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        class Seller
        {
            public string code;
            public string name;
            public string idFiscal;
            public string email;
            public string phone;
        }

        class ClientSaint {
            public string message;
            public bool isSerializerData;
            public string code;
            public string description;
            public string rif;
            public string nit;
            public string represent;
            public short enable;
            public string email;
            public Seller seller;
            public string address1;
            public string address2;
            public string city;
            public string state;
            public string country;
            public string phone;
    }
    }
}
