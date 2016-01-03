namespace Capitalism.Models.Interfaces
{
    public interface IEmployee
    {
        string FirstName { get; }

        string LastName { get; }

        IOrganizationalUnit InUnit { get; }

        decimal SalaryFactor { get; }
    }
}
