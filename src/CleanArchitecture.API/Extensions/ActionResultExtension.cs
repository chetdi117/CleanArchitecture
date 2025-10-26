using CleanArchitecture.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Optional;
namespace CleanArchitecture.API.Extensions;

public static class ActionResultExtension
{
    public static IActionResult ToActionResult<T>(this Option<T> data, bool success, int errorCode = 200, string message = "")
    {
        return data.Match<IActionResult>(
            resp => new ObjectResult(new BaseApiResponse<T>(resp, success, errorCode, message)),
            () => new ObjectResult(new BaseApiResponse(success, errorCode, message))
        );
    }

    public static IActionResult ToActionResult(this bool success, int errorCode = 200, string message = "")
    {
        return new ObjectResult(new BaseApiResponse(success, errorCode, message));
    }
}
