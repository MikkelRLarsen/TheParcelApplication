using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalService.Facade
{
	public interface IAllocateRequestCommand
	{
		public Task<Result> TryHandle(AllocateRequest allocateRequest);
	}
}
