using Xunit;
using Microsoft.EntityFrameworkCore;
using Worknet.Data;
using Eduworknet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

public class AdminControllerIntegrationTests
{
    private AppDbContext GetInMemoryDbContext(string dbName)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;
        return new AppDbContext(options);
    }

    // =================== TAG COURSE ===================
    [Fact]
    public async Task Tags_ReturnsAllTags()
    {
        using var context = GetInMemoryDbContext("TagsDb");
        context.TagCourses.AddRange(new TagCourse { Name = "Tag1" }, new TagCourse { Name = "Tag2" });
        context.SaveChanges();

        var controller = new AdminController(context);
        var result = await controller.Tags();
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<TagCourse>>(viewResult.Model);
        Assert.Equal(2, model.Count());
    }

    [Fact]
    public async Task CreateTag_AddsTagToDatabase()
    {
        using var context = GetInMemoryDbContext("CreateTagDb");
        var controller = new AdminController(context);
        var tag = new TagCourse { Name = "NewTag" };
        var result = await controller.CreateTag(tag);

        Assert.Single(context.TagCourses);
        Assert.Equal("NewTag", context.TagCourses.First().Name);
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Tags", redirectResult.ActionName);
    }

    [Fact]
    public async Task DeleteTagConfirmed_RemovesTag()
    {
        using var context = GetInMemoryDbContext("DeleteTagDb");
        var tag = new TagCourse { Name = "ToDelete" };
        context.TagCourses.Add(tag);
        context.SaveChanges();

        var controller = new AdminController(context);
        var result = await controller.DeleteTagConfirmed(tag.Id);

        Assert.Empty(context.TagCourses);
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Tags", redirectResult.ActionName);
    }

    // =================== CATEGORY COURSE ===================
    [Fact]
    public async Task Categories_ReturnsAllCategories()
    {
        using var context = GetInMemoryDbContext("CategoriesDb");
        context.CategoryCourses.AddRange(new CategoryCourse { Name = "Cat1" }, new CategoryCourse { Name = "Cat2" });
        context.SaveChanges();

        var controller = new AdminController(context);
        var result = await controller.Categories();
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<CategoryCourse>>(viewResult.Model);
        Assert.Equal(2, model.Count());
    }

    [Fact]
    public async Task CreateCategory_AddsCategoryToDatabase()
    {
        using var context = GetInMemoryDbContext("CreateCategoryDb");
        var controller = new AdminController(context);
        var category = new CategoryCourse { Name = "NewCategory" };
        var result = await controller.CreateCategory(category);

        Assert.Single(context.CategoryCourses);
        Assert.Equal("NewCategory", context.CategoryCourses.First().Name);
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Categories", redirectResult.ActionName);
    }

    [Fact]
    public async Task DeleteCategoryConfirmed_RemovesCategory()
    {
        using var context = GetInMemoryDbContext("DeleteCategoryDb");
        var category = new CategoryCourse { Name = "ToDelete" };
        context.CategoryCourses.Add(category);
        context.SaveChanges();

        var controller = new AdminController(context);
        var result = await controller.DeleteCategoryConfirmed(category.Id);

        Assert.Empty(context.CategoryCourses);
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Categories", redirectResult.ActionName);
    }
}
