using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationService.UseCase.TerminalResolvers
{
	public sealed class TerminalResolver : ITerminalResolver
	{
		public Task<ResultT<bool>> ValidateAsync(Guid terminalId)
		{
			throw new NotImplementedException();
		}
	}
}
