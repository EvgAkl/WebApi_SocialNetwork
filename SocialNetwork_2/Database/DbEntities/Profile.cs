using System.Collections.Generic;

namespace SocialNetwork_2.Database.DbEntities
{
    public sealed class Profile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }

        public List<Post> Posts { get; set; }
    }
}
