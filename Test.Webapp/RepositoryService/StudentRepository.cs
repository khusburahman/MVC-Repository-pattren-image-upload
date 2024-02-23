

using AutoMapper;
using Test.Webapp.DatabaseContext;
using Test.Webapp.Models;
using Test.Webapp.Service;
using Test.Webapp.ViewModel;

namespace Test.Webapp.RepositoryService;

public class StudentRepository:RepositoryService
    <Student,StudentVm>, IStudentRepository

{
    public StudentRepository(StudentDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {

    }

}

