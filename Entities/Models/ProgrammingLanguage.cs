namespace Entities.Models
{
    public class ProgrammingLanguage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Project>? Projects { get; set; }
    }
}
