using Microsoft.EntityFrameworkCore;
using OnionHR.Application.Contracts.Persistance;
using OnionHR.Domain;
using OnionHR.Persistence.DatabaseContext;

namespace OnionHR.Persistence.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    public LeaveTypeRepository(HrDbContext context) : base(context)
    {

    }

    public async Task<bool> IsLeaveTypeUnique(string name)
    {
        return await _context.LeaveTypes.AnyAsync(q => q.Name == name);
    }
}

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    public LeaveRequestRepository(HrDbContext context) : base(context)
    {

    }
}

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(HrDbContext context) : base(context)
    {

    }
}