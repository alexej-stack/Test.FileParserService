using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Test.Common.Model;

namespace Test.Database.ProcessingResult;

public class ModuleData
{
	[Key]
	public int Id { get; set; }
	
	[Required]
	[MaxLength(50)]
	public string ModuleCategoryID { get; set; }

	[Required]
	[EnumDataType(typeof(ModuleState))]
	public ModuleState ModuleState { get; set; }

}