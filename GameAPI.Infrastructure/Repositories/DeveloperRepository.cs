using GameAPI.Domain.Entities;
using GameAPI.Domain.Exceptions;
using GameAPI.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAPI.Infrastructure.Repositories
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly GameDbContext _gameDbContext;

        public DeveloperRepository(GameDbContext gameDbContext)
        {
            _gameDbContext = gameDbContext;
        }

        public List<DeveloperEntity> GetAll()
        {
            var result = _gameDbContext.Developers.ToList();
            return result;
        }

        public async Task<DeveloperEntity> GetById(Guid id)
        {
            var result = await _gameDbContext.Developers.FirstOrDefaultAsync(x=>x.Id==id);
            if (result == null) throw new EntityNotFoundException($"Разработчик с id = {id} не существует");
            return result;
        }
    }
}
