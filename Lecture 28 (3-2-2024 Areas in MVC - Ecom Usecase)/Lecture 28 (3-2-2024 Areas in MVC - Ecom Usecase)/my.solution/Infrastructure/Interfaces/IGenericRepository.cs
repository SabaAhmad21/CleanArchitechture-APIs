using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IGenericRepository
    {
        Task<bool> Create(object Entity);
        Task<bool> Update(object Entity);
    }
}
