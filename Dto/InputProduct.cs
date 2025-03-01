namespace DapperPrac.Dto
{
    public record InputProduct
    {
        
        public required string ProductName { get; init;}
        public required float Price { get; init;}
        public required int IndustryId { get; init;}

    }
}