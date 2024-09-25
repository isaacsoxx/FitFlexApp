using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FitFlexApp.BLL.Exceptions
{
    public class CustomException
    {
        private readonly RequestDelegate _delegate;
        private readonly ILogger _logger;

        public CustomException(RequestDelegate requestDelegate, ILogger<CustomException> logger)
        {
            _delegate = requestDelegate;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _delegate(context);
            }
            catch (ReflectionTypeLoadException e)
            {
                foreach (Exception ex in e.LoaderExceptions)
                {
                    _logger.LogCritical(ex.Message + Environment.NewLine + ex.StackTrace);
                }
            }
        }

    }
}
