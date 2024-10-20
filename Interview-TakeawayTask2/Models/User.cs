namespace InterviewTakeawayTask2.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string? Username {get; set;}
        public required string Password {get; set;}
        public required string Name { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }
    }
}
