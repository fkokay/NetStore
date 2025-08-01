using MediatR;

namespace NetStore.Application.Commands.Products;

public record CreateProductCommand(string Name,string Sku, decimal Price) : IRequest<int>;
