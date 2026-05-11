using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalService.Facade
{
	public interface ICheckIfExistQuery
	{
		public Task<Result> Handle(Guid id);
	}
}
