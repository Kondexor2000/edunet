// Algorytmy asynchroniczne
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Worknet.Data;
using Eduworknet.Models;
using Eduworknet.DTOs;

[ApiController]
[Route("api/subjects")]
[Authorize]
public class SubjectController : ControllerBase
{
    private readonly AppDbContext _context;

    public SubjectController(AppDbContext context, ILogger<SubjectController> logger)
    {
        _context = context;
    }

    // =====================================================
    // ADD SUBJECTS (AddSubjectView – FormSet)
    // =====================================================
    [Authorize(Roles = "Moderator")]
    [HttpPost("subject/")]
    public async Task<IActionResult> AddSubjects(
        [FromBody] SubjectDto dto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return Unauthorized();

        foreach (var subjectDto in dto.Subjects)
        {
            if (string.IsNullOrWhiteSpace(subjectDto.Title))
                continue; // odpowiednik form.has_changed()

            var subject = new Subject
            {
                Title = subjectDto.Title,
                Description = subjectDto.Description,
            };

            _context.Subjects.Add(subject);
        }

        await _context.SaveChangesAsync();

        return Created("", new
        {
            message = "Subjects added successfully",
        });
    }

    // =====================================================
    // UPDATE SUBJECT (UpdateSubjectView)
    // =====================================================
    [Authorize(Roles = "Moderator")]
    [HttpPut("/subject/{subjectId:int}")]
    public async Task<IActionResult> UpdateSubject(
        int subjectId,
        [FromBody] SubjectDto dto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return Unauthorized();

        var subject = await _context.Subjects
            .FirstOrDefaultAsync(s =>
                s.Id == subjectId);

        if (subject == null)
            return NotFound("Subject not found or no permission");

        subject.Title = dto.Title;
        subject.Description = dto.Description;

        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "Subject updated successfully",
            subjectId = subject.Id
        });
    }

    // =====================================================
    // DELETE SUBJECT (DeleteSubjectView)
    // =====================================================
    [Authorize(Roles = "Moderator")]
    [HttpDelete("/subject/{subjectId:int}")]
    public async Task<IActionResult> DeleteSubject(
        int subjectId)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
            return Unauthorized();

        var subject = await _context.Subjects
            .FirstOrDefaultAsync(s =>
                s.Id == subjectId);

        if (subject == null)
            return NotFound("Subject not found or no permission");

        _context.Subjects.Remove(subject);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "Subject deleted successfully",
            subjectId = subjectId
        });
    }

    // =====================================================
    // GET SUBJECT (helper)
    // =====================================================
    [HttpGet("{subjectId:int}")]
    public async Task<IActionResult> GetSubject(int subjectId)
    {
        var subject = await _context.Subjects
            .FirstOrDefaultAsync(s => s.Id == subjectId);

        if (subject == null)
            return NotFound();

        return Ok(subject);
    }
    [HttpGet]
    public async Task<IActionResult> Search()
    {
        // Pobranie query string w bezpieczny sposób
        string query = Request.Query["q"].FirstOrDefault()?.Trim() ?? string.Empty;
        string categoryIdStr = Request.Query["category"].FirstOrDefault() ?? string.Empty;
        string tagsIdStr = Request.Query["tags"].FirstOrDefault() ?? string.Empty;

        // Początkowe zapytanie do bazy
        IQueryable<Subject> subjectQuery = _context.Subjects;

        // Filtrowanie po tytule
        if (!string.IsNullOrWhiteSpace(query))
        {
            subjectQuery = subjectQuery.Where(s =>
                EF.Functions.Like(s.Title, $"%{query}%"));
        }

        // Filtrowanie po categoryId
        if (!string.IsNullOrEmpty(categoryIdStr) && int.TryParse(categoryIdStr, out int categoryId))
        {
            subjectQuery = subjectQuery.Where(s =>
                s.CategoryCourses.Any(c => c.Id == categoryId));
        }

        // Filtrowanie po tagsId
        if (!string.IsNullOrEmpty(tagsIdStr) && int.TryParse(tagsIdStr, out int tagsId))
        {
            subjectQuery = subjectQuery.Where(s =>
                s.TagCourses.Any(t => t.Id == tagsId));
        }

        // Pobranie wyników z bazy
        var subjects = await subjectQuery
            .Include(s => s.CategoryCourses)
            .Include(s => s.TagCourses)
            .ToListAsync();

        // Jeśli chcesz zwrócić JSON (API)
        return Ok(subjects);

        // Jeśli chcesz widok Razor MVC:
        // return View(subjects);
    }

}