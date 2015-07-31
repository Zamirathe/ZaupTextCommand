using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ZaupTextCommands
{
    public sealed class TextCommand
    {
        public string Name;
        public string Help;
        [XmlArrayItem("Line")]
        public List<String> Text;
    }
}
