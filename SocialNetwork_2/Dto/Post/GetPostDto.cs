using System;

namespace SocialNetwork_2.Dto.Post
{
    public class GetPostDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int ProfileId { get; set; }
    }
}
