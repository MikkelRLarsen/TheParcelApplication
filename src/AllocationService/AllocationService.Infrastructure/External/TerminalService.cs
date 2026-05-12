using AllocationService.Infrastructure.InfrastructureErros;
using AllocationService.UseCase.Contracts;
using AllocationService.UseCase.InfrastructureInterfaces;
using Dapr.Client;
using Microsoft.Extensions.DependencyInjection;
using Shared.ResultPattern;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace AllocationService.Infrastructure.External
{
	public sealed class TerminalService : ITerminalService
	{
		private readonly HttpClient _httpClient;

		public TerminalService(DaprClient daprClient)
		{
			_httpClient = daprClient.CreateInvokableHttpClient("terminalservice");
		}

		public async Task<ResultT<TerminalServiceState>> GetAsync(Guid terminalId)
		{
			var response = await _httpClient.GetAsync($"terminal/{terminalId}");

			if (response.StatusCode == HttpStatusCode.NotFound)
				return HttpError.NotFound(terminalId);

			if (!response.IsSuccessStatusCode)
				return HttpError.RequestFailed(terminalId);

			var dto = await response.Content.ReadFromJsonAsync<TerminalServiceDto>();

			if (dto is null)
				return HttpError.JSONFormattingError(terminalId);

			return new TerminalServiceState(
				id: dto.Id, 
				capacity: dto.DailyCapacity - dto.CurrentlyReserved);
		}
	}
}
