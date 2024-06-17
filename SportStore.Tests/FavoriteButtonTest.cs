using AutoFixture;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using SportStore.Blazor.Components;
using SportStore.Blazor.State;
using SportStore.Domen.Models;
using System.Diagnostics.Metrics;

namespace SportStore.Tests;


public class FavoriteButtonTests : TestContext
{
     //private readonly Fixture _fixture = new();
    
     public FavoriteButtonTests()
     {
         this.AddBlazoredLocalStorage();
         this.Services.AddScoped<AppState>();
     }


    [Fact]
    public void RendersAddFavoriteButton_When_UserIsNotFavorited()
    {
        // Arrange
        var user = new User();// _fixture.Create<User>();

        // Act

        var cut = RenderComponent<FavoriteButton>(parameters => parameters.Add(p => p.User, user)

    );

        // Assert
        cut.MarkupMatches(
             @"<button class='btn btn-outline-primary ml-1' title='Favorite'><i class='bi bi-heart'></i></button>"
         );
    }


    [Fact]
    public async Task RendersRemoveFavoriteButton_When_TrailIsFavorited()
    {
        // Arrange
        var user = new User(); //_fixture.Create<User>();

        var appState = this.Services.GetService<AppState>();
        await appState.FavoriteUsersState.AddFavorite(user);

        // Act
        var cut = RenderComponent<FavoriteButton>(parameters => parameters.Add(p => p.User, user));
        // Assert
       cut.MarkupMatches("<button class='btn btn-outline-primary ml-1' title='Favorite'><i class='bi bi-heart-fill'></i></button>"
 );
}


}