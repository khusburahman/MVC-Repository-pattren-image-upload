using AutoMapper;
using Test.Webapp.Models;
using Test.Webapp.Models.Base;

namespace Test.Webapp.ViewModel;
[AutoMap(typeof(Student),ReverseMap =true)]
public class StudentVm:AuditableEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string RegistrationId { get; set; }
    public string Address { get; set; }
    public string Image { get; set; }
}
