using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AkademiPlusMicroserviceProje.Shared.DTOS
{
    public class Response<T>
    {
        public T Data { get; set; }
        [JsonIgnore] 
        public int StatusCode { get; set; }
        [JsonIgnore]
        public bool IsSccessful { get; set; }
        public List<string> Errors { get; set; }
        public static Response<T> Success(int statusCode) 
        { 
            return new Response<T> { StatusCode = statusCode,Data=default(T), IsSccessful=true};
        }
        public static Response<T> Success(int statusCode, T data)
        {
            return new Response<T> { StatusCode = statusCode, Data = data, IsSccessful = true };
        }
        public static Response<T> Fail(string error, int statusCode)
        {
            return new Response<T> { Errors = new List<string> { error }, StatusCode = statusCode, IsSccessful = false };
        }
        public static Response<T> Fail(List<string> errors, int statusCode)
        {
            return new Response<T> { Errors =  errors , StatusCode = statusCode, IsSccessful = false };
        }
    }
}
