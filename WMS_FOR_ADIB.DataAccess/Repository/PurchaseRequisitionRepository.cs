﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS_FOR_ADIB.DataAccess.Data;
using WMS_FOR_ADIB.DataAccess.Repository.IRepository;
using WMS_FOR_ADIB.Models;

namespace WMS_FOR_ADIB.DataAccess.Repository
{
    public class PurchaseRequisitionRepository: Repository<PurchaseRequisition>, IPurchaseRequisitionRepository
    {
        private readonly ApplicationDbContext _db;
        public PurchaseRequisitionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(PurchaseRequisition requisition)
        {
            var objFromDb = _db.PurchaseRequisitions.FirstOrDefault(pr => pr.PRId == requisition.PRId);
            if (objFromDb != null)
            {
                objFromDb.PRNumber = requisition.PRNumber;
                objFromDb.Date = requisition.Date;
                objFromDb.RequestedBy = requisition.RequestedBy;
                objFromDb.AuthorizedBy = requisition.AuthorizedBy;

                _db.SaveChanges();
            }
        }

    }
}
