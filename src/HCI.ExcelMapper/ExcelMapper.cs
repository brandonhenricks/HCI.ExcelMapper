namespace HCI.ExcelMapper
{
	using System;
	using System.Collections.Generic;
	using HCI.ExcelMapper.Contracts;

	/// <summary>
	/// Excel mapper.
	/// </summary>
	public sealed class ExcelMapper : IExcelMapper
	{
		private readonly HashSet<IMappingTemplate> _mappingTemplates;
		private readonly Queue<string> _files;

		public ExcelMapper()
		{
			_mappingTemplates = new HashSet<IMappingTemplate>();
			_files = new Queue<string>();
		}

		public IExcelMapper AddFile(string filePath)
		{
			if (string.IsNullOrEmpty(filePath))
			{
				throw new ArgumentNullException();
			}

			if (_files.Contains(filePath))
			{
				_files.Enqueue(filePath);
			}

			return this;
		}

		public IExcelMapper AddTemplate(IMappingTemplate template)
		{
			if (template is null)
			{
				throw new ArgumentNullException(nameof(template));
			}

			if (!_mappingTemplates.Contains(template))
			{
				_mappingTemplates.Add(template);
			}

			return this;
		}

		public IList<T> Map<T>()
		{
			throw new NotImplementedException();
		}
	}
}
