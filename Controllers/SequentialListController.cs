using Microsoft.AspNetCore.Mvc;
using SequenceDataStructure.Models;
using SequenceDataStructure.Model.Exceptions;
using System.Net.Mime;

namespace SequenceDataStructure.Controllers
{
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("listify")]
    public class SequentialListController : ControllerBase
    {
        //listify
        [HttpPost]
        [Route("create")]
        public ActionResult Create([FromBody] SequentialListInput input)
        {
            try
            { 
                var res = SequentialListFactory.CreateFromInput(input);
                return Ok(res);

            }
            catch (InvalidSequentialListRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("getidx/{idx}")]
        public ActionResult GetByIDX(int id)
        {
            var 
        }
    }
}