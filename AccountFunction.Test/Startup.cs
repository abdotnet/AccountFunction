using AccountFunction.Core.Interfaces.Services;
using AccountFunction.Infrastructure.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.DependencyInjection;

namespace AccountFunction.Test
{
    public class Startup
    {



        protected void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IAccountService, AccountService>();
        }
    }
}
