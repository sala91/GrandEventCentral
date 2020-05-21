using System;
using System.ComponentModel.DataAnnotations;

namespace GrandEventCentral.Shared.Entities
{
    public class PublicEvent : Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string HostName { get; set; }
        public string EventUrlFb { get; set; }
        public DateTime Date { get; set; }
        public string FullAddress { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
