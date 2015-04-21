using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace yumyum.Xml
{
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class RefreshToken
    {
        private List<RefreshTokens> tokenField;

        /// <comentarios/>
        public List<RefreshTokens> token
        {
            get
            {
                return this.tokenField;
            }
            set
            {
                this.tokenField = value;
            }
        }
    }

    public partial class RefreshTokens
    {
        private string guiField;
        private string paramField;

        public string gui
        {
            get
            {
                return this.guiField;
            }
            set
            {
                this.guiField = value;
            }
        }

        public string param
        {
            get
            {
                return this.paramField;
            }
            set
            {
                this.paramField = value;
            }
        }
    }
}