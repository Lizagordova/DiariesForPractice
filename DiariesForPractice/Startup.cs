using DiariesForPractice.Domain.Repositories;
using DiariesForPractice.Domain.Services.Diaries;
using DiariesForPractice.Domain.Services.InstituteDetails;
using DiariesForPractice.Domain.Services.Notifications;
using DiariesForPractice.Domain.Services.Organizations;
using DiariesForPractice.Domain.Services.PracticeDetail;
using DiariesForPractice.Domain.Services.StudentTasks;
using DiariesForPractice.Domain.Services.Users;
using DiariesForPractice.Domain.StudentCharacteristics;
using DiariesForPractice.Persistence.Repositories;
using DiariesForPractice.Persistence.Services.Diaries;
using DiariesForPractice.Persistence.Services.InstituteDetail;
using DiariesForPractice.Persistence.Services.MapperService;
using DiariesForPractice.Persistence.Services.Notifications;
using DiariesForPractice.Persistence.Services.Organizations;
using DiariesForPractice.Persistence.Services.PracticeDetail;
using DiariesForPractice.Persistence.Services.StudentCharacteristics;
using DiariesForPractice.Persistence.Services.StudentTasks;
using DiariesForPractice.Persistence.Services.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MainMapperService = DiariesForPractice.Services.Mapper.MapperService;

namespace DiariesForPractice
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
			services.AddControllersWithViews();
			AddRepositories(services);
			AddServices(services);
			// In production, the React files will be served from this directory
			services.AddSpaStaticFiles(configuration => { configuration.RootPath = "client/build"; });
		}

		// Thi
		// s method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseSpaStaticFiles();

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller}/{action=Index}/{id?}");
			});

			app.UseSpa(spa =>
			{
				spa.Options.SourcePath = "client";

				if (env.IsDevelopment())
				{
					spa.UseReactDevelopmentServer(npmScript: "start");
				}
			});
		}

		private void AddRepositories(IServiceCollection services)
		{
			services.AddSingleton<IDiariesRepository, DiariesRepository>();
			services.AddSingleton<IInstituteDetailsRepository, InstituteDetailsRepository>();
			services.AddSingleton<IInstituteDetailsRepository, InstituteDetailsRepository>();
			services.AddSingleton<INotificationRepository, NotificationRepository>();
			services.AddSingleton<IPracticeRepository, PracticeRepository>();
			services.AddSingleton<IStudentCharacteristicRepository, StudentCharacteristicRepository>();
			services.AddSingleton<IStudentTaskRepository, StudentTaskRepository>();
			services.AddSingleton<IOrganizationRepository, OrganizationRepository>();
			services.AddSingleton<IUserRepository, UserRepository>();
		}

		private void AddServices(IServiceCollection services)
		{
			//services.AddHostedService<LoaderWorker>();
			services.AddSingleton<IInstituteDetailsEditorService, InstituteDetailsEditorService>();
			services.AddSingleton<IInstituteDetailsReaderService, InstituteDetailsReaderService>();
			services.AddSingleton<INotificationEditorService, NotificationEditorService>();
			services.AddSingleton<INotificationReaderService, NotificationReaderService>();
			services.AddSingleton<IDiariesEditorService, DiariesEditorService>();
			services.AddSingleton<IDiariesReaderService, DiariesReaderService>();
			services.AddSingleton<IOrganizationEditorService, OrganizationEditorService>();
			services.AddSingleton<IOrganizationReaderService, OrganizationReaderService>();
			services.AddSingleton<IPracticeEditorService, PracticeEditorService>();
			services.AddSingleton<IPracticeReaderService, PracticeReaderService>();
			services.AddSingleton<IStudentCharacteristicsEditor, StudentCharacteristicsEditor>();
			services.AddSingleton<IStudentCharacteristicsReader, StudentCharacteristicsReader>();
			services.AddSingleton<IStudentTaskEditorService, StudentTaskEditorService>();
			services.AddSingleton<IStudentTaskReaderService, StudentTaskReaderService>();
			services.AddSingleton<IUserEditorService, UserEditorService>();
			services.AddSingleton<IUserReaderService, UserReaderService>();
			services.AddSingleton<MainMapperService>();
			services.AddSingleton<MapperService>();
		}
	}
}