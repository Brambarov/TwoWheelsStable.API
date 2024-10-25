namespace api.Helpers.Queries
{
    public class MotorcycleQuery
    {
        public string? Make { get; set; } = null;
        public string? Model { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
    }
}
