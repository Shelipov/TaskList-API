using FluentAssertions;
using NUnit.Framework;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TaskList.BLL.Interface.Common;
using TaskList.BLL.Interface.Dtos;
using TaskList_API.Test.Utilites;
using Xunit;

namespace TaskList_API.Test
{
    public class CurrentTaskTest : BaseTest
    {
        public CurrentTaskTest() : base()
        {
        }

        [Fact]
        public async Task Should_get_CurrentTaskTest_by_id()
        {
            //// Arrange
            
            //// Act
            var response = await _client.GetAsync("api/task-list/search");

            //// Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var body = await response.BodyAs<PagedResponse<TaskListResponse>>();
            body.TotalCount.Should().Be(body.Items.Count());
            
        }

        
    }
}