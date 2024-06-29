using DevIO.Business.Core.Data;
using DevIO.Business.Core.Models;
using DevIO.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly MeuDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(MeuDbContext db)
        {
            Db = db;
            DbSet = Db.Set<TEntity>();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }
        
        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveSanches();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            await SaveSanches();
        }

        public virtual async Task Remover(Guid id)
        {
            //Forma tradicional: Dessa Forma vai na base de dados, resgata o objeto e remove.
            //DbSet.Remove(await DbSet.FindAsync(id));
            
            //Forma sofisticada para economizar ida no banco: Pelo fato da entidade possuir um id, você consegue recuperar.
            Db.Entry(new TEntity { Id = id }).State = EntityState.Deleted;
            
            await SaveSanches();
        }

        public virtual async Task<int> SaveSanches()
        {
            return await Db.SaveChangesAsync();
        }

        public  void Dispose()
        {
            Db?.Dispose();
        }
    }
}
