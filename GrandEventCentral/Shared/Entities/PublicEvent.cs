using System;
using System.ComponentModel.DataAnnotations;

namespace GrandEventCentral.Shared.Entities
{
    public class PublicEvent : Base
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string HostName { get; set; }
        public string EventUrlFb { get; set; }
        public string EventUrlShort { get; set; }
        /// <summary>
        /// When is the event taking place
        /// </summary>
        [Required]
        public DateTime Date { get; set; }
        /// <summary>
        /// For filtering purposes
        /// </summary>
        [Required]
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// E.g. Estonia
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// E.g. Tallinn
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// E.g. Harjumaa
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// E.g. 10131
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// E.g. Planeedi
        /// </summary>
        public string StreetAdress { get; set; }
        /// <summary>
        /// E.g. 9A
        /// </summary>
        public string House { get; set; }
        /// <summary>
        /// E.g. 1
        /// </summary>
        public int ApartmentNo { get; set; }
        /// <summary>
        /// TODO: Make it autocomplete based on other fields
        /// </summary>
        [Required]
        public string FullAddress { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
