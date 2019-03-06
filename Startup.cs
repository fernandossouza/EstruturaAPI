using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstruturaAPI.Models.Repository;
using EstruturaAPI.Service;
using EstruturaAPI.Service.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace EstruturaAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors (o => o.AddPolicy ("CorsPolicy", builder => {
                builder.AllowAnyOrigin ()
                    .AllowAnyMethod ()
                    .AllowAnyHeader ();
            }));
            services.AddMvc();
            // Services
            services.AddTransient<ILocalizacaoService,LocalizacaoService>();
            services.AddTransient<IEstruturaService,EstruturaService>();
            services.AddTransient<IMovimentacaoService,MovimentacaoService>();
            services.AddTransient<IEstruturaHistService,EstruturaHistService>();

            //Repository
            services.AddTransient<TbLocalizacaoContainerRepository,TbLocalizacaoContainerRepository>();
            services.AddTransient<TbEstruturaContainerRepository,TbEstruturaContainerRepository>();
            services.AddTransient<TbEstruturaBandejaRepository,TbEstruturaBandejaRepository>();
            services.AddTransient<TbMovimentacaoCadastroRepository,TbMovimentacaoCadastroRepository>();
            services.AddTransient<VwEstruturaBandejaHistRepository,VwEstruturaBandejaHistRepository>();
            services.AddTransient<VwEstruturaContainerHistRepository,VwEstruturaContainerHistRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors ("CorsPolicy");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
