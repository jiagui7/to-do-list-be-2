using To_Do_List.DTOs;
using To_Do_List.Entities;

namespace To_Do_List
{
    public static class Extensions
    {
        public static TaskDTO AsDTO(this Task task)
        {
            return new TaskDTO
            {
                Id = task.Id,
                Description = task.Description,
                Completed = task.Completed
            };
        }
    }
}