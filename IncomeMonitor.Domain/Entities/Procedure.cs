using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeMonitor.Domain.Entities
{
    public class Procedure
    {
            public int ProcedureId { get; set; }
            public string? Information { get; set; }
            public decimal Value { get; set; }
            public string? Note { get; set; }
            public DateTime ProcedureDate { get; set; }
    }
}
