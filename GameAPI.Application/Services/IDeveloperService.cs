using GameAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.Application.Services
{
    public interface IDeveloperService
    {
        public List<DeveloperEntity> GetAll();
    }
}
