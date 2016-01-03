using System.Collections.Generic;
namespace Capitalism.Models.Interfaces
{
    public interface IOrganizationalUnit
    {
        List<IOrganizationalUnit> SubUnits { get; }

    }
}
