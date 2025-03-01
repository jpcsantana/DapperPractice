namespace DapperPrac.Dto
{
    public record CreateProduct
    {
        
        public required string ProductName { get; init;}
        public required float Price { get; init;}
        public required int IndustryId { get; init;}

    }
}