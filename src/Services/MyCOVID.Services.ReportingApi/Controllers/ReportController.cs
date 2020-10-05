using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCOVID.Services.ReportingApi.Data;
using MyCOVID.Services.ReportingApi.Model;
using MyCOVID.Services.ReportingApi.Model.ProblemDetails;

namespace MyCOVID.Services.ReportingApi.Controllers
{
    [ApiController]
    [Route("/v1/report")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class ReportController : ControllerBase
    {
        private readonly ReportingContext _context;
        
        public ReportController(ReportingContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns a list of all blocks with their respective infection numbers.
        /// </summary>
        /// <response code="200">Block data received.</response>
        /// <response code="500">The request was not processed successfully or an issue has occurred in the MyCOVID service.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Block>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllBlocks()
        {
            var blocks = await _context.Blocks.ToListAsync();
            return Ok(blocks);
        }
        
        /// <summary>
        /// Retrieves a specific report about a block.
        /// </summary>
        /// <param name="block" example="Adsetts">The block to query.</param>
        /// <response code="200">Block data received.</response>
        /// <response code="400">The request cannot be processed because it is either malformed or not correct.</response>
        /// <response code="500">The request was not processed successfully or an issue has occurred in the MyCOVID service.</response>
        [HttpGet]
        [Route("{block}")]
        [ProducesResponseType(typeof(Block), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetSpecificBlock([Required] string block)
        {
            var entity = await _context.Blocks.FindAsync(block);
            if (entity == null)
                return StatusCode(StatusCodes.Status404NotFound );

            return Ok(entity);
        }
        
        /// <summary>
        /// Adds a new infection to a specific block.
        /// </summary>
        /// <param name="block" example="Adsetts">The block to query.</param>
        /// <response code="200">Added infections to block successfully.</response>
        /// <response code="400">The request cannot be processed because it is either malformed or not correct.</response>
        /// <response code="500">The request was not processed successfully or an issue has occurred in the MyCOVID service.</response>
        [ProducesResponseType(typeof(Block), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost]
        public async Task<IActionResult> AddInfection([Required] Block block)
        {
            // ensure that infections are greater than 0
            if (block.Numbers <= 0)
                return StatusCode(StatusCodes.Status400BadRequest, new InfectionValidationProblemDetail());

            // ensure that the block is a valid one
            var entity = await _context.Blocks.FindAsync(block.Id);
            if (entity == null)
                return StatusCode(StatusCodes.Status404NotFound);

            // update the numbers of the entity and then save changes
            entity.Numbers += block.Numbers;
            _context.Blocks.Update(entity);
            await _context.SaveChangesAsync();
            
            return Ok(entity);
        }

        /// <summary>
        /// Removes infections from a specific block.
        /// </summary>
        /// <param name="block" example="Adsetts">The block to query.</param>
        /// <response code="200">Removed infections to a block successfully.</response>
        /// <response code="400">The request cannot be processed because it is either malformed or not correct.</response>
        /// <response code="500">The request was not processed successfully or an issue has occurred in the MyCOVID service.</response>
        [ProducesResponseType(typeof(Block), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpDelete]
        public async Task<IActionResult> RemoveInfection([Required] Block block)
        {
            // ensure that infections are greater than 0
            if (block.Numbers <= 0)
                return StatusCode(StatusCodes.Status400BadRequest, new InfectionValidationProblemDetail());
            
            // ensure that the block is a valid one
            var entity = await _context.Blocks.FindAsync(block.Id);
            if (entity == null)
                return StatusCode(StatusCodes.Status404NotFound);
            
            // update the numbers of the entity and then save changes
            entity.Numbers -= block.Numbers;
            _context.Blocks.Update(entity);
            await _context.SaveChangesAsync();
            
            return Ok(entity);
        }
    }
}