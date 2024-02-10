using AutoMapper;
using Customer.Core.Enums;
using Customer.Core.Interfaces.Common;
using Customer.Core.Interfaces.IAppServices;
using Customer.DTOs.AppDTOs.Customer;
using Customer.DTOs.Common;
using Customer.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Customer.Application.AppServices
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer.Core.DomainModels.Customer, Guid> _custRepository;

        private readonly IMapper _mapper;

        public CustomerService(IRepository<Customer.Core.DomainModels.Customer, Guid> custRepository, IMapper mapper)
        {
            _mapper = mapper;
            _custRepository = custRepository;
        }

        public async Task<Result<PaginatedResult>> FilterByAsync(PaginatedFiltration filtrationDTO)
        {
            var customers = _custRepository.GetWhere();

            List<CustomerListingDTO> customersListing = _mapper.Map<List<CustomerListingDTO>>(await customers.Paginate(filtrationDTO).ToListAsync());

            return new Result<PaginatedResult>()
            {
                Data = new PaginatedResult { Data = customersListing, TotalCount = customers.Count() },
                Message = "",
                Status = true,
                StatusCode = 200
            };

        }

        public async Task<Result<Core.DomainModels.Customer>> CreateAsync(CustomerCreateDTO customerDTO)
        {
            try
            {
                Core.DomainModels.Customer customer = _mapper.Map<Core.DomainModels.Customer>(customerDTO);
                customer.Id = new Guid();
                await _custRepository.CreateAsync(customer);
                await _custRepository.SaveChangesAsync();
                return new Result<Core.DomainModels.Customer>
                {
                    StatusCode = (int)ResponseStatus.Success,
                    Data = customer,
                    Message = "Added Successfully",
                    Status = true,
                };
            }
            catch (Exception ex)
            {
                return new Result<Core.DomainModels.Customer>
                {
                    StatusCode = (int)ResponseStatus.InternalError,
                    Message = "Something Went Wrong",
                    Status = false,
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<Result<bool>> DeleteAsync(Guid id)
        {
            try
            {
                await _custRepository.DeleteAsync(id);
                await _custRepository.SaveChangesAsync();

                return new Result<bool>
                {
                    StatusCode = (int)ResponseStatus.Success,
                    Message = "Deleted Successfully",
                    Status = true
                };
            }
            catch (Exception ex)
            {
                return new Result<bool>
                {
                    StatusCode = (int)ResponseStatus.InternalError,
                    Message = "Something Went Wrong",
                    Status = false,
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<Result<CustomerListingDTO>> GetByIdAsync(Guid id)
        {
            try
            {
                CustomerListingDTO customerDto = _mapper.Map<CustomerListingDTO>(await _custRepository.GetByIdAsync(id));
                return new Result<CustomerListingDTO>
                {
                    StatusCode = (int)ResponseStatus.Success,
                    Data = customerDto,
                    Message = "",
                    Status = true,
                };
            }
            catch (Exception ex)
            {
                return new Result<CustomerListingDTO>
                {
                    StatusCode = (int)ResponseStatus.InternalError,
                    Message = "Something Went Wrong",
                    Status = false,
                    ExceptionMessage = ex.Message
                };
            }
        }

        public async Task<Result<Core.DomainModels.Customer>> UpdateAsync(CustomerUpdateDTO customerDTO)
        {
            try
            {
                Core.DomainModels.Customer customer = _mapper.Map<Core.DomainModels.Customer>(customerDTO);
                _custRepository.Update(customer);
                await _custRepository.SaveChangesAsync();
                return new Result<Core.DomainModels.Customer>
                {
                    StatusCode = (int)ResponseStatus.Success,
                    Message = "Updated Successfully",
                    Status = true
                };
            }
            catch (Exception ex)
            {
                return new Result<Core.DomainModels.Customer>
                {
                    StatusCode = (int)ResponseStatus.InternalError,
                    Message = "Something Went Wrong",
                    Status = false,
                    ExceptionMessage = ex.Message
                };
            }
        }
    }
}