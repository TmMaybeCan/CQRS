using CQRSTestApp.Context;
using CQRSTestApp.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Threading;
using System.Threading.Tasks;

namespace CQRSTestApp.Features.ProductFeatures.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal BuyingPrice { get; set; }
        public decimal Rate{ get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
        {
            private readonly IApplicationContext _context;
            public CreateProductCommandHandler(IApplicationContext context) => _context = context;

            public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                var product = new Product();

                product.Barcode = command.Barcode;
                product.Name = command.Name;
                product.BuyingPrice = command.BuyingPrice;
                product.Rate = command.Rate;
                product.Description = command.Description;

                _context.Products.Add(product);//CREATE
                await _context.SaveChanges();
                return product.Id;
            }
        }
    }
}
