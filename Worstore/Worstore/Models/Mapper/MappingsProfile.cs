using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Worstore.Entities;
using Worstore.Models.HomeViewModels;

namespace Worstore.Models.Mapper
{

    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<WordViewModel, Word>();
            CreateMap<Word, GameWordViewModel>();
        }

    }
}
