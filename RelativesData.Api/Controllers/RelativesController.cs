using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelativesData.Core.Repositories;
using RelativesData.Ef.Models;
using RepoPattern2.Ef;

namespace RelativesData.Api.Controllers
{
    [Route("api/[controller]")]
    
    public class RelativesController : ControllerBase
    {
        private readonly IBaseRepository<Relative> _relativeRepository;

        public RelativesController(IBaseRepository<Relative> relativeRepository)
        {
            _relativeRepository = relativeRepository;
        }

        // GET: api/Relatives

        [HttpGet("GetAllRelatives")]
        [Authorize]
        public IActionResult GetAllRelatives(int SapNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(_relativeRepository.GetAll(x => x.SapNumber == SapNumber));

            }
            catch (Exception e)
            {

                return NotFound(e.Message);

            }
        }

        [Authorize]
        [HttpPost("AddRelative")]
        public IActionResult AddRelative([FromBody]Relative obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(_relativeRepository.Add(obj));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
           
        }


        [HttpPost("AddManyRelatives")]
        public IActionResult AddManyRelatives([FromBody]IEnumerable<Relative> objs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(_relativeRepository.AddRange(objs));
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }

        }




        [HttpPut("UpdateRelative")]
        public IActionResult UpdateRelative([FromBody]Relative obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(_relativeRepository.Update(obj));

            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
        }

        //[HttpDelete("DeleteRelative")]
        //public IActionResult DeleteRelative(Relative obj)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    try
        //    {
        //        _relativeRepository.Delete(obj);
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {

        //        return NotFound(e.Message);
        //    }
            
        //}



        //// DELETE: api/Relatives/5
        [HttpDelete("DeleteRelative/{id}")]
        public IActionResult  DeleteRelative([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var relative = _relativeRepository.GetById(id);
                if (relative == null)
                {
                    return NotFound();
                }

                _relativeRepository.Delete(relative);


                return Ok(relative);

            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }

        }



        
    }
}