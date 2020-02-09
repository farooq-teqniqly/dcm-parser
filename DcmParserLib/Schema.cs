using System.Collections.Generic;

namespace DcmParserLib
{
    public class Schema
    {
        public Schema()
        {
            Fields = new List<Field>();
        }

        public string Type { get; set; }
        public List<Field> Fields { get; set; }
    }
}