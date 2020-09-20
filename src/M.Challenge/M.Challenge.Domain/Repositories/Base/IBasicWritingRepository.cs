﻿using System.Threading.Tasks;

namespace M.Challenge.Domain.Repositories.Base
{
    public interface IBasicWritingRepository<T> where T : class
    {
        Task<T> Add(T entity);
    }
}
