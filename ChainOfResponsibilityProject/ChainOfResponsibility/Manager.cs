using ChainOfResponsibilityProject.DAL;
using ChainOfResponsibilityProject.Models;

namespace ChainOfResponsibilityProject.ChainOfResponsibility;

public class Manager : Employee
{
    private readonly Context _context;

    public Manager(Context context)
    {
        _context = context;
    }

    public override void ProcessRequest(CustomerProcessViewModel model)
    {
        if (model.Account <= 25000)
        {
            CustomerProcess customer = new CustomerProcess();
            customer.Account = model.Account;
            customer.Name = model.Name;
            customer.EmployeeName = "Ahmet";
            customer.Description = "İstenilen tutar müşretiye şube müdür tarafından ödendi.";
        }
        else if (NextApprover != null)
        {
            CustomerProcess customerProcess = new CustomerProcess();
            customerProcess.Account = model.Account;
            customerProcess.Name = model.Name;
            customerProcess.EmployeeName = "Ahmet";
            customerProcess.Description = "Ödeme şube müdür tarafından yapılamadı ve işlem bölge müdürüne gönderildi.";
            _context.CustomerProcesses.Add(customerProcess);
            _context.SaveChanges();
            NextApprover.ProcessRequest(model);
        }
    }
}
