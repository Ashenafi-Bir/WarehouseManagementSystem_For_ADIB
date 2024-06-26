﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS_FOR_ADIB.Models;

namespace WMS_FOR_ADIB.DataAccess.Repository.IRepository
{
    public interface IItemRepository : IRepository<Item>
    {
        void Update(Item obj);
    }
}
