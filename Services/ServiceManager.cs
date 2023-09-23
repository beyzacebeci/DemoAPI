using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager:IServiceManager
    {
        private readonly Lazy<ICourseService> _courseService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServiceManager(IRepositoryManager repositoryManager,
            IMapper mapper,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            _courseService = new Lazy<ICourseService>(() => 
            new CourseManager(repositoryManager,mapper));

            _authenticationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationManager(mapper, userManager, configuration));
        }
        public ICourseService CourseService => _courseService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
