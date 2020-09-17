using System;

namespace SocialNetwork_2.Database.DbEntities
{
    public sealed class Post
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
    }
}
