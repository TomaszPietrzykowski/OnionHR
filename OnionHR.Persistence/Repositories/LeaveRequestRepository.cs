using Microsoft.EntityFrameworkCore;
using OnionHR.Application.Contracts.Persistance;
using OnionHR.Domain;
using OnionHR.Persistence.DatabaseContext;

namespace OnionHR.Persistence.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    public LeaveRequestRepository(HrDbContext context) : base(context)
    {

    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
    {
        var leaveRequests = await _context.LeaveRequests
            .Include(q => q.LeaveType) // <-- inner join
            .ToListAsync();

        return leaveRequests;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId)
    {
        var leaveRequests = await _context.LeaveRequests
            .Where(q => q.RequestingEmployeeId == userId)
            .Include(q => q.LeaveType)
            .ToListAsync();

        return leaveRequests;
    }

    public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
    {
        var leaveRequest = await _context.LeaveRequests
            .Include(q => q.LeaveType)
            .FirstOrDefaultAsync(q => q.Id == id); // <-- cannot use Find/FindAsync with .Include

        return leaveRequest;
    }
}
