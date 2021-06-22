using System;

namespace To_Do_List.Entities
{
    public record Task
    {

        public Guid Id { get; init; }

        public string Description { get; init; }

        public Boolean Completed { get; init; }

    }


}