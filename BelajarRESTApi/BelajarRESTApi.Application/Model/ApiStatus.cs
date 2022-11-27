﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BelajarRESTApi.Application.Model
{
    public class ApiStatus
    {
        public int StatusCode { get; private set; }

        public string StatusDescription { get; private set; }


        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Message { get; private set; }

        public ApiStatus(int statusCode)
        {
            HttpStatusCode parsedCode = (HttpStatusCode)statusCode;
            this.StatusCode = statusCode;
            this.StatusDescription = parsedCode.ToString();
        }

        public ApiStatus(int statusCode, string statusDescription)
        {
            this.StatusCode = statusCode;
            this.StatusDescription = statusDescription;           
        }

        public ApiStatus(int statusCode, string statusDescription, string message) 
            : this(statusCode, statusDescription)
        {
            Message = message;
        }
    }
}
