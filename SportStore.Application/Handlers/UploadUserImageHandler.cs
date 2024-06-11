using MediatR;
using SportStore.Application.Requests;

namespace SportStore.Application.Handlers;

public class UploadUserImageHandler : IRequestHandler<UploadUserImageRequest, UploadUserImageRequest.Response>
{
    private readonly HttpClient _httpClient;
    public UploadUserImageHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<UploadUserImageRequest.Response> Handle(UploadUserImageRequest request, CancellationToken cancellationToken)
    {
        var fileContent = request.File.OpenReadStream(request.File.Size, cancellationToken);

        using var content = new MultipartFormDataContent();
        content.Add(new StreamContent(fileContent), "image", request.File.Name);
        var response = await _httpClient.PostAsync(UploadUserImageRequest.RouteTemplate.Replace("{trailId}", request.UserId.ToString()), content, cancellationToken);
        if (response.IsSuccessStatusCode)
        {
            var fileName = await response.Content.ReadAsStringAsync(cancellationToken: cancellationToken);
            return new UploadUserImageRequest.Response(fileName);
        }
        else
        {
            return new UploadUserImageRequest.Response("");
        }
    }
}
