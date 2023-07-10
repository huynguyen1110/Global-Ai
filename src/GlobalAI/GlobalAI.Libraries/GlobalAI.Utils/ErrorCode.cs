using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.Utils
{
    public enum ErrorCode
    {
        System = 101,

        NotFound = 1404,
        BadRequest = 1400,

        InternalServerError = 1500,
        /// <summary>
        /// Danh cho các lỗi về http request
        /// </summary>
        HttpRequestException = 1501,
        NotHaveClaim = 1502,
        DbUpdateException = 1503,
        GetRequestService = 1504,
        /// <summary>
        /// Request timeout sang bên thứ 3
        /// </summary>
        HttpRequestTimeOut = 1505,
        /// <summary>
        /// lỗi logic api bên thứ 3
        /// </summary>
        HttpRequestThirdPartDomainError = 1506,

        #region user
        UserUsernameDuplicated = 1001,
        UserEmailDuplicated = 1002,
        UserPhoneDuplicated = 1003,
        UserLoginNotFound = 1004,
        UserRoleNotFound = 1005,
        #endregion

        #region sp
        /// sp
        ProductDanhMucThuocTinhNotFound = 2001,
        ProductThuocTinhNotFound = 2002,
        ProductDanhMucThuocTinhInUsed = 2003,
        ProductThuocTinhInUsed = 2004,
        ProductThuocTinhGiaTriInUsed = 2005,
        ProductThuocTinhGiaTriNotFound = 2006,
        ProductDanhMucThuocTinhMaExisted = 2007,
        ProductDanhMucNotFound = 2008,
        ProductSpChiTietNotFound = 2009,
        ProductSpChiTietDaDuocTaoDonHang = 2010,
        #endregion

        #region file
        /// file
        FileExtensionNoAllow = 5001,
        FileUploadNoContent = 5002,
        FileOverUploadLimit = 5003
        #endregion
    }

}
