using Hospital.DbContextAndBuilders.ApiDbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MVC_Hospital_project.Core;
using MVC_Hospital_project.Entities;

namespace MVC_Hospital_project.Queries
{
    public class CreateVisit
    {
        public class Query : IRequest<Result<Visit>>
        {
            public Visit visit;
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
                _context.Add(request.visit);
                int rowsAffected = await _context.SaveChangesAsync();
                if (rowsAffected > 0)
                {
                    return Result<Visit>.Success(request.visit);
                }
                else
                {
                    return Result<Visit>.Failure("No rows were affected in the database.");
                }

            }
        }
    }
}
