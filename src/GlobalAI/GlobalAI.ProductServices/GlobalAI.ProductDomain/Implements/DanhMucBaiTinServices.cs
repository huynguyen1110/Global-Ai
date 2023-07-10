using AutoMapper;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.Entites;
using GlobalAI.ProductDomain.Interfaces;
using GlobalAI.ProductEntities.DataEntities;
using GlobalAI.ProductEntities.Dto.BaiTin;
using GlobalAI.Utils.ConstantVariables.Product;
using GlobalAI.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalAI.ProductRepositories;
using GlobalAI.ProductEntities.Dto.DanhMucBaiTin;
using GlobalAI.ProductEntities.Dto.Voucher;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using GlobalAI.ProductEntities.Dto.GioHang;

namespace GlobalAI.ProductDomain.Implements
{
    public class DanhMucBaiTinServices : IDanhMucBaiTinServices
    {

        private readonly GlobalAIDbContext _dbContext;
        private readonly ILogger<DanhMucBaiTinServices> _logger;
        private readonly string _connectionString;
        private readonly IHttpContextAccessor _httpContext;
        private readonly DanhMucBaiTinRepository _danhMucBaiTinRepository;
        private readonly IMapper _mapper;
        public DanhMucBaiTinServices(GlobalAIDbContext dbContext,
                IHttpContextAccessor httpContext,
                DatabaseOptions databaseOptions,
                ILogger<DanhMucBaiTinServices> logger, IMapper mapper)
        {
            _mapper = mapper;
            _danhMucBaiTinRepository = new DanhMucBaiTinRepository(dbContext, logger, mapper);
            _connectionString = databaseOptions.ConnectionString;
            _logger = logger;
            _dbContext = dbContext;
            _httpContext = httpContext;

        }

        /// <summary>
        /// thêm bản ghi 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public DanhMucBaiTin Add(CreateDanhMucBaiTin input)
        {
            var userType = CommonUtils.GetCurrentRole(_httpContext);
            var userId = CommonUtils.GetCurrentUserId(_httpContext);
            var username = CommonUtils.GetCurrentUsername(_httpContext);
            if(input.ParentId == 0 )
            {
                input.ParentId = null;
            }
            var inputInsert = _mapper.Map<DanhMucBaiTin>(input);

            inputInsert.CreatedBy = username;

            inputInsert.Status = TrangThaiDanhMucBaiTin.KHOI_TAO;

            inputInsert = _danhMucBaiTinRepository.Add(inputInsert);
            _dbContext.SaveChanges();
            return inputInsert;
        }


        /// <summary>
        /// xoa danh muc bai tin
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var username = CommonUtils.GetCurrentUsername(_httpContext);
            _danhMucBaiTinRepository.DeleteById(id, username);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Danh sach dang to list
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public PagingResult<DanhMucBaiTinDto> FindAll(FilterDanhMucBaiTinDto input)
        {
            //int? userId = CommonUtils.GetCurrentUserId(_httpContext);
            //var usertype = CommonUtils.GetCurrentRole(_httpContext);

            var result = new PagingResult<DanhMucBaiTinDto>();
            var baiTinQuery = _danhMucBaiTinRepository.FindAll(input);

            result.Items = _mapper.Map<List<DanhMucBaiTinDto>>(baiTinQuery.Items);
            result.TotalItems = baiTinQuery.TotalItems;

            return result;
        }

        public List<TreesDanhMucBaiTinDto> FindAllTrees(FilterDanhMucBaiTinDto input)
        {
            //lay ra danh sach bai tin
            var danhMucBaiTins = _dbContext.DanhMucBaiTins.Where(g => !g.Deleted).ToList();

            var danhMucBaiTinMap = _mapper.Map<List<TreesDanhMucBaiTinDto>>(danhMucBaiTins);

            //tim tat ca cac nut cha
            var filteredDanhMucBaiTinMap = danhMucBaiTinMap.Where(d => d.ParentId == null).ToList();

            if(!input.IsParent)
            {
                //xu ly cac nut cha
                foreach (var node in filteredDanhMucBaiTinMap)
                {
                    node.Children = BuildTree(danhMucBaiTinMap, node.Id, input.ParentId);
                }
            }
         

            return filteredDanhMucBaiTinMap;
        }

        /// <summary>
        /// tao cay danh muc bai tin
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public static List<TreesDanhMucBaiTinDto> BuildTree(List<TreesDanhMucBaiTinDto> nodes, int? parentId = null, int? id = null)
        {
            return nodes
                .Where(node => node.ParentId == parentId)
                .Select(node => new TreesDanhMucBaiTinDto
                {
                    Id = node.Id,
                    TenDanhMuc = node.TenDanhMuc,
                    MaDanhMuc = node.MaDanhMuc,
                    CreatedDate = node.CreatedDate,
                    CreatedBy = node.CreatedBy,
                    ParentId = node.ParentId,
                    Status = node.Status,
                    Children = BuildTree(nodes, node.Id)
                })
                .ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DanhMucBaiTinDto GetById(int id)
        {
            //int? userId = CommonUtils.GetCurrentUserId(_httpContext);
            var baiTin = _danhMucBaiTinRepository.FindById(id);
            var result = _mapper.Map<DanhMucBaiTinDto>(baiTin);
            return result;
        }

        public void Update(UpdateDanhMucBaiTinDto input)
        {
            var userType = CommonUtils.GetCurrentRole(_httpContext);
            var userId = CommonUtils.GetCurrentUserId(_httpContext);
            var username = CommonUtils.GetCurrentUsername(_httpContext);
            var inputUpdate = _mapper.Map<DanhMucBaiTin>(input);
            inputUpdate.ModifiedBy = username;
            _danhMucBaiTinRepository.Update(inputUpdate);
            _dbContext.SaveChanges();
        }
    }
}
