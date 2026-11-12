namespace XUnitCSharp;

public class UnitTests
{
    [Fact]
    public void Test()
    {
        // Arrange

        // Act

        // Assert
    }

    [Fact]
    public async Task Test_Verify()
    {
        // Arrange

        // Act
        var result = "value";

        // Assert
        await Verify(result).UseFileName("FileName");
    }
}
