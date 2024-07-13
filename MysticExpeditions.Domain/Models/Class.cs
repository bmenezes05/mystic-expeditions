using MysticExpeditions.Domain.Models;

namespace MysticExpeditions.Domain.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentClassId { get; set; }
        public Class ParentClass { get; set; }
        public List<Class> SubClasses { get; set; }
    }
}
