using Dot.Net.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using P7CreateRestApi.Services.Interfaces;
using P7CreateRestApi.ViewsModels.Rules;

namespace P7CreateRestApiUnitTests.ControllerUnitTests
{
    public class RuleControllerUnitTests
    {
        private readonly Mock<IRuleService> _mockService;
        private readonly RuleController _controller;

        public RuleControllerUnitTests()
        {
            _mockService = new Mock<IRuleService>();
            _controller = new RuleController(_mockService.Object);
        }

        [Fact]
        public async Task AddRule_ValidModel_ReturnsOk()
        {
            // ARRANGE
            var model = new AddRuleViewModel { Name = "Rule1", Description = "Description", Json = "{}", Template = "Template", SqlStr = "SQL", SqlPart = "SQLPart" };
            var rule = new Rule { Name = model.Name, Description = model.Description, Json = model.Json, Template = model.Template, SqlStr = model.SqlStr, SqlPart = model.SqlPart };

            _mockService.Setup(s => s.AddRule(It.IsAny<Rule>())).Returns(Task.CompletedTask);

            // ACT
            var result = await _controller.AddRule(model);

            // ASSERT
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedRule = Assert.IsType<Rule>(okResult.Value);
            Assert.Equal(model.Name, returnedRule.Name);
        }

        [Fact]
        public async Task AddRule_InvalidModel_ReturnsBadRequest()
        {
            // ARRANGE
            _controller.ModelState.AddModelError("Name", "Required");
            var model = new AddRuleViewModel();

            // ACT
            var result = await _controller.AddRule(model);

            // ASSERT
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task GetRule_ExistingId_ReturnsOk()
        {
            // ARRANGE
            var rule = new GetRuleViewModel { Id = 1, Name = "Rule1" };
            _mockService.Setup(s => s.GetRuleByIdAsync(1)).ReturnsAsync(rule);

            // ACT
            var result = await _controller.GetRule(1);

            // ASSERT
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedRule = Assert.IsType<GetRuleViewModel>(okResult.Value);
            Assert.Equal(rule.Id, returnedRule.Id);
        }

        [Fact]
        public async Task GetAllRules_ReturnsOk()
        {
            // ARRANGE
            var list = new List<GetRuleViewModel> { new GetRuleViewModel { Id = 1 }, new GetRuleViewModel { Id = 2 } };
            _mockService.Setup(s => s.GetAllRules()).ReturnsAsync(list);

            // ACT
            var result = await _controller.GetAllRules();

            // ASSERT
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedList = Assert.IsType<List<GetRuleViewModel>>(okResult.Value);
            Assert.Equal(2, returnedList.Count);
        }

        [Fact]
        public async Task UpdateRule_ValidModel_ReturnsOk()
        {
            // ARRANGE
            var model = new UpdateRuleViewModel { Id = 1, Name = "Updated Rule" };
            var updatedRule = new GetRuleViewModel { Id = 1, Name = "Updated Rule" };
            _mockService.Setup(s => s.UpdateRule(model)).ReturnsAsync(updatedRule);

            // ACT
            var result = await _controller.UpdateRule(1, model);

            // ASSERT
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedRule = Assert.IsType<GetRuleViewModel>(okResult.Value);
            Assert.Equal(updatedRule.Id, returnedRule.Id);
        }

        [Fact]
        public async Task UpdateRule_MismatchedId_ReturnsBadRequest()
        {
            // ARRANGE
            var model = new UpdateRuleViewModel { Id = 2 };

            // ACT
            var result = await _controller.UpdateRule(1, model);

            // ASSERT
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task DeleteRule_ValidId_ReturnsOk()
        {
            // ARRANGE
            _mockService.Setup(s => s.RemoveRule(1)).Returns(Task.CompletedTask);

            // ACT
            var result = await _controller.DeleteRule(1);

            // ASSERT
            Assert.IsType<OkResult>(result);
        }
    }
}
