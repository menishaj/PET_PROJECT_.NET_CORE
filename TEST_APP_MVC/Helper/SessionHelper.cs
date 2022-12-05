using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

namespace TEST_APP_MVC.Helper
{
    public static class SessionHelper
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetCustomObjectn<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static bool AddObjectToJson<T>(this ISession session, string key, T data)
        {
            try
            {
                var sessionData = JsonConvert.SerializeObject(data);

                session.SetString(key, sessionData);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }            
        }
    }
}



