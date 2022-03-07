using System.Collections.Generic;

namespace AlatechMachines.webAPI.Response
{
    public class ResponseData
    {
        public string Message { get; set; }
        public object Data { get; set; }
        public List<Error> Errors { get; set; }
    }

    public class Error
    { 
        public string name { get; set; }
        public string Description { get; set; }
    }
}
