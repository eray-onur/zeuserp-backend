using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ZeusERP.Core.Utilities
{
    public static class WebConfig
    {
        public static string GetConfigItem(string item)
        {
            var ConnectionString = string.Empty;
            try
            {
                var appSettings = File.ReadAllText($"{Directory.GetCurrentDirectory()}/appsettings.json", Encoding.UTF8);
                var json = JsonConvert.DeserializeObject<JObject>(appSettings);
                ConnectionString = json.GetValue("ConnectionStrings").Value<dynamic>(item);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
            return ConnectionString;
        }
    }
}
