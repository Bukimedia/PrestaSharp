using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bukimedia.PrestaSharp
{
    /// <summary>
    /// Exception for entities not found in database
    /// </summary>
    class PrestaSharpNotFoundException : PrestaSharpException
    {
        public PrestaSharpNotFoundException()
            : base()
        {
        }

        public PrestaSharpNotFoundException(string Message)
            : base(Message)
        {
        }

        public PrestaSharpNotFoundException(string ResponseContent, string ResponseErrorMessage, Exception ResponseErrorException)
            : base(ResponseContent, ResponseErrorMessage ,ResponseErrorException)
        {
            this.ResponseContent = ResponseContent;
            this.ResponseErrorMessage = ResponseErrorMessage;
        }

        public PrestaSharpNotFoundException(string ResponseContent, string ResponseErrorMessage, HttpStatusCode ResponseHttpStatusCode, Exception ResponseErrorException)
            : base(ResponseContent, ResponseErrorMessage, ResponseHttpStatusCode, ResponseErrorException)
        {
            this.ResponseContent = ResponseContent;
            this.ResponseErrorMessage = ResponseErrorMessage;
            this.ResponseHttpStatusCode = ResponseHttpStatusCode;
        }

    }
}
