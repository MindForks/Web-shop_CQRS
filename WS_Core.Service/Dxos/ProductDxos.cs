using AutoMapper;
using WS_Core.Domain.Dtos;
using WS_Core.Domain.Models;

namespace WS_Core.Service.Dxos
{
    public class ProductDxos : IProductDxos
    {
        private readonly IMapper _mapper;

        public ProductDxos()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Domain.Models.Manufacturer, Domain.Dtos.ManufacturerDto>().ReverseMap();
                cfg.CreateMap<Domain.Models.Product, Domain.Dtos.ProductDto>().ReverseMap();

                //cfg.CreateMap<Domain.Models.Product, Domain.Dtos.ProductDto>()
                //    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                //    .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title))
                //    .ForMember(dst => dst.Price, opt => opt.MapFrom(src => src.Price))
                //    .ForMember(dst => dst.CountInStock, opt => opt.MapFrom(src => src.CountInStock)) // opt.MapFrom(src => src.Manufacturer)
                //    .ForMember(dst => dst.Manufacturer, opt => opt.MapFrom(src => src.Manufacturer));
            });

            _mapper = config.CreateMapper();
        }

        public ProductDto MapProductDto(Product product)
        {
            return _mapper.Map<Product, Domain.Dtos.ProductDto>(product);
        }
        public Manufacturer MapManufacturer(ManufacturerDto manufacturerDto)
        {
            return _mapper.Map<ManufacturerDto, Manufacturer>(manufacturerDto);
        }

        public Product MapProduct(ProductDto productDto)
        {
            return _mapper.Map<ProductDto,Product>(productDto);
        }
    }
}
