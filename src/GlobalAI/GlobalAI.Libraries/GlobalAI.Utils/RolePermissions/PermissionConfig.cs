using GlobalAI.Utils.RolePermissions.Constant;
using System.Collections.Generic;

namespace GlobalAI.Utils.RolePermissions
{
    /// <summary>
    /// Cấu hình các permission trong hệ thống
    /// </summary>
    public static class PermissionConfig
    {
        public static readonly Dictionary<string, PermissionContent> Configs = new()
        {
            #region product
            {
                Permissions.ProductAdminDashboard, new PermissionContent(){ Description = "Trang admin dashboard" }
            },
            {
                Permissions.ProductAdminProduct, new PermissionContent(){ Description = "Trang admin product" }
            },
            {
                Permissions.ProductAdminProductAdd, new PermissionContent(){ Description = "Trang admin product add" }
            },
            {
                Permissions.ProductAdminProductEdit, new PermissionContent(){ Description = "Trang admin product edit" }
            },
            {
                Permissions.ProductAdminOrder, new PermissionContent(){ Description = "Trang admin đơn hàng" }
            },
            {
                Permissions.ProductAdminOrderAdd, new PermissionContent(){ Description = "Trang admin đơn hàng add" }
            },
            {
                Permissions.ProductAdminOrderEdit, new PermissionContent(){ Description = "Trang admin đơn hàng edit" }
            },
            {
                Permissions.ProductAdminOrderDetails, new PermissionContent(){ Description = "Trang admin đơn hàng detail" }
            },
            {
                Permissions.ProductGsalerHome, new PermissionContent(){ Description = "Trang chủ gsaler" }
            },
            {
                Permissions.ProductGsalerAdvisement, new PermissionContent(){ Description = "Trang saler advisement" }
            },
            {
                Permissions.ProductGsalerProfile, new PermissionContent(){ Description = "Trang saler profile" }
            },
            {
                Permissions.ProductGsalerSliderNcc, new PermissionContent(){ Description = "Trang slider ncc" }
            },
            {
                Permissions.ProductProfile, new PermissionContent(){ Description = "Trang profile" }
            },
            #endregion

        };
    }
}
