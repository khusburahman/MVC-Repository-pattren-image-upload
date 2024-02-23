namespace Test.Webapp.Models.Base;

public abstract class BaseEntity<TId>
{
    public TId Id { get; set; }
}
public class BaseEntity:BaseEntity<long> { }
