﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Hassie.API.NewsAPI.Exceptions
{
    public class NewsHTTPException : Exception
    {
        public NewsHTTPException(string message, HttpRequestException inner) : base(message, inner) { }
    }
}