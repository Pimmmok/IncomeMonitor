using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeMonitor.Domain.Entities
{
    public class Procedure
    {
            public int Id { get; set; }
            public string? Information { get; set; }
            public float Value { get; set; }
            public string? Notes { get; set; }
            public DateTime ProcedureDate { get; set; }
    }
}
