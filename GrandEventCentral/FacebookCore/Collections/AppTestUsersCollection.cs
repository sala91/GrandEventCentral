using System.Threading.Tasks;
using FacebookCore.Entities;
using Newtonsoft.Json.Linq;

namespace FacebookCore.Collections
{
    public class AppTestUsersCollection : FacebookCollection<TestUser>
    {
        public new FacebookCursor Cursor { get; internal set; }

        public AppTestUsersCollection(FacebookClient client, string query, string token, FacebookCursor cursor = null) : base(client, query, token, TestUserMapper, cursor)
        {

        }

        public new async Task<AppTestUsersCollection> BeforeAsync()
        {
            var collection = await base.BeforeAsync();
            return (AppTestUsersCollection)collection;
        }

        public new async Task<AppTestUsersCollection> AfterAsync()
        {
            var collection = await base.AfterAsync();
            return (AppTestUsersCollection)collection;
        }

        private static TestUser TestUserMapper(JToken data)
        {
            var user = new TestUser()
            {
                Id = data["id"].ToString(),
                LoginUrl = data["login_url"].ToString(),
                AccessToken = data["access_token"].ToString()
            };

            return user;
        }
    }
}
