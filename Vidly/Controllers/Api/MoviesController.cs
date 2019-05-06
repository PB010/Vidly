﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Data.Entity;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    [Authorize (Roles = RoleName.CanManageMovies)]
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContextModel _context;

        public MoviesController()
        {
            _context = new ApplicationDbContextModel();
        }

        //GET api/movies

        public IEnumerable<MoviesDto> GetMovies()
        {
            return _context.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MoviesDto>);
        }

        //GET api/movies/1

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map < Movie, MoviesDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MoviesDto moviesDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            var movie = Mapper.Map<MoviesDto, Movie>(moviesDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            moviesDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), moviesDto);

        }

        [HttpPut]
        public IHttpActionResult EditMovie(int id, MoviesDto moviesDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var moviesInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (moviesInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(moviesDto, moviesInDb);

            _context.SaveChanges();

            return Ok(moviesInDb);
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movies = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movies == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movies);
            _context.SaveChanges();

            return Ok();
        }
    }
}