﻿using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ProductDAL : DALGenericoImpl<Product>, IProductDAL
    {
        NorthwndContext _context;
        public ProductDAL(NorthwndContext context) : base(context)
        {
            _context = context;
        }
    }
}