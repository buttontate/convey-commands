using System;
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
            var itemUuid = Guid.NewGuid();
            var sql = @"INSERT 
INTO
    item
    (id, upc, description) 
  VALUES
    (@itemUuid,@itemUpc,@itemDescription)";

            using var connection = _connectionFactory.GetConnection();
            await connection.ExecuteAsync(sql,
                new {itemUuid, itemUpc = item.Upc, @itemDescrioption = item.Description});

            return itemUuid;
        }
    }
    
}