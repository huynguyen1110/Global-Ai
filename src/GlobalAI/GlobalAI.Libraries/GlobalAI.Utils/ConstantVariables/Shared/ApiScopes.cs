using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.Utils.ConstantVariables.Shared
{
    /// <summary>
    /// Các api scope được dùng để config trong identity server cho từng client id có thể vào được scope nào, các api scope này được cấu hình với policy trong startup
    /// </summary>
    public static class ApiScopes
    {
        /// <summary>
        /// Các api nghiệp vụ thường
        /// </summary>
        public const string LogicBusiness = "LogicBusiness";
    }
}
