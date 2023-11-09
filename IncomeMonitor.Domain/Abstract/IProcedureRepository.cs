﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IncomeMonitor.Domain.Entities;

namespace IncomeMonitor.Domain.Abstract
{
    public interface IProcedureRepository
    {
        public IQueryable<Procedure> Procedurs { get; }

        public Task<int> AddProcedure(Procedure procedure);

        public Task<int> RemoveProcedure(Procedure procedure);


    }
}
