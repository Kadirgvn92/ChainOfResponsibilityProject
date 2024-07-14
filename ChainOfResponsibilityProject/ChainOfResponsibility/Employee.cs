using ChainOfResponsibilityProject.Models;

namespace ChainOfResponsibilityProject.ChainOfResponsibility;

public abstract class Employee
{
    protected Employee NextApprover;

    public void SetNextApprover(Employee superVisior)
    {
        this.NextApprover = superVisior;
    }
    public abstract void ProcessRequest(CustomerProcessViewModel model);
}
