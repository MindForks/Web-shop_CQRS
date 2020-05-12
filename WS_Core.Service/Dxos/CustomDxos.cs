using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using WS_Core.Data.Database;
using WS_Core.Data.Interfaces;
using WS_Core.Domain.Dtos;
using WS_Core.Domain.Models;

namespace WS_Core.Service.Dxos
{
    public class CustomDxos : ICustomDxos
    {
        private readonly IDatabase<Product> _productDatabase;
        private readonly IMapper _mapper;


        public CustomDxos(IDatabase<Product> productDatabase)
        {
              _productDatabase = productDatabase ?? throw new ArgumentNullException(nameof(productDatabase));

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Manufacturer, ManufacturerDto>().ReverseMap();

                cfg.CreateMap<Product, ProductDto>();
                cfg.CreateMap<ProductDto, Product>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => new ObjectId(src.Id)));

                cfg.CreateMap<Order, OrderDto>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dst => dst.UserName, opt => opt.MapFrom(src => src.UserName))
                    .ForMember(dst => dst.ProductIDs, opt => opt.MapFrom(src => src.ProductIDs.Select(y => y.Id.ToString()).ToList()))
                    .ForMember(dst => dst.ProductNames, opt => opt.Ignore());
                    //.ForMember(dst => dst.ProductNames, opt => opt.MapFrom<CustomResolver>())
                    //.ForMember(dst => dst.ProductNames, opt => opt.MapFrom(src => GetProductNames(src.ProductIDs)));
                    //.ForMember(dst => dst.ProductNames, opt => opt.MapFrom(src => src.ProductIDs.Select(y => _productDatabase.GetOne(db => db.Id == y.Id).Title)));

                cfg.CreateMap<OrderDto, Order>()
                    .ForMember(dst => dst.Id, opt => opt.MapFrom(src => new ObjectId(src.Id)))
                    .ForMember(dst => dst.UserName, opt => opt.MapFrom(src => src.UserName))
                    .ForMember(dst => dst.ProductIDs, opt => opt.MapFrom(src => src.ProductIDs.Select(y => new MongoDBRef(ProductRepository.collectionName, y))));


            });
            config.AssertConfigurationIsValid();

            _mapper = config.CreateMapper();
        }
        public List<string> GetProductNames(List<MongoDBRef> obj)
        {
            if (obj == null)
                return null;

            List<string> productNames = new List<string>();
            for (int i = 0; i < obj.Count(); i++)
            {
                var id = obj[i].Id;
                var item = _productDatabase.GetOne(db => db.Id == id).Title;
                productNames.Add(item);
            }
            return productNames;
        }

        public Manufacturer MapManufacturer(ManufacturerDto manufacturerDto)
        {
            return _mapper.Map<ManufacturerDto, Manufacturer>(manufacturerDto);
        }

        public ProductDto MapProductDto(Product product)
        {
            return _mapper.Map<Product, ProductDto>(product);
        }

        public List<ProductDto> MapProductsDto(List<Product> products)
        {
            return _mapper.Map<List<Product>, List<ProductDto>>(products);
        }

        public OrderDto MapOrderDto(Order order)
        {
            return _mapper.Map<Order, OrderDto>(order);
        }

        public List<OrderDto> MapOrdersDto(List<Order> orders)
        {
            return _mapper.Map<List<Order>, List<OrderDto>>(orders);
        }
    }
    public class CustomResolver : IValueResolver<Order, OrderDto, List<string>>
    {
        public List<string> Resolve(Order source, OrderDto destination, List<string> destMember, ResolutionContext context)
        {
            var res = source.ProductIDs.Select(x => new ProductRepository().GetOne(db => db.Id == x.Id).Title).ToList();
            return res;
         //   return new List<string> { "test" };
        }
    }

}
