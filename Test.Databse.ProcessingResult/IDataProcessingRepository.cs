using Test.Database;

namespace Test.Database.ProcessingResult;

public interface IDataProcessingRepository:IRepositoryBase<ModuleData>
{
	Task<ModuleData?> GetByCategoryId(string moduleCategoryId, bool trackChanges = false);
}