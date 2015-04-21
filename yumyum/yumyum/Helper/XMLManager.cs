using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;
using yumyum.Xml;

namespace yumyum.Helper
{
    public class XMLManager
    {
        private static string GetFilePath
        {
            get 
            {
                var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "refresh_tokens.xml");
                return path;
            }
        }

        public static RefreshToken LoadFile ()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(RefreshToken));

            using (var stream = new StreamReader(GetFilePath))
            {
                return (RefreshToken)serializer.Deserialize(stream);
            }
        }

        public static bool SaveFile(RefreshToken tokens)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(RefreshToken));

                using (var stream = new StreamWriter(GetFilePath))
                {
                    serializer.Serialize(stream, tokens);
                }                

                return true;
            }
            catch (Exception)
            {
                return false;
                
            }
        }
    }
}