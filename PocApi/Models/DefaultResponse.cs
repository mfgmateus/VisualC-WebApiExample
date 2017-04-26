using System;

namespace PocApi.Models
{
    public class DefaultResponse
    {

        public DefaultResponse()
        {
            this.Success = false;
            this.Value = null;
        }
        public DefaultResponse(bool success, Object value)
        {
            this.Success = success;
            this.Value = value;
        }

        public bool Success { get; set; }
        public Object Value { get; set; }
    }
}
