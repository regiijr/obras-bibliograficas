using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ObrasBibliográficasAPI.Database;

namespace ObrasBibliográficasAPI.Models
{
    public class NameResult
    {
        public bool result { get; set; }
        public List<TblNames> Names { get; set; }
    }
}
