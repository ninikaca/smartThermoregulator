﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Interfejsi
{
    public interface IDatabaseConnection
    {
        IDbConnection GetConnection();
    }
}