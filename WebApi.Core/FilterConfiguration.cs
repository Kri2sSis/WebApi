using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core
{
    public class FilterConfiguration
    {
        public string sex { get; set; } = null;

        public int ageMin { get; set; } = 0;

        public int ageMax { get; set; } = 0;
    }
}
