using System;
using IvorySaga.Application.Common.Persistence.Interfaces.Persistence;
using IvorySaga.Domain.Saga;
using IvorySaga.Domain.Saga.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace IvorySaga.Infrastructure.Persistence.Repositories
{
    public class SagaRepository : ISagaRepository
    {
        private readonly IvorySagaDbContext _dbContext;

        public SagaRepository(IvorySagaDbContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Saga Add(Saga saga)
        {
            var entity = _dbContext.Sagas.Add(saga).Entity;
            _dbContext.SaveChanges();

            return entity;
        }

        public async Task<Saga?> FindAsync(SagaId id)
        {
            return await _dbContext.Sagas.FindAsync(id);
        }
    }
}
