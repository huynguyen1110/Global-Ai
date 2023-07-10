using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.Utils.EnumType
{
    public enum EnumYesNo
    {
        [Description("YES")]
        [EnumMember(Value = "Y")]
        YES = 0,

        [Description("NO")]
        [EnumMember(Value = "N")]
        NO = 1,
    }
}
