using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bukimedia.PrestaSharp
{
    class PrestaSharpNotAuthorized : PrestaSharpException
    {
        public PrestaSharpNotAuthorized()
            : base()
        {
        }

        public PrestaSharpNotAuthorized(string Message)
            : base(Message)
        {
        }

        public PrestaSharpNotAuthorized(string ResponseContent, string ResponseErrorMessage, Exception ResponseErrorException)
            : base(ResponseContent, ResponseErrorMessage, ResponseErrorException)
        {
            this.ResponseContent = ResponseContent;
            this.ResponseErrorMessage = ResponseErrorMessage;
        }

        public PrestaSharpNotAuthorized(string ResponseContent, string ResponseErrorMessage, HttpStatusCode ResponseHttpStatusCode, Exception ResponseErrorException)
            : base(ResponseContent, ResponseErrorMessage, ResponseHttpStatusCode, ResponseErrorException)
        {
            this.ResponseContent = ResponseContent;
            this.ResponseErrorMessage = ResponseErrorMessage;
            this.ResponseHttpStatusCode = ResponseHttpStatusCode;
        }
    }
}
