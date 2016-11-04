using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace FCD.EntityFramework.Repositories
{
    public abstract class FCDRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<FCDDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected FCDRepositoryBase(IDbContextProvider<FCDDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class FCDRepositoryBase<TEntity> : FCDRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected FCDRepositoryBase(IDbContextProvider<FCDDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
