﻿using System;
using System.Collections.Generic;
using AnimalRescue.Contracts.BusinessLogic.Models;
using AnimalRescue.DataAccess.Mongodb.Exceptions;
using AnimalRescue.DataAccess.Mongodb.Models;

using AutoMapper;

using System.Linq;

namespace AnimalRescue.BusinessLogic.Configurations.MappingProfiles
{
    internal class AnimalMappingProfile : Profile
    {
        public AnimalMappingProfile()
        {
            CreateMap<Animal, AnimalDto>()
                .ForMember(x => x.ImageIds, o => o.MapFrom(x => x.ImageIds.Select(ObjectIdExtentions.AsGuid)))
                .ForMember(x => x.Id, o => o.MapFrom(x => x.Id.AsGuid()));
            CreateMap<AnimalDto, Animal>()
                .ForMember(x => x.ImageIds, o => o.MapFrom(x => x.ImageIds.Select(ObjectIdExtentions.AsObjectIdString)))
                .ForMember(x => x.Id, o => o.MapFrom(x => x.Id.AsObjectIdString()))
                .ForMember(x => x.ModifiedBy, options => options.Ignore())
                .ForMember(x => x.DateOfAdopted, options => options.Ignore())
                .ForMember(x => x.DateOfFound, options => options.Ignore());
        }
    }
}
