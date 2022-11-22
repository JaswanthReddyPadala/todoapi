using todoapi.Models.Enums;

namespace todoapi.Models
{
    public class Todo
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public StatusType Status { get; set; }
    }
}
