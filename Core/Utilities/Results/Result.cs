using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        

        public Result(bool success, string message ):this(success)
        {
            Message = message;
            

        }
        public Result(bool success)//Istemezsek mesaj girmemiz için.
        {
            Success = success;

        }

        public bool Success { get; }
        
        public string Message { get; }
    }
}
