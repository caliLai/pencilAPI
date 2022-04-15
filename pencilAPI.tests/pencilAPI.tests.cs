using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Moq;
using pencilAPI.tests.MockData;
using pencilAPI.Services;
using pencilAPI.Controllers;

namespace pencilAPI.tests.Controllers;

public class TestController : IClassFixture<WebApplicationFactory<Program>>
{
	private readonly WebApplicationFactory<Program> _factory;

	public TestController(WebApplicationFactory<Program> factory)
	{
		_factory = factory;
	}

    [Fact]
    public async Task GetAsync_ShouldReturn200Status()
    {
        // Arrange
		var client = _factory.CreateClient();

        /// Act
        var response = await client.GetAsync("/api/Pencil");
 
        // /// Assert
        Assert.Equal(true, response.IsSuccessStatusCode);
    }
}