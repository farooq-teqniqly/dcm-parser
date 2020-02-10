using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcmParserLib.Abstractions
{
    public interface IParseable
    {
        void Accept(INodeParser nodeParser);
    }
}
