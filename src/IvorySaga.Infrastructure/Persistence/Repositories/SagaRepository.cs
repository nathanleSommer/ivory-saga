using System;
using System.Runtime.CompilerServices;
using IvorySaga.Application.Common.Persistence.Interfaces;
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

        public async Task<Saga> AddAsync(Saga saga, CancellationToken cancellationToken = default)
        {
            var entity = await _dbContext.Sagas.AddAsync(saga, cancellationToken);
            
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Entity;
        }

        public async Task<Saga?> FindAsync(SagaId id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Sagas.FindAsync(keyValues: new object[] { id }, cancellationToken: cancellationToken);
        }
    }
}
