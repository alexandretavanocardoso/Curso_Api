using Curso.Api.Data.Data.Context;
using Curso.Api.Domain.Entities;
using Curso.Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Api.Data.Data
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MyContext _context;
        private DbSet<T> _dbSet;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>(); // Importante, pos traz meus DbSet do context
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                if(item.Id == Guid.Empty) 
                    item.Id = Guid.NewGuid();

                item.CreateAt = DateTime.UtcNow;

                _dbSet.Add(item);

                await _context.SaveChangesAsync();

            } 
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                // Recuperar o item pelo Id
                var registro = await _dbSet.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

                if (registro == null)
                    return null;

                item.UpdateAt = DateTime.UtcNow;
                item.CreateAt = registro.CreateAt;

                // Faz a entrada, pega os valores e seta os novos valores
                _context.Entry(registro).CurrentValues.SetValues(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
               var item = await _dbSet.SingleOrDefaultAsync(p => p.Id.Equals(id));

                if (item == null)
                    return false;

                _dbSet.Remove(item);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dbSet.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<bool> ExistAsync(Guid id)
        {
            return await _dbSet.AnyAsync(p => p.Id.Equals(id));
        }
    }
}
