using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST.Models
{
    public class DataController
    {
        public List<string> getManagerList()
        {
            List<string> result = new List<string>();

            result.Add("CLM");
            result.Add("SAM");
            result.Add("SET");
            return result;
        }
    }
}
