using AbajurrBot.Core.Models;
using Xunit;

namespace AbajurrBot.Core.Tests.Models
{
    public class RoleTest
    {
        [Fact]
        public void Constructor_WithoutName_NameIsEmpty()
        {
            // Arrange
            // Act
            var role = new Role();

            // Assert
            Assert.Empty(role.Name);
        }

        [Fact]
        public void Constructor_WithoutUsers_UsersIsEmpty()
        {
            // Arrange
            // Act
            var role = new Role();

            // Assert
            Assert.Empty(role.Users);
        }
    }
}
