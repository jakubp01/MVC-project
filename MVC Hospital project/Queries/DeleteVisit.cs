using AutoMapper;
using Hospital.DbContextAndBuilders.ApiDbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MVC_Hospital_project.Core;
using MVC_Hospital_project.Entities;

namespace MVC_Hospital_project.Queries
{
    public class DeleteVisit
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
                var response = await _context.Visits.FindAsync(request.Id);
                
                if (response != null)
                {
                    _context.Visits.Remove(response);
                    await _context.SaveChangesAsync();
                    return Result<Visit>.Success(response);

                }
                return Result<Visit>.Failure("error");

            }
        }
    }
}
