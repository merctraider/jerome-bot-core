using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace JeromeBot
{
    class TextHandler
    {
        private static Dictionary<string, string> texts;
        public static string _fileName = "augustineconfessions";

        static TextHandler()
        {
            if (!File.Exists("Writings/" + _fileName + ".json"))
            {
                GetContents("Error");
            } else
            {
                string json = File.ReadAllText("Writings/" + _fileName + ".json");
                var data = JsonConvert.DeserializeObject<dynamic>(json);
                texts = data.ToObject<Dictionary<string, string>>();
            }
            
        }



        /*public static void GetText (string fileName, string contents)
        {
            _fileName = fileName; //Set file name
                        
        }*/

        public static string GetContents(string contents)
        {
            if (texts.ContainsKey(contents)) return texts[contents];
            return "Text not found!";
        }



    }
}
