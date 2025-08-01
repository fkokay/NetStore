using MediatR;
using NetStore.Application.Interfaces.Repositories;
using NetStore.Domain.Entities;

namespace NetStore.Application.Commands.Products;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product()
        {
            Name = request.Name,
            Sku = request.Sku,
            Price = request.Price,
        };

        await _productRepository.AddAsync(product);

        return product.Id;
    }
}
