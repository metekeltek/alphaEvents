using System;
using System.Data;
using System.Threading.Tasks;
using alphaEventViewer.Models;
using Dapper.Contrib.Extensions;

namespace alphaEventViewer.Repository
{
    public class JobEventRegistrationRepository
    {
        public async Task<int> CreateAsync(JobEventRegistrationEntity jobEventRegistration)
        {
            using (var connection = await ConnectionFactory.CreateAsync())
            {
                return await connection.InsertAsync(jobEventRegistration);
            }
        }
    }
}