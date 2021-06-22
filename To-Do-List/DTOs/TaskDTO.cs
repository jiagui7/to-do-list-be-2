using System;

namespace To_Do_List.DTOs
{
    public record TaskDTO
    {
        public Guid Id { get; init; }

        public string Description { get; init; }

        public Boolean Completed { get; init; }
    }
}