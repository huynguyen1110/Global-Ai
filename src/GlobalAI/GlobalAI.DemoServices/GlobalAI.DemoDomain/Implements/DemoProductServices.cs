using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.DemoProduct;
using GlobalAI.DemoRepositories;
using GlobalAI.Entites;
using GlobalAI.EntitiesBase.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GlobalAI.ProductDomain.Implements
{
    public class DemoProductServices : IDemoProductServices
    {
        private readonly GlobalAIDbContext _dbContext;
        //private readonly IMapper _mapper;
        private readonly ILogger<DemoProductServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly DemoProductRepository _demoProductRepository;

        public DemoProductServices(
            GlobalAIDbContext dbContext,
            DatabaseOptions databaseOptions,
            //IMapper mapper,
            ILogger<DemoProductServices> logger,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _dbContext = dbContext;
            //_mapper = mapper;
            _logger = logger;
            _connectionString = databaseOptions.ConnectionString;
            _httpContext = httpContextAccessor;
            _demoProductRepository = new DemoProductRepository(dbContext, logger);
        }

        /// <summary>
        /// Tạo demo product
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public AddProductDto Add(AddDemoProductDto dto)
        {
            _logger.LogInformation($"{nameof(Add)}: input = {JsonSerializer.Serialize(dto)}");

            var result = _demoProductRepository.Add(new AddProductDto
            {
                Description = dto.Description,
                Manufacturer = dto.Manufacturer,
                Price = dto.Price,
                ProductName = dto.ProductName,
                ProductId = "ssaf",
            });

            _dbContext.SaveChanges();
            return result;
        }

        /// <summary>
        /// Get list demo product phân trang
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagingResult<AddProductDto> FindAll(FindDemoProductDto input)
        {
            _logger.LogInformation($"{nameof(FindAll)}: input = {JsonSerializer.Serialize(input)}");

            return _demoProductRepository.FindAll(input);
        }
    }
}
