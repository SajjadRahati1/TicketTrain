﻿namespace EndPoint.Site.Models.Dto.Home
{
    public class SearchTravelDFDto
    {
        public short TravelType { get; set; }
        public long FromCity { get; set; }
        public long ToCity { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}