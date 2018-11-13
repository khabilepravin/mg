﻿using dataModel;
using dataModel.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class MediaController : ControllerBase
    {
        private readonly IMediaRepository _mediaRepository;

        public MediaController(IMediaRepository mediaRepository)
        {
            _mediaRepository = mediaRepository;
        }

        // GET: api/Media
        [HttpGet]
        public IEnumerable<Media> GetMedia()
        {
            return null;// _context.Media;
        }

        // GET: api/Media/5
        [HttpGet("{id}")]
        public  IActionResult GetMedia([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var media = await _context.Media.FindAsync(id);

            //if (media == null)
            //{
            //    return NotFound();
            //}

            return Ok("");
        }

        // PUT: api/Media/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedia([FromRoute] string id, [FromBody] Media media)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != media.Id)
            {
                return BadRequest();
            }

            //_context.Entry(media).State = EntityState.Modified;

            await _mediaRepository.UpdateMedia(media);

            return NoContent();
        }

        // POST: api/Media
        [HttpPost]
        public async Task<IActionResult> PostMedia([ModelBinder(BinderType = typeof(JsonModelBinder))] Media media,
                IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           var newMedia = await _mediaRepository.AddMedia(media);

            return Ok(newMedia);
        }

        // DELETE: api/Media/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMedia([FromRoute] string id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //var media = await _context.Media.FindAsync(id);
            //if (media == null)
            //{
            //    return NotFound();
            //}

            //_context.Media.Remove(media);
            //await _context.SaveChangesAsync();

            return Ok("");
        }
    }
}