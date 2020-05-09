
using System.Collections.Generic;
using WS_Core.Domain.Dtos;
using WS_Core.Domain.Models;

namespace WS_Core.Service.Dxos
{
    public interface IProductDxos
    {
        ProductDto MapProductDto(Product product);

        List<ProductDto> MapProductsDto(List<Product> products);

        Product MapProduct(ProductDto productDto);

        Manufacturer MapManufacturer(ManufacturerDto manufacturerDto);

    }
}
