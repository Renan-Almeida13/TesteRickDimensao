using Data.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using RickDimensao.Domain.Entities;

namespace Data.Repository.Base
{
    public abstract class SpecificRepositoryBase<T> where T : BaseEntitie
    {
        internal abstract IEnumerable<T> ConfigurarBuscaObjetoCompleto(Expression<Func<T, bool>> linqExpression, IMySQLContext dbContext);
    }
}
