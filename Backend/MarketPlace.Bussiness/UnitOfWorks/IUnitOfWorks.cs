﻿using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.DataTransfer.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.UnitOfWorks
{
    public interface IUnitOfWorks
    {
       IGenericRepository<T> GetGenericRepository<T>() where T : class, new();

        Task<ServiceResult> SaveChanges();
    }
}
