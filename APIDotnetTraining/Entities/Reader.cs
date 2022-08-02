namespace APIDotnetTraining.Entities
{

    public class Reader
    {
        public int ID { get; set; }

        public string Name { get; set; }
        
        public int Age { get; set; }
        
        public int BookId { get; set; }
        
        public List<Book> Books { get; set; }

    }

}
