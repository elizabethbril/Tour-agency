using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Exceptions
{
    public class InvalidLoginPasswordCombinationException : Exception
    {
        public InvalidLoginPasswordCombinationException(string Message) : base(Message) { }
    }
}