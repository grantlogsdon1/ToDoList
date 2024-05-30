using Data.Entity;

namespace DTOs
{
    public class ListDTO
    {
        public ListHeader ListHeader { get; set; }

        public List<TaskItem>? Tasks { get; set; }
    }
}
