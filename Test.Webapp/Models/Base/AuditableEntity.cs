namespace Test.Webapp.Models.Base;

public class AuditableEntity<TId>:BaseEntity
{
    public AuditableEntity()
    {
        IsDelete=false;
    }

    public DateTimeOffset CreateDate { get; set; }
    public long CreateBy {  get; set; }
    public DateTimeOffset? ModifiedDate { get; set; }
    public long ModiffiedBy {  get; set; }
    public bool IsDelete { get; set; } 


}
public class AuditableEntity : AuditableEntity<long> { }
