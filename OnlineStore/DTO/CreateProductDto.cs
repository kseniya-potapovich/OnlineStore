namespace OnlineStore.DTO
{
    public class CreateProductDto: GetProductDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int? Price { get; set; }

        public bool Available { get; set; }

    }
}
