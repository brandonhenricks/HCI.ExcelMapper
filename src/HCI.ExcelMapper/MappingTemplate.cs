
namespace HCI.ExcelMapper
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using HCI.ExcelMapper.Contracts;

	/// <summary>
	/// Mapping template.
	/// </summary>
	public abstract class MappingTemplate : IMappingTemplate
	{
		private readonly HashSet<IColumnMap> _columnMaps;

		protected MappingTemplate()
		{
			_columnMaps = new HashSet<IColumnMap>();
			UseColumnIndex = false;
		}

		public bool UseColumnIndex { get; set; }
		public DataSet Data { get; }
		public ICollection<IColumnMap> Maps { get; }

		/// <summary>
		/// Adds <paramref name="columnMap"/> to <see cref="Maps"/>.
		/// </summary>
		/// <param name="columnMap">Column map.</param>
		public void Add(IColumnMap columnMap)
		{
			if (columnMap is null)
			{
				throw new ArgumentNullException(nameof(columnMap));
			}

			if (!_columnMaps.Contains(columnMap))
			{
				_columnMaps.Add(columnMap);
			}
		}

		/// <summary>
		/// Returns the <see cref="IColumnMap"/> by <paramref name="columnName"/>
		/// </summary>
		/// <returns>The map.</returns>
		/// <param name="columnName">Column name.</param>
		public IColumnMap GetMap(string columnName)
		{
			if (string.IsNullOrEmpty(columnName))
			{
				throw new ArgumentNullException(nameof(columnName));
			}

			return _columnMaps.FirstOrDefault(x => x.ColumnName.Equals(columnName, StringComparison.OrdinalIgnoreCase));
		}

		/// <summary>
		/// Returns the <see cref="IColumnMap"/> by <paramref name="columnIndex"/>
		/// </summary>
		/// <returns>The map.</returns>
		/// <param name="columnIndex">Column index.</param>
		public IColumnMap GetMap(int columnIndex)
		{
			if (columnIndex < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(columnIndex));
			}

			return _columnMaps.FirstOrDefault(x => x.ColumnIndex == columnIndex);
		}

		/// <summary>
		/// Removes the <paramref name="columnMap"/> from <see cref="Maps"/>
		/// <param name="columnMap">Column map.</param>
		public void Remove(IColumnMap columnMap)
		{
			if (columnMap is null)
			{
				throw new ArgumentNullException(nameof(columnMap));
			}

			if (_columnMaps.Contains(columnMap))
			{
				_columnMaps.Remove(columnMap);
			}
		}
	}
}
