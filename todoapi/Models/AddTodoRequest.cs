using todoapi.Models.Enums;

namespace todoapi.Models
{
    public class AddTodoRequest
    {
        public string Description { get; set; }

        public StatusType Status { get; set; }
    }
}
