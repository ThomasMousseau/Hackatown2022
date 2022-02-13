using Models;


namespace Interfaces {
    public interface ILogicLayer
    {
        Task<List<Topic>> GetAllNews();
    }
}
