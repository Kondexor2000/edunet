using Eduworknet.Models;

namespace Eduworknet.DTOs{
public class SubjectDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Subject> Subjects { get; set; } = new();

        public static implicit operator SubjectDto(Subject subject)
{
    return new SubjectDto
    {
        Title = subject.Title,
        Description = subject.Description
        // Map other properties as needed
    };
}

        internal class Item
        {
            public string Title { get; internal set; }
            public string Description { get; internal set; }
        }
    }
}