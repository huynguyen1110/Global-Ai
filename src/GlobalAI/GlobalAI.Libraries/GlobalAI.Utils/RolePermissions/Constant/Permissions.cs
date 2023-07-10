using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.Utils.RolePermissions.Constant
{
    public static class Permissions
    {
        //các loại permission
        private const string Menu = "menu_";
        private const string Tab = "tab_";
        private const string Page = "page_";
        private const string Table = "table_";
        private const string Form = "form_";
        private const string ButtonAction = "btn_action_";

        #region product
        private const string ProductModule = "product.";

        public const string ProductAdminDashboard = ProductModule + Page + "admin_dashboard";
        public const string ProductAdminProduct = ProductModule + Page + "admin_product";
        public const string ProductAdminProductAdd = ProductModule + Page + "admin_product_add";
        public const string ProductAdminProductEdit = ProductModule + Page + "admin_product_edit";
        public const string ProductAdminOrder = ProductModule + Page + "admin_order";
        public const string ProductAdminOrderAdd = ProductModule + Page + "admin_order_add";
        public const string ProductAdminOrderEdit = ProductModule + Page + "admin_order_edit";
        public const string ProductAdminOrderDetails = ProductModule + Page + "admin_order_details";
        public const string ProductGsalerHome = ProductModule + Page + "gsaler_home";
        public const string ProductGsalerAdvisement = ProductModule + Page + "gsaler_advisement";
        public const string ProductGsalerProfile = ProductModule + Page + "gsaler_profile";
        public const string ProductGsalerSliderNcc = ProductModule + Page + "gsaler_sliderncc";
        public const string ProductManageCart = ProductModule + Page + "manage_cart";
        public const string ProductProfile = ProductModule + Page + "profile";
        #endregion

        #region product
        private const string CoreModule = "core.";
        public const string CoreAdminUser = ProductModule + Page + "user";
        #endregion
    }
}
