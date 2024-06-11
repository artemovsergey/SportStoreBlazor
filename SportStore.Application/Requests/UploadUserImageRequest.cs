using MediatR;
using Microsoft.AspNetCore.Components.Forms;

namespace SportStore.Application.Requests;

public record UploadUserImageRequest(int UserId, IBrowserFile File) : IRequest<UploadUserImageRequest.Response>
{
    public const string RouteTemplate = "/api/trails/{trailId}/images";
    public record Response(string ImageName);
}
