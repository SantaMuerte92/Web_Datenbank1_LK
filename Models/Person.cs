namespace Web_Datenbank1_LK.Models
{
    public class Person : IComparable<Person>
    {
        public Guid PID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? BodySize { get; set; }
        public float? BodyWeight { get; set; }
        public string? PersonImage { get; set; }

        public int CompareTo(Person? other)
        {
            return this.LastName.CompareTo(other.LastName);
        }

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

        public bool isBdayin3months
        {
            get
            {
                if (BirthDate == null)
                {
                    return false;
                }
                DateTime today = DateTime.Today;
                DateTime bdayThisYear = new DateTime(today.Year, BirthDate.Value.Month, BirthDate.Value.Day);
                DateTime threeMonthsFromNow = today.AddDays(91);
                if (bdayThisYear >= today && bdayThisYear <= threeMonthsFromNow)
                {
                    return true;
                }
                return false;

            }
        }
    }
}
