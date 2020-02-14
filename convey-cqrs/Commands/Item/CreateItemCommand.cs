using System;
using System.Runtime.InteropServices;
using Convey.CQRS.Commands;
using convey_cqrs.Models.Item;

namespace convey_cqrs.Commands.Item
{
    public class CreateItemCommand : ICommand
    {
        public static CreateItemCommand CreateInstance(CreateItem item)
        {
            return new CreateItemCommand()
            {
                Id = Guid.NewGuid(),
                Description = item.Description,
                Upc = item.Upc
            };
        }

        public Guid Id { get; set; }
        public string Upc { get; set; }
        public string Description { get; set; }
    }
}