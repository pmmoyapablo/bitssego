﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitTestApi_WorksOrders;

namespace UnitTestApi_WorksOrders
{
    public class TypeModel<T> where T : class
    {
        public static T DeserializeInObject(String pJsonDatas)
        {
            T model = JsonConvert.DeserializeObject<T>(pJsonDatas);

            return model;
        }

        public static List<T> DeserializeInArray(String pJsonDatas)
        {
            List<T> models = JsonConvert.DeserializeObject<List<T>>(pJsonDatas);

            return models;
        }
    }
}
