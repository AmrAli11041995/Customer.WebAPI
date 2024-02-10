namespace Customer.DTOs.AppDTOs.Customer
{
    public class CustomerUpdateDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
    }
}
