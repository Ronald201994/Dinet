﻿using MediatR;

namespace Dinet.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand: IRequest<int>
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
    }
}
