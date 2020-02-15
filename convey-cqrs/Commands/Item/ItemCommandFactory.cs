using System;

namespace convey_cqrs.Commands.Item
{
    public interface IItemCommandFactory
    {
        public CreateItemCommand CreateInstance();
    }
    
    public class ItemCommandFactory : IItemCommandFactory
    {
        public CreateItemCommand CreateInstance()
        {
            return new CreateItemCommand
            {
                Id = Guid.NewGuid()
            };
        }
    }
}