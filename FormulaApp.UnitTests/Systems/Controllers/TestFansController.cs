using FluentAssertions;
using FormulaApp.Api.Controllers;
using FormulaApp.Api.Models;
using FormulaApp.Api.Services.Interfaces;
using FormulaApp.UnitTests.Fixtures;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FormulaApp.UnitTests.Systems.Controllers;

public class TestFansController
{
    [Fact]
    public async Task Get_On_Success_ReturnStatusCode200()
    {
        var mockFanService = new Mock<IFanService>();
        mockFanService.Setup(service => service.GetAllFans()).ReturnsAsync(FansFixtures.GetFans);
        var fansController = new FansController(mockFanService.Object);
        var result = (OkObjectResult) await fansController.Get();
        result.StatusCode.Should().Be(200);

    }

    [Fact]
    public async Task Get_OnSuccess_InvokeService()
    {
        var mockFanService = new Mock<IFanService>();
        mockFanService.Setup(service => service.GetAllFans()).ReturnsAsync(FansFixtures.GetFans);
        var fansController = new FansController(mockFanService.Object);
        var result = (OkObjectResult)await fansController.Get();
        mockFanService.Verify(service => service.GetAllFans(), Times.Once);
    }

    [Fact]
    public async Task Get_OnSuccess_ReturnListOfFans()
    {
        
        var mockFanService = new Mock<IFanService>();
        mockFanService.Setup(service => service.GetAllFans()).ReturnsAsync(FansFixtures.GetFans);
        var fansController = new FansController(mockFanService.Object);
        var result = (OkObjectResult)await fansController.Get();

        result.Should().BeOfType<OkObjectResult>();
        result.Value.Should().BeOfType<List<Fan>>();
    }

    [Fact]
    public async Task Get_OnNoFans_ReturnNotFound()
    {
        var mockFanService = new Mock<IFanService>();
        mockFanService.Setup(service => service.GetAllFans()).ReturnsAsync(new List<Fan>());
        var fansController = new FansController(mockFanService.Object);
        var result = (NotFoundResult)await fansController.Get();
        result.Should().BeOfType<NotFoundResult>();
    }

}