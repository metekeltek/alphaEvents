using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alphaEventViewer.Models;
using alphaEventViewer.Repository;

namespace alphaEventViewer.Services
{
    public class SalutationsService
    {
        private readonly SalutationsRepository _salutationsRepository;

        public SalutationsService(SalutationsRepository salutationsRepository)
        {
            _salutationsRepository = salutationsRepository;
        }

        public async Task<IEnumerable<SalutationEntity>> GetAllAsync()
        {
            return await _salutationsRepository.GetAllAsync();
        }
    }
}
