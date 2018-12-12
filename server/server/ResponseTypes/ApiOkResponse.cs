namespace server.ResponseTypes
{
    public class ApiOkResponse : ApiResponse
    {
        public object Result { get; }

        public ApiOkResponse(object result) : base(200)
        {
            Result = result;
        }

        public ApiOkResponse() : base(200) { }
    }
}
