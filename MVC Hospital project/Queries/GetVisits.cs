using AutoMapper;
using Hospital.DbContextAndBuilders.ApiDbContext;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MVC_Hospital_project.Core;
using MVC_Hospital_project.Entities;
using MVC_Hospital_project.Models;
using System.Security.Claims;

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
            private readonly IHttpContextAccessor _httpContext;
            public Handler(HospitalDbContext context, IHttpContextAccessor httpContext)
            {
                _context = context;
                _httpContext = httpContext;
            }

            public async Task<Result<List<Visit>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var userid = _httpContext.HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;
                var response = await _context.Visits
                    .Include(r => r.Doctor)
                    .Include(r => r.Patient)
                    .Where(r=>r.Doctor.IdentificationNumber== userid)
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

