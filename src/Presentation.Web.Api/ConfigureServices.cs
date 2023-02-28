using NoteTakingAppSolution.Application.Common.Interfaces;
using NoteTakingAppSolution.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Presentation.Web.Api.Services;

namespace Presentation.Web.Api;

public static class ConfigureServices
{
    public static IServiceCollection AddPresentationWebApiServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        return services;
    }
}
