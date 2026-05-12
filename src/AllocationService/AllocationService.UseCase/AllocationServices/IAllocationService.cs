using AllocationService.UseCase.Contracts;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationService.UseCase.AllocationServices
{
	public interface IAllocationService
	{
		public Task<Result> AllocateAsync(AllocationContract contract);
	}
}
