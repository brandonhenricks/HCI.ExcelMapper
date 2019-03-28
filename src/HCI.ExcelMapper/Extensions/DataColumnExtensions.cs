namespace HCI.ExcelMapper.Extensions
{
	using System;
	using System.Data;
	using System.Linq;

	/// <summary>
	/// <see cref="DataColumnCollection"/> extensions.
	/// </summary>
	public static class DataColumnExtensions
	{
		/// <summary>
		/// Returns an <see cref="Array"/> of Column Names from <paramref name="dataColumns"/>.
		/// </summary>
		/// <returns>The column names.</returns>
		/// <param name="dataColumns">Data columns.</param>
		public static string[] GetColumnNames(this DataColumnCollection dataColumns)
		{
			if (dataColumns is null)
			{
				throw new NullReferenceException(nameof(dataColumns));
			}

			return (from DataColumn col in dataColumns select col.ColumnName).ToArray();
		}
	}
}
