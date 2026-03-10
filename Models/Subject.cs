   namespace Eduworknet.Models{
   public class Subject
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public ICollection<TagCourse> TagCourses { get; set; } = new List<TagCourse>();
        public ICollection<CategoryCourse> CategoryCourses { get; set; } = new List<CategoryCourse>();

    }}