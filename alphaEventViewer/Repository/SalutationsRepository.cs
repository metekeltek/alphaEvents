using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using alphaEventViewer.Models;
using Dapper;

namespace alphaEventViewer.Repository
{
    public class SalutationsRepository
    {
        public async Task<IEnumerable<SalutationEntity>> GetAllAsync()
        {
            using (var connection = await ConnectionFactory.CreateAsync())
            {
                return await connection.QueryAsync<SalutationEntity>("select salutation from salutations");
            }
        }
    }
}
