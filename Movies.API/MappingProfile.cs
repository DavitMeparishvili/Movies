using AutoMapper;
using IMDbApiLib.Models;
using Movies.Application.Commands;
using Movies.Application.Dto;
using Movies.Application.Queries;
using Movies.Domain.Entities;
using Movies.Domain.Filters;

namespace Movies.API;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetMoviesQuery, MoviesFilter>();

        CreateMap<Movie, MovieDto>();

        CreateMap<AdvancedSearchResult, MovieDto>();

        CreateMap<AdvancedSearchResult, MovieDto>()
            .ForMember(
                dest => dest.GenreList,
                opt => opt.MapFrom(src => src.GenreList.Select(x => new KeyValuePair<string, string>(x.Key, x.Value))))
            .ForMember(
                dest => dest.Actors,
                opt => opt.MapFrom(src => src.StarList.Select(x => x.Name)));

        CreateMap<AddWatchListCommand, WatchList>();

        CreateMap<WatchList, WatchListDto>();
    }
}
