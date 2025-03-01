using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperPrac.Exception
{
    public class BadRequestException : System.Exception
    {
        public BadRequestException(string message) : base(message) {}
    }
}