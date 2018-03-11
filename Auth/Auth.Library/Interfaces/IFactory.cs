namespace Auth.Library.Interfaces
{
    public interface IFactory
    {
        T Make<T>();
    }
}
