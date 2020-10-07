using CQRSTestApp.Context;
using CQRSTestApp.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSTestApp.Features.ProductFeatures.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
        {
            public IApplicationContext _context;
            public GetProductByIdQueryHandler(IApplicationContext context) => _context = context;

            public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product =  await _context.Products.Where(e => e.Id == query.Id).FirstOrDefaultAsync();//await _context.Products.Where(e => e.Id == query.Id).FirstAsync();
                if (product == null) return null;
                return product;
            }
        }
    }
}
