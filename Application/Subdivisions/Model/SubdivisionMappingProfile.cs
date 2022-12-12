﻿using AutoMapper;
using Domain;

namespace Application.Subdivisions.Model;

public sealed class SubdivisionMappingProfile : Profile
{
    public SubdivisionMappingProfile()
    {
        CreateMap<CreateSubdivisionDto, Subdivision>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        CreateMap<Subdivision, SubdivisionViewModel>();
    }
}