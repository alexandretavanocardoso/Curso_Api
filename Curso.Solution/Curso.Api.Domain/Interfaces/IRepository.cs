using Curso.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Curso.Api.Domain.Interfaces
{
    // Sempre uma interface de repositorio vai herdar
    // repositorio génerico que espera uma entidade
    // Nesse caso quer dizer que apenas podemos usar
    // essa interface se a entidade estiver herdando
    // da BaseEntity
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAsync();
    }
}
