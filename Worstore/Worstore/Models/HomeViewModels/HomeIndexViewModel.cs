﻿using System.Collections.Generic;
using Worstore.Models.GeneralModels;

namespace Worstore.Models.HomeViewModels
{
    public class HomeIndexViewModel
    {
        public List<SpokenLanguageViewModel> Languages { get; set; }
        public WordViewModel Word { get; set; }
    }
}
