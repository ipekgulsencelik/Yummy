﻿namespace Yummy.Entity.Entities
{
    public class Service
    {
        public int ServiceID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public bool IsVisible { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }
}