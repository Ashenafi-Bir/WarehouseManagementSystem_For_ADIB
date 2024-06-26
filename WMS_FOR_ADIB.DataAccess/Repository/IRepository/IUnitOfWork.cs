using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS_FOR_ADIB.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IItemRepository Item { get; }
        void Save();
    }
}
