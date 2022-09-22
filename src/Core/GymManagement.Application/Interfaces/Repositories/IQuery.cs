﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.Application.Interfaces.Repositories
{
    public interface IQuery<T>
    {
        IQueryable<T> Query();
    }
}
