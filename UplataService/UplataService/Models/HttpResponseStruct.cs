namespace UplataService.Models
{
    /// <summary>
    /// Struct which will be used in HttpMiddleware in order to
    /// format specific details as per LoggerService requirements.
    /// </summary>
    struct HttpResponseStruct
    {
        public static readonly string HTTP_5XX = " INTERNAL SERVER ERROR";
        public static readonly string HTTP_404 = " NOT FOUND";
        public static readonly string HTTP_403 = " FORBIDDEN";
        public static readonly string HTTP_401 = " UNAUTHORIZED";
        public static readonly string HTTP_400 = " BAD REQUEST";
        public static readonly string HTTP_200 = " OK";
    }
}