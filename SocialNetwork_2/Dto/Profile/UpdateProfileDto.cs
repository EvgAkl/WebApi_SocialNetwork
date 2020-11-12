namespace SocialNetwork_2.Dto.Profile
{
    public class UpdateProfileDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }

        public bool Validate()
        {
            var isValid = (Id != 0) && (Age != 0) && !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName);
            return isValid;
        }
    }
}
