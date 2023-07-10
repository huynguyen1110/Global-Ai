using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.CoreDomain.Interfaces
{
    public interface IPermissionServices
    {
        /// <summary>
        /// Lấy toàn bộ permissions
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllPermissions();

        /// <summary>
        /// Lấy list permission theo userid hiện tại
        /// </summary>
        /// <returns></returns>
        public List<string> FindPermissionsByCurrentUser();
    }
}
