using AutoMapper;
using Hospital.DbContextAndBuilders.ApiDbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MVC_Hospital_project.Core;
using MVC_Hospital_project.Entities;
using MVC_Hospital_project.Models;

namespace MVC_Hospital_project.Queries
{
    public class GetVisits
    {
        public class Query : IRequest<Result<List<Visit>>>
        {

        }

        public class Handler : IRequestHandler<Query, Result<List<Visit>>>
        {
            private readonly HospitalDbContext _context;
            
            public Handler(HospitalDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Visit>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var response = await _context.Visits
                    .Include(r => r.Doctor)
                    .Include(r => r.Patient)
                    .ToListAsync(cancellationToken: cancellationToken);
                if (response != null)
                {

                    return Result<List<Visit>>.Success(response);

                }
                return Result<List<Visit>>.Failure("error");

            }
        }
    }
}

