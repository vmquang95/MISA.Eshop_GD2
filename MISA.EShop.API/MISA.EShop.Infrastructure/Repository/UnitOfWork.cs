using MISA.EShop.Core.Interfaces;
using MISA.EShop.Core.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.EShop.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IOrderBillRepository orderBillTask)
        {
            OrderBillTask = orderBillTask;
        }

        public IOrderBillRepository OrderBillTask { get; }
    }
}
