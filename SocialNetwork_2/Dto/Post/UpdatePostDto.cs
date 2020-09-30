namespace SocialNetwork_2.Dto.Post
{
    public class UpdatePostDto
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public bool Validate()
        {
            var isValid = !string.IsNullOrEmpty(Text) && (Id != 0);
            return isValid;
        }
    }
}
