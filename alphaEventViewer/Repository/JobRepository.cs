using System;
using System.Data;
using System.Threading.Tasks;
using alphaEventViewer.Models;
using Dapper.Contrib.Extensions;

namespace alphaEventViewer.Repository
{
    public class JobRepository
    {
        public async Task<int> CreateAsync(JobEntity job)
        {
            using (var connection = await ConnectionFactory.CreateAsync())
            {
                return await connection.InsertAsync(job);
            }
        }
    }
}