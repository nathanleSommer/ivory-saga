using System;
using IvorySaga.Domain.Data;
using IvorySaga.Domain.Repositories;
using IvorySaga.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace IvorySaga.Infrastructure.Repositories
{
    public class SagaRepository : ISagaRepository
    {
        private readonly IvorySagaDataContext _dbContext;

        public SagaRepository(IvorySagaDataContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Saga Add(Saga saga)
        {
            return _dbContext.Sagas.Add(saga).Entity;
        }

        public async Task<Saga?> FindAsync(Guid id)
        {
            var saga = await _dbContext.Sagas
                .Include(s => s.Chapters)
                .Where(s => s.Id == id)
                .SingleOrDefaultAsync();

            return saga;
        }
    }
}
