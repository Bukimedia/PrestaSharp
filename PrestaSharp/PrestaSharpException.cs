using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bukimedia.PrestaSharp
{
    public class PrestaSharpException : ApplicationException
    {
        public HttpStatusCode ResponseHttpStatusCode { get; set; }
        public string ResponseContent { get; set; }
        public string ResponseErrorMessage { get; set; }

        public PrestaSharpException()
            : base()
        {
        }

        public PrestaSharpException(string ResponseContent, string ResponseErrorMessage, Exception ResponseErrorException)
            : base(ResponseContent + " " + ResponseErrorMessage, ResponseErrorException)
        {
            this.ResponseContent = ResponseContent;
            this.ResponseErrorMessage = ResponseErrorMessage;
        }

        public PrestaSharpException(string ResponseContent, string ResponseErrorMessage, HttpStatusCode ResponseHttpStatusCode, Exception ResponseErrorException)
            : base(ResponseContent + " " + ResponseErrorMessage + " HttpStatusCode: " + ResponseHttpStatusCode, ResponseErrorException)
        {
            this.ResponseContent = ResponseContent;
            this.ResponseErrorMessage = ResponseErrorMessage;
            this.ResponseHttpStatusCode = ResponseHttpStatusCode;
        }

    }
}
