﻿namespace Yummy.UI.DTOs.EventDTOs
{
    public class ResultEventDTO
    {
        public int YummyEventID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public bool IsVisible { get; set; }
        public bool IsActive { get; set; }
    }
}
