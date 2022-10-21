using GameAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.Domain.Repositories
{
    public interface IDeveloperRepository
    {
        public Task<DeveloperEntity> GetById(Guid id);
        public List<DeveloperEntity> GetAll();
    }
}
