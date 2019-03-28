namespace HCI.ExcelMapper.Extensions
{
	using System.Collections.Generic;
	using System.Data;
	using Newtonsoft.Json.Linq;

	/// <summary>
	/// <see cref="DataSet"/> extensions.
	/// </summary>
	public static class DataSetExtensions
	{
		/// <summary>
		/// Converts a <see cref="DataTable"/> in the <paramref name="dataSet"/> to <see cref="JArray"/> by <paramref name="tableIndex"/>
		/// </summary>
		/// <returns>The JA rray.</returns>
		/// <param name="dataSet">Data set.</param>
		/// <param name="tableIndex">Table index.</param>
		public static JArray ToJArray(this DataSet dataSet, int tableIndex = 0)
		{
			return dataSet.Tables[tableIndex].ToJArray();
		}

		/// <summary>
		/// Converts the <see cref="DataTable"/> into a <see cref="JArray"/> in the <paramref name="dataSet"/>.
		/// </summary>
		/// <returns>The JA rray list.</returns>
		/// <param name="dataSet">Data set.</param>
		public static List<JArray> ToJArrayList(this DataSet dataSet)
		{
			var jList = new List<JArray>();

			foreach (DataTable dataTable in dataSet.Tables)
			{
				jList.Add(dataTable.ToJArray());
			}

			return jList;
		}
	}
}
