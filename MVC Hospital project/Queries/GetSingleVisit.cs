using AutoMapper;
using Hospital.DbContextAndBuilders.ApiDbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MVC_Hospital_project.Core;
using MVC_Hospital_project.Entities;

namespace MVC_Hospital_project.Queries
{
    public class GetSingleVisit
    {
        public class Query : IRequest<Result<Visit>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Visit>>
        {
            private readonly HospitalDbContext _context;
            public Handler(HospitalDbContext context)
            {
                _context = context;
            }

            public async Task<Result<Visit>> Handle(Query request, CancellationToken cancellationToken)
            {
                var response = await _context.Visits
                .Include(v => v.Doctor)
                .Include(v => v.Patient)
                .FirstOrDefaultAsync(m => m.Id == request.Id);
                if (response != null)
                {

                    return Result<Visit>.Success(response);

                }
                return Result<Visit>.Failure("error");

            }
        }
    }
}
