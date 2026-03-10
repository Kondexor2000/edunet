using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Worknet.Data;
using Eduworknet.Models;
using Eduworknet.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class SubjectControllerUnitTests
{
    private SubjectController SetupControllerWithUser(AppDbContext context)
    {
        var controller = new SubjectController(context, Mock.Of<Microsoft.Extensions.Logging.ILogger<SubjectController>>());

        // Mock User
        var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, "1")
        }, "mock"));

        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = user }
        };

        return controller;
    }

    private AppDbContext GetInMemoryDbContext(string dbName)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(dbName)
            .Options;
        return new AppDbContext(options);
    }
    [Fact]
    public async Task UpdateSubject_ExistingSubject_UpdatesSuccessfully()
    {
        using var context = GetInMemoryDbContext("UpdateSubjectDb");
        var subject = new Subject { Title = "Old Title", Description = "Old Desc" };
        context.Subjects.Add(subject);
        context.SaveChanges();

        var controller = SetupControllerWithUser(context);
        var dto = new SubjectDto { Title = "New Title", Description = "New Desc" };

        var result = await controller.UpdateSubject(subject.Id, dto);
        var okResult = Assert.IsType<OkObjectResult>(result);

        var updatedSubject = context.Subjects.First();
        Assert.Equal("New Title", updatedSubject.Title);
        Assert.Equal("New Desc", updatedSubject.Description);
    }

    [Fact]
    public async Task DeleteSubject_RemovesSubject()
    {
        using var context = GetInMemoryDbContext("DeleteSubjectDb");
        var subject = new Subject { Title = "ToDelete" };
        context.Subjects.Add(subject);
        context.SaveChanges();

        var controller = SetupControllerWithUser(context);
        var result = await controller.DeleteSubject(subject.Id);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Empty(context.Subjects);
    }

    [Fact]
    public async Task GetSubject_ReturnsSubject()
    {
        using var context = GetInMemoryDbContext("GetSubjectDb");
        var subject = new Subject { Title = "Physics" };
        context.Subjects.Add(subject);
        context.SaveChanges();

        var controller = SetupControllerWithUser(context);
        var result = await controller.GetSubject(subject.Id);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedSubject = Assert.IsType<Subject>(okResult.Value);
        Assert.Equal("Physics", returnedSubject.Title);
    }

    [Fact]
    public async Task Search_ReturnsFilteredSubjects()
    {
        using var context = GetInMemoryDbContext("SearchSubjectDb");

        var subject1 = new Subject { Title = "Math" };
        var subject2 = new Subject { Title = "Science" };
        context.Subjects.AddRange(subject1, subject2);
        context.SaveChanges();

        var controller = SetupControllerWithUser(context);

        // Mock query string
        controller.ControllerContext.HttpContext.Request.Query = new QueryCollection(
            new Dictionary<string, Microsoft.Extensions.Primitives.StringValues>
            {
                { "q", "Math" }
            }
        );

        var result = await controller.Search();
        var okResult = Assert.IsType<OkObjectResult>(result);
        var subjects = Assert.IsAssignableFrom<IEnumerable<Subject>>(okResult.Value);
        Assert.Single(subjects);
        Assert.Equal("Math", subjects.First().Title);
    }
}
