using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P7CreateRestApi.Services;
using P7CreateRestApi.Repositories.Interfaces;
using P7CreateRestApi.ViewsModels.Rules;
using Dot.Net.WebApi.Controllers;

namespace P7CreateRestApiUnitTests.ServiceUnitTests
{
    public class RuleServiceUnitTests
    {
        private readonly Mock<IRuleRepository> _ruleRepositoryMock;
        private readonly RuleService _ruleService;

        public RuleServiceUnitTests()
        {
            _ruleRepositoryMock = new Mock<IRuleRepository>();
            _ruleService = new RuleService(_ruleRepositoryMock.Object);
        }

        [Fact]
        public async Task AddRule_Should_Call_Repository_AddAsync()
        {
            var rule = new Rule { Id = 1, Name = "Test Rule" };

            await _ruleService.AddRule(rule);

            _ruleRepositoryMock.Verify(r => r.AddAsync(rule), Times.Once);
        }

        [Fact]
        public async Task GetAllRules_Should_Return_List_Of_Rules()
        {
            var rules = new List<Rule>
            {
                new Rule { Id = 1, Name = "Rule 1", Description = "Desc 1" },
                new Rule { Id = 2, Name = "Rule 2", Description = "Desc 2" }
            };

            _ruleRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(rules);

            var result = await _ruleService.GetAllRules();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Rule 1", result[0].Name);
            Assert.Equal("Rule 2", result[1].Name);
        }

        [Fact]
        public async Task GetRuleById_Should_Return_Correct_Rule()
        {
            var rule = new Rule { Id = 1, Name = "Test Rule" };
            _ruleRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(rule);

            var result = await _ruleService.GetRuleByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Test Rule", result.Name);
        }

        [Fact]
        public async Task GetRuleById_Should_Throw_KeyNotFoundException_When_Not_Found()
        {
            _ruleRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Rule)null);

            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _ruleService.GetRuleByIdAsync(1));

            Assert.Equal("La règle avec l'ID 1 n'existe pas.", exception.Message);
        }

        [Fact]
        public async Task UpdateRule_Should_Update_Existing_Rule()
        {
            var rule = new Rule { Id = 1, Name = "Old Rule", Description = "Old Desc" };
            var updateModel = new UpdateRuleViewModel { Id = 1, Name = "New Rule", Description = "New Desc" };

            _ruleRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(rule);

            var result = await _ruleService.UpdateRule(updateModel);

            Assert.NotNull(result);
            Assert.Equal("New Rule", result.Name);
            Assert.Equal("New Desc", result.Description);

            _ruleRepositoryMock.Verify(r => r.UpdateAsync(It.IsAny<Rule>()), Times.Once);
        }

        [Fact]
        public async Task UpdateRule_Should_Throw_KeyNotFoundException_When_Not_Found()
        {
            var updateModel = new UpdateRuleViewModel { Id = 1, Name = "New Rule" };
            _ruleRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Rule)null);

            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _ruleService.UpdateRule(updateModel));

            Assert.Equal("La règle avec l'ID 1 n'existe pas.", exception.Message);
        }

        [Fact]
        public async Task RemoveRule_Should_Delete_Existing_Rule()
        {
            var rule = new Rule { Id = 1, Name = "Test Rule" };
            _ruleRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(rule);

            await _ruleService.RemoveRule(1);

            _ruleRepositoryMock.Verify(r => r.DeleteAsync(1), Times.Once);
        }

        [Fact]
        public async Task RemoveRule_Should_Throw_KeyNotFoundException_When_Not_Found()
        {
            _ruleRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Rule)null);

            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _ruleService.RemoveRule(1));

            Assert.Equal("La règle avec l'ID 1 n'existe pas.", exception.Message);
        }
    }
}
