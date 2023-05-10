using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneraIP
{
    /// <summary>
    /// interfaccia da implementare
    /// </summary>
    internal interface IAddress
    {
        string generateIPv4();
        string generateSubnet();
    }
}
