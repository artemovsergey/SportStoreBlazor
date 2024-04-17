using SportStore.Domen.Models;
using FluentValidation;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class LoginValidator : AbstractValidator<User>
{
	private readonly HttpClient _httpClient;

	public LoginValidator(HttpClient httpClient)
	{
		_httpClient = httpClient;

		RuleFor(m => m.Login)
			.MustAsync(async (name, cancellation) => await IsNameValidAsync(name))
			.WithMessage("��� ��� ������������.");
	}

	private async Task<bool> IsNameValidAsync(string name)
	{
		var response = await _httpClient.PostAsJsonAsync("https://localhost:7214/api/Users/checklogin", name);
		Console.WriteLine(response.IsSuccessStatusCode);

		if (!response.IsSuccessStatusCode)
		{
			// ������� ��������� ��������� �� ������ �� ������
			var errorContent = await response.Content.ReadAsStringAsync();
			Console.WriteLine($"������: {errorContent}");
			return false;
		}

		return response.IsSuccessStatusCode;
	}
}