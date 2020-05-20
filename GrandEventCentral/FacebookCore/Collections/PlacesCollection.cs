using System;
using System.Threading.Tasks;
using FacebookCore.Entities;
using Newtonsoft.Json.Linq;

namespace FacebookCore.Collections
{
    public class PlacesCollection : FacebookCollection<Place>
    {
        public PlacesCollection(FacebookClient client, string query, string token, FacebookCursor cursor = null) : base(client, query, token, PlaceMapper, cursor)
        {

        }

        public new async Task<PlacesCollection> BeforeAsync()
        {
            var collection = await base.BeforeAsync();
            return (PlacesCollection)collection;
        }

        public new async Task<PlacesCollection> AfterAsync()
        {
            var collection = await base.AfterAsync();
            return (PlacesCollection)collection;
        }

        private static Place PlaceMapper(JToken data)
        {
            var place = new Place
            {
                Id = data["id"]?.ToString(),
                Name = data["name"]?.ToString()
            };

            if (data["checkins"] != null)
            {
                place.Checkins = Convert.ToInt32(data["checkins"]);
            }

            if (data["picture"] != null)
            {
                place.Picture = new Picture()
                {
                    Url = data["picture"]["data"]["url"].ToString(),
                    Width = Convert.ToInt32(data["picture"]["data"]["width"]),
                    Height = Convert.ToInt32(data["picture"]["data"]["height"])
                };
            }

            return place;
        }
    }
}
