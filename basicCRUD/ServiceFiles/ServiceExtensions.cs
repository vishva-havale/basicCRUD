using BAL;
using DAL;

namespace basicCRUD.ServiceFiles
{
    public static class ServiceExtensions
    {
        public static void RegisterEmplo(this IServiceCollection collection, ConfigurationManager configuration) {
            //retrieves connection string from application configuration
            var connectionString = configuration["ConnectionStrings:cntx"];
            
            //Register Repos
  
           collection.AddTransient<IEmployeeService, EmployeeService>();  //register interface and create new instance of class every time
           collection.AddTransient<IEmployeeRepo>(s => new EmployeeRepo(connectionString)); //passing connection string start from here

           collection.AddTransient<IEmployeeAddressService, EmployeeAddressService>();
           collection.AddTransient<IEmployeeAddressRepo>(s => new EmployeeAddressRepo(connectionString));

           collection.AddTransient<IContactInfoService, ContactInfoService>();
           collection.AddTransient<IContactInfoRepo>( s => new ContactInfoRepo(connectionString));

            collection.AddTransient<IUserService, UserService>();
            collection.AddTransient<IUserRepo>( s => new UserRepo(connectionString));
        }
    }
}
