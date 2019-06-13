namespace ApplicationServices.DTOs
{
    public class CarDto
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public int ReleaseYear { get; set; }

        public int HorsePower { get; set; }

        public MakeDto Make { get; set; }

        public TypeDto Type { get; set; }
    }
}
