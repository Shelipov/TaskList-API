using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TaskList.BLL.Interface.Common;
using TaskList.BLL.Interface.Dtos;
using TaskList_API.Test.Consts;
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
        public async Task Should_get_all_CurrentTaskTest()
        {
            //// Arrange
            
            //// Act
            var response = await _client.GetAsync($"api/task-list/search?UserId={Defaults.Users.ElementAt(0).UserId}");

            //// Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var body = await response.BodyAs<PagedResponse<TaskListResponse>>();
            body.TotalCount.Should().Be(body.Items.Count());
            
        }

        [Fact]
        public async Task Should_create_get_update_delete_CurrentTaskListTest()
        {
            //// Arrange
            var UserId = Defaults.Users.ElementAt(0).UserId;
            var createCurrentTaskListDto = new CreateCurrentTaskListDto
            {
                CurrentTaskListName = "CurrentTaskListName",
                UserId = UserId,
                CreateCurrentTaskDtos = new List<CreateCurrentTaskDto>
                {
                    new CreateCurrentTaskDto
                    {
                        CurrentTaskName = "CurrentTaskName",
                        Description = "Description"
                    }
                }
            };
            var contentCrete = new StringContent(JsonConvert.SerializeObject(createCurrentTaskListDto), Encoding.UTF8, "application/json-post+json");
            //// Act
            var responseCreate = await _client.PostAsync($"api/task-list", contentCrete);

            //// Assert
            responseCreate.StatusCode.Should().Be(HttpStatusCode.OK);
            var bodyCreate = await responseCreate.BodyAs<Guid>();

            //// Arrange
            var currentTasklistId = bodyCreate;
            //// Act
            var responseGet = await _client.GetAsync($"api/task-list/{currentTasklistId}/user/{UserId}");
            //// Assert
            responseGet.StatusCode.Should().Be(HttpStatusCode.OK);
            var bodyGet = await responseGet.BodyAs<CurrentTaskListDto>();

            //// Arrange
            var currentTaskListDto = bodyGet;
            var contentUpdate = new StringContent(JsonConvert.SerializeObject(currentTaskListDto), Encoding.UTF8, "application/json-post+json");
            //// Act
            var responseUpdate = await _client.PutAsync($"api/task-list", contentUpdate);
            //// Assert
            responseUpdate.StatusCode.Should().Be(HttpStatusCode.OK);
            var bodyUpdate = await responseUpdate.BodyAs<Guid>();

            //// Arrange
            
            //// Act
            var responseDelete = await _client.DeleteAsync($"api/task-list/{bodyUpdate}/user/{UserId}");
            //// Assert
            responseDelete.StatusCode.Should().Be(HttpStatusCode.OK);
            var bodyDelete = await responseDelete.BodyAs<Guid>();
            bodyDelete.Should().Be(bodyUpdate);

        }


    }
}