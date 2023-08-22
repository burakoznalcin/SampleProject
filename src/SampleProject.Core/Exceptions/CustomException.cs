using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Core.Exceptions
{
    public class CustomException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public List<string> ErrrorList { get; set; }

        public CustomException() : base()
        {

        }

        public CustomException(string message) : base(message) { }

        public CustomException(string message, HttpStatusCode httpStatusCode) : base(message)
        {
            this.HttpStatusCode = httpStatusCode;
        }

    }
}
