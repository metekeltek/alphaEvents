using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using alphaEventViewer.Models;
using Dapper;

namespace alphaEventViewer.Repository
{
    public class EventItemRepository
    {
        public async Task<EventItemEntity> GetAsync(Guid id)
        {
            using (var connection = await ConnectionFactory.CreateAsync())
            {
                return await connection.QueryFirstAsync<EventItemEntity>("select * from eventItems where eventItemId = @Id", new
                {
                    Id = id
                });
            }
        }

        public async Task<IEnumerable<EventItemEntity>> GetModulesAsync(Guid id)
        {
            using (var connection = await ConnectionFactory.CreateAsync())
            {
                return await connection.QueryAsync<EventItemEntity>("select * from eventItems where RootId = @Id and [Level] = 3", new
                {
                    Id = id
                });
            }
        }


        public async Task<IEnumerable<EventItemEntity>> GetAllAsync()
        {
            using (var connection = await ConnectionFactory.CreateAsync())
            {
                var now = DateTime.Now.Year.ToString("D2") + DateTime.Now.Month.ToString("D2") + DateTime.Now.Day.ToString("D2");
                return (await connection.QueryAsync<EventItemEntity>($"select eventItemId, Title, City, Beginning from eventItems where Beginning > '{now}' Order by Beginning ASC")).ToList();
            }
        }
    }
}
