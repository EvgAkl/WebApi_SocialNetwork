namespace SocialNetwork_2.Dto.Profile
{
    public class AddProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }

        public bool Validate()
        {
            var isValid = !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && !string.IsNullOrEmpty(City) &&
                          (Age != 0);
            return isValid;
        }
    }
}
