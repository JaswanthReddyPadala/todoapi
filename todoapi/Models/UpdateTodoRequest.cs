using todoapi.Models.Enums;

namespace todoapi.Models;

public class UpdateTodoRequest
{
    public string Description { get; set; }

    public StatusType Status { get; set; }
}