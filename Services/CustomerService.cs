using AutoMapper;
using DAL.Repositories.Interfaces;
using Domain.Entities;
using Models.DTOs.Output;
using Services.Interfaces;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(IGenericRepository<Customer> customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomerSocialNetworksDTO>> GetCustomersWithSocialNetworksAsync(CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<CustomerSocialNetworksDTO>>(customers);
        }

        public async Task<double?> GetWorkingHoursByCustomerId(int id, CancellationToken cancellationToken)
        {
            var customer = (await _customerRepository.GetAllByConditionAsync(c => c.Id == id, cancellationToken)).FirstOrDefault();
            var customerEmployeeProjects = customer?.Projects.SelectMany(project => project.EmployeeProjects);
            var customerTimeLogs = customerEmployeeProjects?.SelectMany(ep => ep.TimeLogs);
            return customerTimeLogs?.Sum(timeLog => timeLog.Duration);
        }
    }
}