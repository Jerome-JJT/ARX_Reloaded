using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARX_Reloaded
{
    public class JsonManagement
    {
        private string fullPath;

        public JsonManagement()
        {
            string path = $"{Environment.GetEnvironmentVariable("appdata")}/ARXReloadedProfile";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            fullPath = $"{path}/ARXReloadedProfile.json";
        }


        public JsonData ExtractData()
        {
            StreamReader file = new StreamReader(fullPath);

            JsonData jsonContent = JsonConvert.DeserializeObject<JsonData>(file.ReadToEnd());

            file.Close();

            return jsonContent;
        }

        public void InsertData(JsonData data)
        {
            StreamWriter file = new StreamWriter(fullPath);

            file.Write(JsonConvert.SerializeObject(data, Formatting.Indented));

            file.Close();
        }
    }
}
