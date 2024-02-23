using Test.Webapp.Models.Base;

namespace Test.Webapp.Models
{
    public class Student:AuditableEntity
    {
        public string Name {  get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string RegistrationId { get; set; }
        public string Address { get; set; }
        public string Image {  get; set; }
    }
}
