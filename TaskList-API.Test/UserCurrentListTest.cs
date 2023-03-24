using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TaskList_API.Test.Consts;
using TaskList_API.Test.Utilites;
using Xunit;

namespace TaskList_API.Test
{
    public class UserCurrentListTest : BaseTest
    {
        public UserCurrentListTest() : base()
        {
        }

        [Fact]
        public async Task Should_assignment_and_unassignment_CurrentTaskTest()
        {
            //// Arrange
            var content = new StringContent(JsonConvert.SerializeObject(Defaults.CurrentTaskLists.ElementAt(0).CurrentTaskListId), Encoding.UTF8, "application/json-post+json");
            var userId = Defaults.Users.ElementAt(1).UserId;
            var currentTasklistId = Defaults.CurrentTaskLists.ElementAt(9).CurrentTaskListId;
            //// Act
            var responseAssignment = await _client.PutAsync($"api/user-tasks/{userId}/assignment/{currentTasklistId}", content);

            //// Assert
            responseAssignment.StatusCode.Should().Be(HttpStatusCode.OK);
            var bodyAssignment = await responseAssignment.BodyAs<Guid>();

            //// Act
            var responseUnAssignment = await _client.PutAsync($"api/user-tasks/{userId}/unassignment/{currentTasklistId}", content);

            //// Assert
            responseUnAssignment.StatusCode.Should().Be(HttpStatusCode.OK);
            var bodyUnAssignment = await responseUnAssignment.BodyAs<Guid>();

        }
    }
}
