using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core
{
    public class FilterRequest
    {
        public PaginationConfiguration PaginationConfiguration { get; set; }

        public FilterConfiguration? FilterConfiguration { get; set; }
    }
}
