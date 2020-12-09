using System;

namespace Domain.Category
{
    public class Category : ICategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category()
        {
            
        }

        public Category(string name)
        {
            Name = name;
        }

        protected bool Equals(Category other)
        {
            return Id == other.Id && Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Category) obj);
        }
        
    }
}