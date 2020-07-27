using Domain.Repositories;
using Infrastructure.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbStorage _storage;

        public UnitOfWork(DbStorage storage)
        {
            _storage = storage;
        }

        public async Task<bool> Save()
        {
            return (await _storage.SaveChangesAsync() > 0);
        }
    }
}
