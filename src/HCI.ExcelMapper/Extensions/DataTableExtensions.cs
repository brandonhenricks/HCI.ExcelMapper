namespace HCI.ExcelMapper.Extensions
{
	using System;
	using System.Data;
	using HCI.ExcelMapper.Contracts;
	using Newtonsoft.Json.Linq;

	/// <summary>
	/// <see cref="DataTable"/> extensions.
	/// </summary>
	public static class DataTableExtensions
	{
		/// <summary>
		/// Convert <paramref name="dataTable"/> to <see cref="JArray"/>.
		/// </summary>
		/// <returns>The JA rray.</returns>
		/// <param name="dataTable">Data table.</param>
		public static JArray ToJArray(this DataTable dataTable)
		{
			var jArray = new JArray();

			var columnNames = dataTable.Columns.GetColumnNames();

			foreach (DataRow row in dataTable.Rows)
			{
				var jObject = new JObject();

				foreach (var column in columnNames)
				{
					jObject.Add(column, row[column].ToString());
				}

				jArray.Add(jObject);
			}

			return jArray;
		}

		/// <summary>
		/// Convert <paramref name="dataTable"/> to <see cref="JArray"/> using <paramref name="mappingTemplate"/>.
		/// </summary>
		/// <returns>The jarray.</returns>
		/// <param name="dataTable">Data table.</param>
		/// <param name="mappingTemplate">Mapping template.</param>
		public static JArray ToJarray(this DataTable dataTable, IMappingTemplate mappingTemplate)
		{
			if (dataTable is null)
			{
				throw new NullReferenceException(nameof(dataTable));
			}

			if (mappingTemplate is null)
			{
				throw new ArgumentNullException(nameof(mappingTemplate));
			}

			var jArray = new JArray();

			foreach (DataRow row in dataTable.Rows)
			{
				var jObject = new JObject();

				int colIndex = 0;

				foreach (DataColumn column in dataTable.Columns)
				{
					IColumnMap columnMap = null;

					if (mappingTemplate.UseColumnIndex)
					{
						columnMap = mappingTemplate.GetMap(columnIndex: colIndex);
					}
					else
					{
						columnMap = mappingTemplate.GetMap(columnName: column.ColumnName);
					}

					if (columnMap is null) continue;

					jObject.Add(new JProperty(columnMap.PropertyName, row[column].ToString()));

					colIndex++;
				}

				colIndex = 0;
				jArray.Add(jObject);
			}
			return jArray;
		}
	}
}
