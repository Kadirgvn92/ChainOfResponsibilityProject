using ChainOfResponsibilityProject.DAL;
using ChainOfResponsibilityProject.Models;

namespace ChainOfResponsibilityProject.ChainOfResponsibility;

public class Treasurer : Employee
{
   Context _context = new Context();
    public override void ProcessRequest(CustomerProcessViewModel model)
    {
        if (model.Account <= 80000)
        {
            CustomerProcess customerProcess = new CustomerProcess();
            customerProcess.Account = model.Account;
            customerProcess.Name = model.Name;
            customerProcess.EmployeeName = "Batuhan";
            customerProcess.Description = "İstenen tutar müşteriye veznedar tarafından ödendi.";
            _context.CustomerProcesses.Add(customerProcess);
            _context.SaveChanges();
        }
        else if (NextApprover != null)
        {
            CustomerProcess customerProcess = new CustomerProcess();
            customerProcess.Account = model.Account;
            customerProcess.Name = model.Name;
            customerProcess.EmployeeName = "Batuhan";
            customerProcess.Description = "Odeme veznedar tarafından yapılamadı ve şube müdür yardımcıına gönderildi.";
            _context.CustomerProcesses.Add(customerProcess) ;
            _context.SaveChanges();
            NextApprover.ProcessRequest(model);
        }
    }
}
