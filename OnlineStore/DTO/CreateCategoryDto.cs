namespace OnlineStore.DTO
{
    public class CreateCategoryDto: GetCategoryDto
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
