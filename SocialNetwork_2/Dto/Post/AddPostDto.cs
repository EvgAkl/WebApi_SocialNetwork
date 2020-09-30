namespace SocialNetwork_2.Dto.Post
{
    public class AddPostDto
    {
        public string Text { get; set; }
        public int ProfileId { get; set; }

        public bool Validate()
        {
            var isValid = !string.IsNullOrEmpty(Text) && (ProfileId != 0);
            return isValid;
        }
    }
}
