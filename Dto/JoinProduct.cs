using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperPrac.Dto
{
    public record JoinProduct
    {
        
        public required int Id { get; init;}
        public required string Name { get; init;}
        public required float Price { get; init;}
        public required string IndustryName { get; init;}
        public required string Cnpj { get; init;}

    }
}