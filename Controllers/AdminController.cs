using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Worknet.Data;
using Eduworknet.Models;

public class AdminController : Controller
{
    private readonly AppDbContext _context;

    public AdminController(AppDbContext context)
    {
        _context = context;
    }

    // =================== TAG COURSE ===================

    public async Task<IActionResult> Tags()
    {
        var tags = await _context.TagCourses.ToListAsync();
        return View(tags);
    }

    public IActionResult CreateTag() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateTag(TagCourse tag)
    {
        if (!ModelState.IsValid) return View(tag);

        _context.TagCourses.Add(tag);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Tags));
    }

    public async Task<IActionResult> EditTag(int id)
    {
        var tag = await _context.TagCourses.FindAsync(id);
        if (tag == null) return NotFound();
        return View(tag);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditTag(TagCourse tag)
    {
        if (!ModelState.IsValid) return View(tag);

        _context.Update(tag);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Tags));
    }

    public async Task<IActionResult> DeleteTag(int id)
    {
        var tag = await _context.TagCourses.FindAsync(id);
        if (tag == null) return NotFound();
        return View(tag);
    }

    [HttpPost, ActionName("DeleteTag")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteTagConfirmed(int id)
    {
        var tag = await _context.TagCourses.FindAsync(id);
        if (tag != null)
        {
            _context.TagCourses.Remove(tag);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Tags));
    }

    // =================== CATEGORY COURSE ===================

    public async Task<IActionResult> Categories()
    {
        var categories = await _context.CategoryCourses.ToListAsync();
        return View(categories);
    }

    public IActionResult CreateCategory() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateCategory(CategoryCourse category)
    {
        if (!ModelState.IsValid) return View(category);

        _context.CategoryCourses.Add(category);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Categories));
    }

    public async Task<IActionResult> EditCategory(int id)
    {
        var category = await _context.CategoryCourses.FindAsync(id);
        if (category == null) return NotFound();
        return View(category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditCategory(CategoryCourse category)
    {
        if (!ModelState.IsValid) return View(category);

        _context.Update(category);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Categories));
    }

    public async Task<IActionResult> DeleteCategory(int id)
    {
        var category = await _context.CategoryCourses.FindAsync(id);
        if (category == null) return NotFound();
        return View(category);
    }

    [HttpPost, ActionName("DeleteCategory")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteCategoryConfirmed(int id)
    {
        var category = await _context.CategoryCourses.FindAsync(id);
        if (category != null)
        {
            _context.CategoryCourses.Remove(category);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Categories));
    }
}
