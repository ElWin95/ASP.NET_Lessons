namespace PracticeP416.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string StuName { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
