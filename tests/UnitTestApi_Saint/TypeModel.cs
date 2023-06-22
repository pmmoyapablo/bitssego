﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UnitTestApi_Saint
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