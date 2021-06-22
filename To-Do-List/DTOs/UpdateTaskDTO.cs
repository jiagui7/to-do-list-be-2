using System;
using System.ComponentModel.DataAnnotations;

namespace To_Do_List.DTOs
{
    public record UpdateTaskDTO
    {
        [Required()]
        public Boolean Completed { get; init; }
    }
}