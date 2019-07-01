using System;
using System.Data;
using System.Threading.Tasks;
using alphaEventViewer.Models;
using Dapper;
using Dapper.Contrib.Extensions;

namespace alphaEventViewer.Repository
{
    public class JobContactRepository
    {
        public async Task<int> CreateAsync(JobContactEntity jobContact)
        {
            using (var connection = await ConnectionFactory.CreateAsync())
            {
                return await connection.InsertAsync(jobContact);
            }
        }
    }
}