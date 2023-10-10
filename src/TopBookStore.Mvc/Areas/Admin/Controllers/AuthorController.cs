using Microsoft.AspNetCore.Mvc;
using TopBookStore.Application.Interfaces;
using TopBookStore.Domain.Entities;

namespace TopBookStore.Mvc.Areas.Admin.Controllers;

[Area("Admin")]
public class AuthorController : Controller
{
    private readonly IAuthorService _service;

    public AuthorController(IAuthorService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Upsert(int? id)
    {
        Author? author = new();
        if (id is null)
        {
            ViewBag.Action = "Add";
            return View(author);
        }

        ViewBag.Action = "Update";
        author = await _service.GetAuthorByIdAsync(id.GetValueOrDefault());
        return View(author);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upsert(Author author)
    {
        if (ModelState.IsValid)
        {
            if (author.AuthorId == 0) // add
            {
                await _service.AddAuthorAsync(author);
            }
            else // update
            {
                await _service.UpdateAuthorAsync(author);
            }
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Action = author.AuthorId == 0 ? "Add" : "Update";
        return View(author);
    }

    #region API CALLS

    [HttpGet]
    public async Task<IActionResult> GetAllAuthors()
    {
        return Json(new { data = await _service.GetAllAuthorsAsync() });
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        Author? author = await _service.GetAuthorByIdAsync(id);
        if (author is null)
        {
            return Json(new { success = false, message = "Không tìm thấy tác giả bạn muốn xóa." });
        }

        await _service.DeleteAuthorAsync(author);
        return Json(new { success = true, message = "Đã xóa thành công." });
    }

    #endregion
}