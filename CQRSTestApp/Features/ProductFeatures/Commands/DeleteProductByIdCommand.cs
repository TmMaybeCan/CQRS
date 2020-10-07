using CQRSTestApp.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSTestApp.Features.ProductFeatures.Commands
{
    public class DeleteProductByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProdyuctByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
        {
            private readonly IApplicationContext _context;

            public DeleteProdyuctByIdCommandHandler(IApplicationContext context) => _context = context;

            public async Task<int> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Where(e => e.Id == command.Id).FirstOrDefaultAsync();
                if (product == null) return default;
                _context.Products.Remove(product);//DELETE
                await _context.SaveChanges();
                return product.Id;
            }
        }
    }
}
