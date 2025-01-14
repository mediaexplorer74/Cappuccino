﻿using System.Threading.Tasks;
using Cappuccino.Core.Network.Config;
using Cappuccino.Core.Network.Models;
using Cappuccino.Core.Network.Handlers;
using System.Text.Json;
using System.Threading;

namespace Cappuccino.Core.Network 
{
    public abstract class ApiRequest<TResult> 
    {
        public async Task<TResult> ExecuteAsync(CancellationToken cancellationToken) 
        {
            if (!CredentialsManager.IsInternalTokenValid())
                throw new ApiException("Access token incorrect");

            return await OnExecuteAsync(cancellationToken);
        }

        protected abstract Task<TResult> OnExecuteAsync(CancellationToken cancellationToken);

        /* Dirty response, may contain error from server */
        protected internal TResult OnServerResponseReceived(string response) 
        {
            ErrorResponse error = JsonSerializer.Deserialize<ErrorResponse>(response)!;

            if (error.InnerError == null)
                return OnResponseSuccess(response);

            TokenExpiredHandler.ValidateError(error);
            throw new ApiException(error.InnerError);
        }

        /* Handled response, deserialize and pass */
        protected virtual TResult OnResponseSuccess(string response) 
        {
            return JsonSerializer.Deserialize<TResult>(response)!;
        }
    }
}