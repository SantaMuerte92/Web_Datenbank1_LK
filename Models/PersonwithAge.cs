namespace Web_Datenbank1_LK.Models
{
    public class PersonwithAge
    {
        public Guid PID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? BodySize { get; set; }
        public float? BodyWeight { get; set; }
        public string? PersonImage { get; set; }
        public int? Age
        {
            get
            {
                if (BirthDate == null)
                {
                    return 0;
                }

                DateTime today = DateTime.Today;
                int age = today.Year - BirthDate.Value.Year;

                if (BirthDate.Value.Date > today.AddYears(-age))
                {
                    age--;
                }

                return age;
            }
        }
    }
}
