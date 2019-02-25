using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToDevExpress0225.Common
{
    public interface IDocumentModule
    {
        string Caption { get; }
        bool IsActive { get; set; }
    }
}
