
using System.Collections.Generic;
using WS_Core.Domain.Dtos;
using WS_Core.Domain.Models;

namespace WS_Core.Service.Dxos
{
    public interface ICustomDxos
    {
        Manufacturer MapManufacturer(ManufacturerDto manufacturerDto);

        ProductDto MapProductDto(Product product);

        List<ProductDto> MapProductsDto(List<Product> products);

        OrderDto MapOrderDto(Order order);

        List<OrderDto> MapOrdersDto(List<Order> orders);
    }
}
