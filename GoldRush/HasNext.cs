﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public interface HasNext
    {
        HasNext Next
        {
            get;
            set;
        }
    }
}