using Microsoft.AspNetCore.Mvc;
using SequenceDataStructure.Models;
using SequenceDataStructure.Models.Exceptions;
using SequenceDataStructure.Helpers;
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
                var res = SequentialListFactory.CreateNew(input);
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
        [Route("getidx")]
        public ActionResult GetByIDX([FromQuery] int min, [FromQuery] int max, [FromQuery] int idx)
        {
            try
            {
                var obj = SequentialListFactory.CreateNew(min, max);
                int res = obj[idx];
                return Ok(res);

            }
            catch (IndexOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Gets the index of an element with value val
        /// </summary>
        /// <param name="min">Lowest number</param>
        /// <param name="max">Highest number</param>
        /// <param name="val">Value to search for.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("getval")]
        public ActionResult GetIdxByVal([FromQuery] int min, [FromQuery] int max, [FromQuery] int val)
        {
            try
            {
                var obj = SequentialListFactory.CreateNew(min, max);
                int res = obj.IndexOf(val);
                if (res < 0)
                {
                    throw new ValueNotInListException();
                }
                return Ok(res);

            }
            
            catch (Exception ex)
            {
                if (ex is IndexOutOfRangeException || ex is ValueNotInListException)
                {
                    return BadRequest(ex.Message);
                }
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Gets element of index based off passed JSON object
        /// </summary>
        [HttpPost]
        [Route("getidx")]
        public ActionResult GetByIdx([FromBody] SequentialListJSONInput input)
        {
            try
            {  
                SequentialList list = SequentialListFactory.CreateNew(input);
                int res = list[input.idx];
                return Ok(res);

            }
            catch (Exception ex)
            {
                if (ex is NotSequentialException || ex is ArgumentNullException || ex is IndexOutOfRangeException)
                {
                    return BadRequest(ex.Message);
                }
                return StatusCode(500);
            }
        }
    }
}