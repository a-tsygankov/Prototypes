namespace SearchProto1.Model
{
    public interface IPersistable
    {
        int Id { get; set; }
        int GetId();
    }   
}