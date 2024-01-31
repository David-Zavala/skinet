using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Errors;


namespace API.Controllers
{
    public class BuggyController(StoreContext context) : BaseApiController
    {
        private readonly StoreContext _context = context;
        
        [HttpGet("notfound")]
        public ActionResult<Product> GetNotFound()
        {
            var thing = _context.Products.Find(-1);

            if (thing == null) return NotFound(new ApiResponse(404));

            return Ok();
        }
        
        [HttpGet("servererror")]
        public ActionResult<string> GetServerError()
        {
            var thing = _context.Products.Find(42);
            
            var thingToReturn = thing.ToString();

            return Ok();
        }
        
        [HttpGet("badrequest")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult<string> GetBadRequest(int id)
        {
            return Ok();
        }
    }
}