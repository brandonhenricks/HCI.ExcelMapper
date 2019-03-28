namespace HCI.ExcelMapper.Contracts
{
	using System.Collections.Generic;

	public interface IExcelMapper
	{
		IExcelMapper AddFile(string filePath);
		IExcelMapper AddTemplate(IMappingTemplate template);
		IList<T> Map<T>();
	}
}
