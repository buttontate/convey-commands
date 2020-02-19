using System;
using System.Threading.Tasks;
using convey_cqrs.Models.Item;

namespace convey_cqrs.Data
{
    public interface IItemData
    {
        Task<Guid> CreateItem(ItemPostDto item);
    }
 
}