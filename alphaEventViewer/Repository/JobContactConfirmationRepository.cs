using System;
using System.Data;
using System.Threading.Tasks;
using alphaEventViewer.Models;
using Dapper;
using Dapper.Contrib.Extensions;

namespace alphaEventViewer.Repository
{
    public class JobContactConfirmationRepository
    {
        public async Task<int> CreateAsync(JobContactConfirmationEntity jobContact)
        {
            using (var connection = await ConnectionFactory.CreateAsync())
            {
                return await connection.InsertAsync(jobContact);
            }
        }

        public async Task<JobContactConfirmationEntity> GetAsync(Guid participationId)
        {
            using (var connection = await ConnectionFactory.CreateAsync())
            {
                return connection.QueryFirst<JobContactConfirmationEntity>($"select * from JobContactConfirmations where JobContactId = '{participationId}'");
            }
        }

        public async Task UpdateAsync(Guid participationId)
        {
            using (var connection = await ConnectionFactory.CreateAsync())
            {
                await connection.QueryAsync($"UPDATE JobContactConfirmations SET confirmed = 1 WHERE JobContactId = '{participationId}';");
            }
        }
    }
}