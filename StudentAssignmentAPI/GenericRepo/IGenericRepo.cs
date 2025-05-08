namespace StudentAssignmentAPI.GenericRepo;

public interface IGenericRepo<TModel> where TModel : class
{
    Task<List<TModel>> GetAllAsync();
    Task<TModel?> GetByIdAsync(Guid id);
    Task AddAsync(TModel entity);
    Task UpdateAsync(TModel entity);
    Task DeleteAsync(Guid id);
}