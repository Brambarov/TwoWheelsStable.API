namespace TwoWheelsStable.API.Helpers.Queries
{
    public class MotorcycleQuery
    {
        public string? Make { get; set; } = null;
        public string? Model { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
