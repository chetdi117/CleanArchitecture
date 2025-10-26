using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Models;
public class BaseApiResponse
{
    public BaseApiResponse()
    {
        Success = true;
    }

    public BaseApiResponse(bool success, int errorCode, string message)
    {
        Success = success;
        ErrorCode = errorCode;
        Message = message;
    }

    public string? Message { get; set; }
    public bool Success { get; set; }
    public int? ErrorCode { get; set; }
}
public class BaseApiResponse<T> : BaseApiResponse
{
    public BaseApiResponse()
    {
    }

    public BaseApiResponse(T data, string message)
    {
        Data = data;
        Message = message;
        Success = true;
    }

    public BaseApiResponse(T data, bool success)
    {
        Data = data;
        Success = success;
    }

    public BaseApiResponse(T data, string message, int errorCode)
    {
        Data = data;
        Message = message;
        ErrorCode = errorCode;
        Success = false;
    }

    public BaseApiResponse(T data, bool success, int errorCode, string message)
    {
        Data = data;
        Message = message;
        ErrorCode = errorCode;
        Success = success;
    }

    public T? Data { get; set; }
}
