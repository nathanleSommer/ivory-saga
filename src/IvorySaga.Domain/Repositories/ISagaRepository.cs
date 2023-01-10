using System;
using System.Threading.Tasks;
using IvorySaga.Domain.Common;
using IvorySaga.Domain.Data;

namespace IvorySaga.Domain.Repositories;

public interface ISagaRepository : IRepository<Saga>
{
    Saga Add(Saga saga);

    Task<Saga?> FindAsync(Guid id);
}

