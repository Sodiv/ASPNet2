﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.ViewModel.Cart;

namespace WebStore.Domain.ViewModel.Order
{
    public class DetailsViewModel
    {
        public CartViewModel CartViewModel { get; set; }

        public OrderViewModel OrderViewModel { get; set; }
    }
}
