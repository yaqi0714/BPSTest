using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidding.IBLL
{
    public interface IBaseService<T> where T : class
    {
        T Add(T entity);

        bool Update(T entity);

        bool Delete(T entity);
    }
}
