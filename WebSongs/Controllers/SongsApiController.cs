﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSongs.Data;
using WebSongs.Models;

namespace WebSongs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SongsApiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/SongsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSong()
        {
            return await _context.Song.ToListAsync();
        }

        // GET: api/SongsApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(string id)
        {
            var song = await _context.Song.FindAsync(id);

            if (song == null)
            {
                return NotFound();
            }

            return song;
        }

        // PUT: api/SongsApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(string id, Song song)
        {
            if (id != song.NombreCancion)
            {
                return BadRequest();
            }

            _context.Entry(song).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SongsApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            _context.Song.Add(song);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SongExists(song.NombreCancion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSong", new { id = song.NombreCancion }, song);
        }

        // DELETE: api/SongsApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(string id)
        {
            var song = await _context.Song.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            _context.Song.Remove(song);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SongExists(string id)
        {
            return _context.Song.Any(e => e.NombreCancion == id);
        }
    }
}