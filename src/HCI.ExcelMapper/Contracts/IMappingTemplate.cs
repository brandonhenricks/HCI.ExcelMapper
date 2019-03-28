namespace HCI.ExcelMapper.Contracts
{
	using System.Data;
	using System.Collections.Generic;

	public interface IMappingTemplate
	{
		bool UseColumnIndex { get; set; }
		DataSet Data { get; }
		ICollection<IColumnMap> Maps { get; }
		void Add(IColumnMap columnMap);
		void Remove(IColumnMap columnMap);
		IColumnMap GetMap(string columnName);
		IColumnMap GetMap(int columnIndex);
	}
}
