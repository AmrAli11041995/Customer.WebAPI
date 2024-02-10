using Customer.DTOs.AppDTOs.Customer;
using Customer.DTOs.Common;

namespace Customer.Core.Interfaces.IAppServices
{
    public interface ICustomerService
    {
        Task<Result<PaginatedResult>> FilterByAsync(PaginatedFiltration filtrationDTO);
        Task<Result<CustomerListingDTO>> GetByIdAsync(Guid id);
        Task<Result<Customer.Core.DomainModels.Customer>> CreateAsync(CustomerCreateDTO customerDTO);
        Task<Result<Customer.Core.DomainModels.Customer>> UpdateAsync(CustomerUpdateDTO customerDTO);
        Task<Result<bool>> DeleteAsync(Guid id);
    }
}
