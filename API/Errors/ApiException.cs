using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiException(int statusCode, string message = null, string details = null) : ApiResponse(statusCode, message)
    {
        public string Details { get; set; } = details;
    }
}