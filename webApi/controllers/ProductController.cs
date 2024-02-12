[ApiController]
using C-project.entities.models;

namespace C-project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController(DbContext ctx) : ControllerBase
    {

        private readonly ProductService? _productServ = new(ctx);


        // GET: api/products
        [HttpGet, Route("/product")]
        public ActionResult<IEnumerable<Product>> GetProduct()
        {
            return Ok(_productServ?.GetAll());
        }

        // GET: api/products/5
        [HttpGet, Route("/products/{id}")]
        public ActionResult<Product> GetProduct(Guid id)
        {
            var product = _productServ?.GetById(id);
            return product == null
                ? NotFound()
                : Ok(product);
        }

        // PUT: api/products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut, Route("/products/{id}")]
        public IActionResult PutProduct(Guid id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            try
            {
                _productServ?.Update(product);
                _productServ?.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_productServ?.GetById(id) != null)
                {
                    return NotFound();
                }

                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost, Route("/uProducts")]
        public IActionResult PostProduct(Product product)
        {
            _productServ?.Add(product);
            _productServ?.SaveChanges();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/products/5
        [HttpDelete, Route("/products/{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            try
            {
                _productServ?.DeleteById(id);
                _productServ?.SaveChanges();
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // PUT: api/addproducts/5
        [HttpPut, Route("/addproducts/{id}/{userId}")]
        public IActionResult AddProductToCart(Guid id,Guid userId)
    {
        var user = _context.Users.Include(u => u.Cart).FirstOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return null;
        }

        var product = _context.Products.Find(id);

        if (product == null)
        {
            return null;
        }
        if (!product.Available)
        {
            return null;
        }

        user.Cart.Products.Add(product);
        _context.SaveChanges();

        return user.Cart;
    }
    }
}