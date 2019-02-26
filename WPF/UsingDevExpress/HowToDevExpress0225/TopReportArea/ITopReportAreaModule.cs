using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopReportArea
{
    interface ITopReportAreaModule
    {
        string Caption { get; }
        bool IsActive { get; }
    }
}
