using AutoMapper;
using OnionHR.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using OnionHR.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using OnionHR.Domain;

namespace OnionHR.Application.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailsDto>();
        }
    }
}
