using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UnitTestApi_Access
{
    [TestClass]
    public class UnitTestAccess
    {
        //DEV
        //private string URL = "https://localhost:44330/";
        //IIS Local
        private string URL = "http://localhost/ApisSgo/";
        //Ambiente de TEST en Servidor Local
        //private string URL = "http://192.168.0.73/ApisSgo/";

        // Roles

        #region Get Roles
        [TestMethod]
        public void TestGetRoles()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                string json = clientHttp.GetObjetcsAll("api-access/Roles");
                List<Rol> list = TypeModel<Rol>.DeserializeInArray(json);

                Assert.IsTrue(list.Count > 0);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Get Rol
        [TestMethod]
        public void TestGetRol()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                string json = clientHttp.GetObjetc("api-access/Roles", "7");
                Rol rol = TypeModel<Rol>.DeserializeInObject(json);

                Assert.IsTrue(rol != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Post Rol
        [TestMethod]
        public void TestPostRol()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);

                String json = @"{
                                    'id': 0,
                                    'description': 'Rol Test 2',
                                    'accessId': 5,
                                    'profileId': 2
                                }";

                String response = clientHttp.PostObjetc("api-access/Roles", json);

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

        #region Put Rol
        [TestMethod]
        public void TestPutRol()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);

                String json = @"{
                                    'id': 24,
                                    'description': 'Rol Teta',
                                    'accessId': 8,
                                    'profileId': 3
                                }";

                String response = clientHttp.PutObjetc("api-access/Roles", "24", json);

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

        #region Delete Rol
        [TestMethod]
        public void TestDeleteRol()
        {
            try
            {
                ClientHttpREST clientHttp = new ClientHttpREST(URL);
                string response = clientHttp.DeleteObjetc("api-access/Roles", "24");

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

        // Users

        #region Get Users
        [TestMethod]
        public void TestGetUsers()
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

                clientHttp = new ClientHttpREST(URL,token);
                string json1 = clientHttp.GetObjetcsAll("api-access/Users");
                List<User> list = TypeModel<User>.DeserializeInArray(json1);

                Assert.IsTrue(list != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Get User
        [TestMethod]
        public void TestGetUser()
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
                string json1 = clientHttp.GetObjetc("api-access/Users", "2");
                User us = TypeModel<User>.DeserializeInObject(json1);

                Assert.IsTrue(us != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Post User
        [TestMethod]
        public void TestPostUser()
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

                String json1 = @"{  'id':0,
                                    'rolId':10,
                                    'username':'vgomez@tfhka.com',
                                    'password':'Coyote555',
                                    'enable':1
                                }";

                String response1 = clientHttp.PostObjetc("api-access/Users", json1);

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

        #region Put User
        [TestMethod]
        public void TestPutUser()
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
	                                'id':20,
                                    'rolId':10,
                                    'username':'coyota@hotmail.com',
                                    'password':'Lunas345',
                                    'enable':0
                                }";

                String response1 = clientHttp.PutObjetc("api-access/Users", "20", json1);

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

        #region Delete User
        [TestMethod]
        public void TestDeleteUser()
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
                string response1 = clientHttp.DeleteObjetc("api-access/Users", "20");

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

        // Login

        #region Post Login
        [TestMethod]
        public void TestPostLogin()
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

                if (response.Equals("OK") && tokenObj.authenticated && tokenObj.accessToken != "" && tokenObj.userData.id != 0) 
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

        // Menu

        #region Get Menus
        [TestMethod]
        public void TestGetMenus()
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
                string json1 = clientHttp.GetObjetcsAll("api-access/Menus");
                List<Menu> list = TypeModel<Menu>.DeserializeInArray(json1);

                Assert.IsTrue(list != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Get Menu
        [TestMethod]
        public void TestGetMenu()
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
                string json1 = clientHttp.GetObjetc("api-access/Menus", "2");
                Menu mn = TypeModel<Menu>.DeserializeInObject(json1);

                Assert.IsTrue(mn != null);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Post Menu
        [TestMethod]
        public void TestPostMenu()
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

                String json1 = @"{  'id':0,
                                    'name':'Enajenaciones',
                                    'parentId':0,
                                    'view':'Index',
                                    'level':1,
                                    'order':8,
                                    'url':'Alliennations/',
                                    'visible': 1,
                                    'path_icon':'Image/enage.ico'
                                 }";

                String response1 = clientHttp.PostObjetc("api-access/Menus", json1);

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

        #region Put Menu
        [TestMethod]
        public void TestPutMenu()
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

                String json1 = @"{  'id':15,
                                    'name':'Fiscalizaciones',
                                    'parentId':0,
                                    'view':'Index',
                                    'level':1,
                                    'order':7,
                                    'url':'Alliennations/',
                                    'visible': 0,
                                    'path_icon':'Image/enage.ico'
                                 }";

                String response1 = clientHttp.PutObjetc("api-access/Menus", "15", json1);

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

        #region Delete Menu
        [TestMethod]
        public void TestDeleteMenu()
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
                string response1 = clientHttp.DeleteObjetc("api-access/Menus", "15");

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

        // Roles/{id}/Menus 

        #region Get Roles/{id}/Menus
        [TestMethod]
        public void TestGetRolesMenu()
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
                string json1 = clientHttp.GetObjetcsAll("api-access/Roles/1/Menus");
                List<Menu> list = TypeModel<Menu>.DeserializeInArray(json1);

                if (list.Count > 0)
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

        #region Post Roles/{id}/Menus
        [TestMethod]
        public void TestPostRolesMenus()
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

                String json1 = @"{  'id':15,
                                    'name':'Fiscalizaciones',
                                    'parentId':0,
                                    'view':'Index',
                                    'level':1,
                                    'order':7,
                                    'url':'Alliennations/',
                                    'visible': 1,
                                    'path_icon':'Image/enage.ico'
                                     }";

                String response1 = clientHttp.PostObjetc("api-access/Roles/4/Menus", json1);

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

        #region Put Roles/{id}/Menus
        [TestMethod]
        public void TestPutRolesMenu()
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

                String json1 = @"{       'id':15,
                                    'name':'Fiscalizaciones',
                                    'parentId':0,
                                    'view':'Index',
                                    'level':1,
                                    'order':7,
                                    'url':'Alliennations/',
                                    'visible': 1,
                                    'path_icon':'Image/enage.ico'
                                     }";

                String response1 = clientHttp.PutObjetc("api-access/Roles/4/Menus", "3", json1);

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

        class User
        {
            public int id { get; set; }
            public int rolId { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public int enable { get; set; }
            public DateTime creation_date { get; set; }
            public Rol rol { get; set; }
        }

        public class Rol
        {
            public int id { get; set; }
            public string description { get; set; }
            public int accessId { get; set; }
            public int profileId { get; set; }
            public DateTime creation_date { get; set; }
            public Access access { get; set; }
            public Profile profile { get; set; }
        }
       public class Access
        {
            public int id { get; set; }
            public int level { get; set; }
            public string description { get; set; }
            public DateTime creation_date { get; set; }
        }

        public class Profile
        {
            public int id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public DateTime creation_date { get; set; }
        }

        public class Menu
        {
            public int id { get; set; }
            public string name { get; set; }
            public int parentId { get; set; }
            public string view { get; set; }
            public int level { get; set; }
            public int order { get; set; }
            public string url { get; set; }
            public int visible { get; set; }
            public string path_icon { get; set; }
            public DateTime creation_date { get; set; }
        }

        #endregion
    }
}
