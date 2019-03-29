namespace HCI.ExcelMapper.Contracts
{
	public interface IColumnMap
	{
		string ColumnName { get; set; }
		string PropertyName { get; set; }
		int ColumnIndex { get; set; }
		bool NormalizeValue { get; set; }
	}
}
