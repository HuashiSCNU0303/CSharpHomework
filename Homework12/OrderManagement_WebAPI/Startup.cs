using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace OrderManagement_WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<OrderContext>(options => options
                .UseMySql(Configuration.GetConnectionString("orderDatabase"),
                    mySqlOptions => mySqlOptions
                    .ServerVersion(new Version(8, 0, 19), ServerType.MySql)
            ));
            services.AddControllers(); //�������������󣬴���ʱ��������ע��
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles(); //����ȱʡ��̬�ļ���index.html��index.htm��
            app.UseStaticFiles(); //������̬�ļ���ҳ�桢js��ͼƬ�ȸ���ǰ���ļ���

            app.UseHttpsRedirection(); //����http��https���ض���
            app.UseRouting();  //��·��������ӵ�app��
            app.UseAuthorization(); //����Ȩ������ӵ�app��
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers(); //����ӳ�䣬��url·�ɵ�������
            });
        }
    }
}