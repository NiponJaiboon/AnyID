using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iSabaya;

namespace AnyIDModel
{
    public interface ICustomerRepository
    {
        IList<Customer> GetCustomerProfiles(out int count, Context context, string firstName, string lastName, int pageNo = 1);
        IList<Customer> GetCustomerProfiles(out int count, Context context, string idNo, IDType idType, int pageNo = 1);
        IList<Customer> GetCustomerProfiles(out int count, Context context, string idNo, IDType idType, string firstName, string lastName, int pageNo = 1);
        IList<Customer> GetCustomerProfilesNoAddress(out int count, Context context, string idNo, IDType idType, string firstName, string lastName, int pageNo = 1);
        IList<BankAccount> GetCustomerAccounts(Context context, string idNo, IDType idType);
        Customer GetCustomerProfile(Context context, string cisID);
    }
}
