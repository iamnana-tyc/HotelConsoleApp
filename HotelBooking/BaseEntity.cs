public class BaseEntity : IIdentifiable
{
    public int Id { get ; set ; }

    public virtual string Display()
    {
        return $"{this.GetType().Name} Id:{Id}";
    }
}