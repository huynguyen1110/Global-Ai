using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.DataAccess.Models
{
    public class PagingResult<T>
    {
        public IEnumerable<T> Items { get; set; }
        public decimal TotalItems { get; set; }
    }
}
