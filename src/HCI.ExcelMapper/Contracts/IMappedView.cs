namespace HCI.ExcelMapper.Contracts
{
	using System;
	using System.Collections.Generic;

	public interface IMappedView
	{
		IList<object> Mapped { get; }
	}
}
