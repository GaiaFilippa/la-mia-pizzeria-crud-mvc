namespace LaMiaPizzeria.Models
{
    public class UserProfile
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int City { get; set; }

        public UserProfile(string name, string surname, int city)
        {
            Name = name;
            Surname = surname;
            City = city;
        }
    }
}
