using ChainOfResponsibilityProject.DAL;
using ChainOfResponsibilityProject.Models;

namespace ChainOfResponsibilityProject.ChainOfResponsibility;

public class AreaDirector : Employee
{
    private readonly Context _context;

    public AreaDirector(Context context)
    {
        _context = context;
    }

    public override void ProcessRequest(CustomerProcessViewModel model)
    {
        if (model.Account <= 30000)
        {
            CustomerProcess customer = new CustomerProcess();
            customer.Account = model.Account;
            customer.Name = model.Name;
            customer.EmployeeName = "Ahmet";
            customer.Description = "İstenilen tutar müşretiye bölge müdürü tarafından ödendi.";
        }
        else
        {
            CustomerProcess customerProcess = new CustomerProcess();
            customerProcess.Account = model.Account;
            customerProcess.Name = model.Name;
            customerProcess.EmployeeName = "Ahmet";
            customerProcess.Description = "Ödeme bölge müdürü tarafından yapılamadı, müşteriye bilgi verildi";
            _context.CustomerProcesses.Add(customerProcess);
            _context.SaveChanges();
            NextApprover.ProcessRequest(model);
        }
    }
}
