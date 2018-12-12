using System;
using System.Collections.Generic;
using System.Text;

namespace server.ResponseTypes
{
    public class ApiErrorResponse : ApiResponse
    {
        public ApiErrorResponse(string message) : base(500, message) { }
    }
}
