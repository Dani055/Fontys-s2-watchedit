using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibraries.models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Newtonsoft.Json;

namespace WatchedItWeb
{
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            }));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
        }
        public static User GetLoggedUser(this ISession session)
        {
            return session.GetObject<User>("loggedUser");
        }
        public static Movie GetMovie(this ISession session)
        {
            return session.GetObject<Movie>("movie");
        }
        public static bool IsAdmin(this ISession session)
        {
            if (session.GetObject<User>("loggedUser") == null)
            {
                return false;
            }
            return session.GetObject<User>("loggedUser").IsAdmin;
        }
    }
}
