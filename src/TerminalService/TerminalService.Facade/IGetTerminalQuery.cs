using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;
using TerminalService.Facade.DataTransferObjects;

namespace TerminalService.Facade
{
	public interface IGetTerminalQuery
	{
		public Task<ResultT<Terminal>> GetTerminalAsync(Guid id);
	}
}
