using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperPrac.Exception
{
    public class NotFoundException : System.Exception
    {
        public NotFoundException() : base("Resource not found.") {}
        public NotFoundException(string message) : base(message) {}
    }
}