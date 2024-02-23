using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Test.Webapp.RepositoryService;
using Test.Webapp.ViewModel;

namespace Test.Webapp.Controllers;

public class StudentController : Controller
{
    private readonly IStudentRepository studentRepository;

    public StudentController(IStudentRepository studentRepository)
    {
        this.studentRepository = studentRepository;
    }
    public async Task<ActionResult<StudentVm>> Index(CancellationToken cancellationToken)
    {
        return View(await studentRepository.GetAllAsync(cancellationToken));
    }
    public async Task<ActionResult<StudentVm>> CreateOrEdit(long id, CancellationToken cancellationToken)
    {
        if (id == 0)
        {
            return View(new StudentVm());
        }
        else
        {
            return View(await studentRepository.GetByIdAsync(id, cancellationToken));
        }
    }
    [HttpPost]
    public async Task<ActionResult<StudentVm>>CreateOrEdit(long id,StudentVm studentVm,CancellationToken cancellationToken,IFormFile photo)
    {
        if (id == 0)
        {
            if (ModelState.IsValid)
            {
                if(photo!=null&&photo.Length>0)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot/images/student",photo.FileName);
                    using (var stream=new FileStream(path, FileMode.Create))
                    {
                        photo.CopyTo(stream);
                    }
                    studentVm.Image = $"{photo.FileName}";

                }
                await studentRepository.InsertAsync(studentVm, cancellationToken);
                return RedirectToAction(nameof(Index)); 
            }
        }
        else
        {
          await studentRepository.UpdateAsync(id,studentVm,cancellationToken);
            return RedirectToAction(nameof(Index));
        }
        return View(new StudentVm());
    }
    public async Task<ActionResult<StudentVm>>Delete(long id,CancellationToken cancellationToken)
    {
        if (id == 0)
        {
            return RedirectToAction(nameof(Index));
        }
        else
        {
            await studentRepository.DeleteAsync(id, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
    }
    public async Task<ActionResult<StudentVm>>Details(long id,CancellationToken cancellationToken)
    {
        if (id == 0)
        {
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return View(await studentRepository.GetByIdAsync(id, cancellationToken));
        }
    }
}
    