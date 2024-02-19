using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Test.Database.Base;

namespace Test.Database.ProcessingResult;

public class DataProcessingRepository: RepositoryBase<ModuleData>,IDataProcessingRepository
{

	public DataProcessingRepository(DbContext repositoryContext) : base(repositoryContext)
	{
	}
	public Task<ModuleData?> GetByCategoryId(string moduleCategoryID, bool trackChanges = false)
	{
		return FindByCondition(m => m.ModuleCategoryID == moduleCategoryID, trackChanges)
			.FirstOrDefaultAsync();
	}

}