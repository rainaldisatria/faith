public interface IPool<T> 
{
    void Prewarm(int number);
    T Request();
    void Return(T member);
}
