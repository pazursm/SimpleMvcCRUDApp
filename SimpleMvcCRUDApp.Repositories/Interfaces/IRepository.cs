﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimpleMvcCRUDApp.Repositories.Interfaces
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T GetById(long id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        //Ovo izbaciti
        void Update(T entity);
    }
}
