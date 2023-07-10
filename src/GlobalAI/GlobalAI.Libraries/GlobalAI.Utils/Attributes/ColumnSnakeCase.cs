﻿using GlobalAI.Utils.DataUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalAI.Utils.Attributes
{
    public class ColumnSnackCaseAttribute : System.ComponentModel.DataAnnotations.Schema.ColumnAttribute
    {
        public ColumnSnackCaseAttribute(string name) : base(name.ToSnakeUpperCase())
        {
        }
    }
}
