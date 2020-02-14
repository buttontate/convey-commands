using System;
using Convey.CQRS.Commands;

namespace convey_microservice.Commands.Item
{
    public class CreateItemCommand : ICommand
    {
        public CreateItemCommand(Guid id, string upc, string description)
        {
            Id = id;
            Upc = upc;
            Description = description;
        }

        public Guid Id { get; set; }
        public string Upc { get; set; }
        public string Description { get; set; }
        
        
    }
}