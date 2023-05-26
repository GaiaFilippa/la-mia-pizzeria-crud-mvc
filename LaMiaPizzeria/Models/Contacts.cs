namespace LaMiaPizzeria.Models
{
    public class Contacts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Feedback { get; set; }

        public Contacts()
        {
           
        }

        public Contacts(string name, string surname, string email, string feedback)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Feedback = feedback;
        }
    }
}
