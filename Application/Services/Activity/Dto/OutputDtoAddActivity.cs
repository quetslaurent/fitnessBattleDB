namespace Application.Services.Activity.Dto
{
    public class OutputDtoAddActivity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Repetitions { get; set; }

        public class Category
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class Unit
        {
            public int Id { get; set; }
            public string Type { get; set; }
        }
    }
}