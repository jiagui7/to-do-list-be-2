using System.ComponentModel.DataAnnotations;

namespace To_Do_List.DTOs
{
    public record CreateTaskDTO
    {
        [Required(AllowEmptyStrings = false)]
        public string Description { get; init; }
    }
}