using IMDbApiLib;
using IMDbApiLib.Models;
using Movies.Domain.Entities;
using Movies.Domain.Filters;
using Movies.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using AutoMapper;

namespace Movies.Infrastructure.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly ApiLib _apiLib;
        private readonly IMapper _mapper;

        public MoviesRepository(IConfiguration configuration, IMapper mapper)
        {
            var key = configuration["IMBD:ApiKey"];
            _apiLib = new ApiLib(key);
            _mapper = mapper;
        }   
        
        public async Task<List<Movie>> GetByExpressionAsync(MoviesFilter filter)
        {
            var input = new AdvancedSearchInput()
            {
                Title = filter.Title,
                Genres = filter.Genre is not null ? (AdvancedSearchGenre)filter.Genre : null,
                Languages = filter.LanguageId is not null ? (AdvancedSearchLanguage)filter.LanguageId : null,
                ReleaseDateFrom = filter.ReleaseDateFrom?.ToString(),
                ReleaseDateTo = filter.ReleaseDateTo?.ToString(),
                UserRatingFrom = filter.UserRatingFrom,
                UserRatingTo = filter.UserRatingTo
            };            
            var response = await _apiLib.AdvancedSearchAsync(input);

            return response.Results.Select(x => new Movie()
            {
                Id = x.Id,
                Title = x.Title,
                GenreList = x.Genres != null ? x.Genres.Split(',').ToList() : null,
                IMDbRating = x.IMDbRating,
                Actors = x.Stars != null ? x.Stars.Split(',').ToList() : null
            }).ToList();
        }

        public async Task<Movie> GetByIdAsync(string id)
        {
            var titleData = await _apiLib.TitleAsync(id);

            return new Movie()
            {
                Id = titleData.Id,
                Title = titleData.Title,
                GenreList = titleData.Genres != null ? titleData.Genres.Split(',').ToList() : null,
                IMDbRating = titleData.IMDbRating,
                Actors = titleData.Stars != null ? titleData.Stars.Split(',').ToList() : null
            };
        }
    }
}
