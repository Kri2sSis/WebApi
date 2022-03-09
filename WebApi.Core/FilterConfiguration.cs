using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core
{
    public class FilterConfiguration
    {
        public string? Sex { get; set; }

        public int AgeMin { get; set; }

        public int AgeMax { get; set; }
    }
}
