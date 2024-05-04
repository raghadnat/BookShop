using FluentAssertions;
using Microsoft.AspNetCore.Routing;
using NUnit.Framework;
using System.Net;
using RestSharp;
using System.Text.Json;

namespace BookShop.UnitTest
{
    public class APITests
    {
        APIRequest request = new APIRequest();

        [Test]
        public void SearchBooks()
        {
            RestResponse response = request.GetApiRequest();
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void CreateABook()
        {
            RestResponse response = request.PostApiRequest();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();
            var bodyContent = JsonSerializer.Deserialize<ApiEntities>(response.Content);
            bodyContent.Title.Should().NotBeNull();
            bodyContent.price.Should().BePositive();
        }
        [Test]
        public void UpdateABook()
        {
            RestResponse response = request.PutApiRequest(15);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();
            var bodyContent = JsonSerializer.Deserialize<ApiEntities>(response.Content);
            bodyContent.price.Should().BePositive();
            bodyContent.Title.Should().NotBeNull();
        }

        [Test]
        public void DeleteABook()
        {
            RestResponse response = request.DeleteFakeApiRequest(15);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNull();
        }
    }
}
