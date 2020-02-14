using System;

namespace convey_microservice.Models.Item
{
    public class CreateItem
    {
        public Guid Id { get; set; }
        public string Upc { get; set; }
        public string Description { get; set; }
    }
}