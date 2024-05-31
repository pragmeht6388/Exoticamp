using Exoticamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Contracts.Persistence
{
    public interface IActivitiesRepository : IAsyncRepository<Activities>
    {
        Task<List<Activities>> GetAll(bool includePassedEvents);
        Task<Activities> Add(Activities Activities);
        Task<Activities> Update(Activities Activities);
        Task<Activities> Delete(Activities Activities);
    }
}
