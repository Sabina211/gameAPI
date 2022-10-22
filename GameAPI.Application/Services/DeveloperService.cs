using GameAPI.Domain.Entities;
using GameAPI.Domain.Repositories;

namespace GameAPI.Application.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IDeveloperRepository _developerRepository;

        public DeveloperService(IDeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public List<DeveloperEntity> GetAll()
        {
            return _developerRepository.GetAll();
        }
    }
}
