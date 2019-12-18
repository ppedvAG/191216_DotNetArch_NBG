namespace ppedv.TombstoneStrong.Domain.Interfaces
{
    public interface IEmployeeRepository : IUniversalRepository<Employee>
    {
        Employee GetEmployeeWithMostWorkhours();
        TimeSheet[] GetAllTimeSheetsForEmployee(Employee input);
    }
}
