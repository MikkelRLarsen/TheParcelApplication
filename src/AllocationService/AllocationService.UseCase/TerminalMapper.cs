using AllocationService.Domain;
using AllocationService.UseCase.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace AllocationService.UseCase
{
	public static class TerminalMapper
	{
		public static Terminal ToDomain(this TerminalCacheState state)
			=> new Terminal(
				id: state.Id, 
				capacity: state.Capacity);

		public static TerminalCacheState ToCache(this Terminal terminal)
			=> new TerminalCacheState(
				id: terminal.Id,
				capacity: terminal.Capacity);

		public static Terminal ToDomain(this TerminalServiceState state)
			=> new Terminal(
				id: state.Id,
				capacity: state.Capacity);

		public static TerminalCacheState ToCache(this TerminalServiceState terminal)
			=> new TerminalCacheState(
				id: terminal.Id,
				capacity: terminal.Capacity);
	}
}
