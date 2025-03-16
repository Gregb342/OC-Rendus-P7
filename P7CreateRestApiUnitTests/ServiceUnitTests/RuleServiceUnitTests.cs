using Dot.Net.WebApi.Controllers;
using Moq;
using P7CreateRestApi.Repositories.Interfaces;
using P7CreateRestApi.Services;
using P7CreateRestApi.ViewsModels.Rules;

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
            // ARRANGE
            var rule = new Rule { Id = 1, Name = "Test Rule" };

            // ACT
            await _ruleService.AddRule(rule);

            // ASSERT
            _ruleRepositoryMock.Verify(r => r.AddAsync(rule), Times.Once);
        }

        [Fact]
        public async Task GetAllRules_Should_Return_List_Of_Rules()
        {
            // ARRANGE
            var rules = new List<Rule>
            {
                new Rule { Id = 1, Name = "Rule 1", Description = "Desc 1" },
                new Rule { Id = 2, Name = "Rule 2", Description = "Desc 2" }
            };

            _ruleRepositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(rules);

            // ACT
            var result = await _ruleService.GetAllRules();

            // ASSERT
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Rule 1", result[0].Name);
            Assert.Equal("Rule 2", result[1].Name);
        }

        [Fact]
        public async Task GetRuleById_Should_Return_Correct_Rule()
        {
            // ARRANGE
            var rule = new Rule { Id = 1, Name = "Test Rule" };
            _ruleRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(rule);

            // ACT
            var result = await _ruleService.GetRuleByIdAsync(1);

            // ASSERT
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Test Rule", result.Name);
        }

        [Fact]
        public async Task GetRuleById_Should_Throw_KeyNotFoundException_When_Not_Found()
        {
            // ARRANGE
            _ruleRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Rule)null);

            // ACT
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _ruleService.GetRuleByIdAsync(1));

            // ASSERT
            Assert.Equal("La règle avec l'ID 1 n'existe pas.", exception.Message);
        }

        [Fact]
        public async Task UpdateRule_Should_Update_Existing_Rule()
        {
            // ARRANGE
            var rule = new Rule { Id = 1, Name = "Old Rule", Description = "Old Desc" };
            var updateModel = new UpdateRuleViewModel { Id = 1, Name = "New Rule", Description = "New Desc" };

            _ruleRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(rule);

            // ACT
            var result = await _ruleService.UpdateRule(updateModel);

            // ASSERT
            Assert.NotNull(result);
            Assert.Equal("New Rule", result.Name);
            Assert.Equal("New Desc", result.Description);

            _ruleRepositoryMock.Verify(r => r.UpdateAsync(It.IsAny<Rule>()), Times.Once);
        }

        [Fact]
        public async Task UpdateRule_Should_Throw_KeyNotFoundException_When_Not_Found()
        {
            // ARRANGE
            var updateModel = new UpdateRuleViewModel { Id = 1, Name = "New Rule" };
            _ruleRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Rule)null);

            // ACT
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _ruleService.UpdateRule(updateModel));

            // ASSERT 
            Assert.Equal("La règle avec l'ID 1 n'existe pas.", exception.Message);
        }

        [Fact]
        public async Task RemoveRule_Should_Delete_Existing_Rule()
        {
            // ARRANGE
            var rule = new Rule { Id = 1, Name = "Test Rule" };
            _ruleRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(rule);

            // ACT
            await _ruleService.RemoveRule(1);

            // ASSERT
            _ruleRepositoryMock.Verify(r => r.DeleteAsync(1), Times.Once);
        }

        [Fact]
        public async Task RemoveRule_Should_Throw_KeyNotFoundException_When_Not_Found()
        {
            // ARRANGE
            _ruleRepositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync((Rule)null);

            // ACT
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(() => _ruleService.RemoveRule(1));

            // ASSERT
            Assert.Equal("La règle avec l'ID 1 n'existe pas.", exception.Message);
        }
    }
}
