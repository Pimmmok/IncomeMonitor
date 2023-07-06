using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncomeMonitor.Domain.Entities;

namespace IncomeMonitor.Domain.Abstract
{
    public interface IProcedureRepository
    {
        IQueryable<Procedure> Procedures { get; }
}
}
