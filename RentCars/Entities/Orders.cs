﻿namespace RentCars.Entities
{
    public class Orders
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int CarId { get; set; }
    }
}
