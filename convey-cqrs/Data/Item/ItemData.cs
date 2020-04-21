using System;
using System.Linq;
using System.Threading.Tasks;
using convey_cqrs.Factories;
using convey_cqrs.Models.Item;
using Dapper;

namespace convey_cqrs.Data.Item
{
    public interface IItemData
    {
        Task<Guid> CreateItem(ItemPostDto item);
    }

    public class ItemData : IItemData
    {
        private readonly IConnectionFactory _connectionFactory;

        public ItemData(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<Guid> CreateItem(ItemPostDto item)
        {
            using var connection = _connectionFactory.GetConnection();
            return (await connection.QueryAsync<Guid>("")).Single();
        }
    }
    
}