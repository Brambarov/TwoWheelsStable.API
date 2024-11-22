namespace api.DTOs.Job
{
    public class JobGetDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int Mileage { get; set; }
        public int DueMileage { get; set; }
    }
}
