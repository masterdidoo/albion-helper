using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Albion.Db.Xml.Entity.Building
{
    /// <remarks />
    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class CraftingItemList
    {
        /// <remarks />
        [XmlElement("craftitem", Form = XmlSchemaForm.Unqualified)]
        public CraftItem[] craftitem { get; set; }

        /// <remarks />
        [XmlAttribute]
        public string recipefilter { get; set; }
    }
}