namespace ArticlesApp.DAL
{
    public struct RequestResult<T> where T:class
    {
        public readonly string Message;
        public readonly RequestStatus Status;
        public readonly T Data;
        public bool IsValid => Status == RequestStatus.Ok && Data != null;

        public RequestResult(T data, RequestStatus status, string message=null)
        {
            Data = data;
            Status = status;
            Message = message;
        }

        public override string ToString()
        {
            return $@"Result: {Status}, data: {Data}, message: {Message}.";
        }
    }

    public struct RequestResult
    {
        public readonly string Message;
        public readonly RequestStatus Status;
        public bool IsValid => Status == RequestStatus.Ok;

        public RequestResult(RequestStatus status, string message = null)
        {
            Status = status;
            Message = message;
        }

        public override string ToString()
        {
            return $@"Result: {Status}, message: {Message}.";
        }
    }

    public enum RequestStatus
    {
        Unknown = 0,
        Ok=200,
        NotModified=304,
        BadRequest=400,
        Unauthorized=401,
        Forbidden=403,
        NotFound=404,
        InternalServerError=500,
        ServiceUnavaliable=503
    }
}
