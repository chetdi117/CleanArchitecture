using CleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Factory
{
    public class ApplicationFactory
    {
        public static JsonSerializerOptions CreateDefaultJsonSerializerOptions()
        {
            return new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public static BaseApiResponse CreateSuccessResponse(string? message = null)
        {
            return new BaseApiResponse
            {
                Success = true,
                Message = message
            };
        }

        public static BaseApiResponse<T> CreateSuccessResponse<T>(T? data, string? message = null)
        {
            return new BaseApiResponse<T>
            {
                Success = true,
                Data = data,
                Message = message
            };
        }

        public static BaseApiResponse CreateFailureResponse(string? message = null, int? errorCode = null)
        {
            return new BaseApiResponse
            {
                Success = false,
                Message = message,
                ErrorCode = errorCode
            };
        }
    }
}
