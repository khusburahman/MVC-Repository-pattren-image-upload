using AutoMapper;
using Test.Webapp.DatabaseContext;
using Test.Webapp.Models;
using Test.Webapp.Service;
using Test.Webapp.ViewModel;

namespace Test.Webapp.RepositoryService;

public interface IStudentRepository : IRepositoryService<Student, StudentVm>
{
}
