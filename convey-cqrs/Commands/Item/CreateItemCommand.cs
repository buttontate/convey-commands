using System;
using Convey.CQRS.Commands;

namespace convey_cqrs.Commands.Item
{
    public class CreateItemCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Upc { get; set; }
        public string Description { get; set; }
    }
}