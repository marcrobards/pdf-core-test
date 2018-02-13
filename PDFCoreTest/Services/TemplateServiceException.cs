using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PDFCoreTest.Services
{
    public class TemplateServiceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="TemplateServiceException"/>
        /// </summary>
        /// <param name="message"></param>
        public TemplateServiceException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TemplateServiceException"/>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public TemplateServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
