using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectStructure
{

 ///class ProductController : Controller
 ///{
 ///
 ///    private ProductService _productService;
 ///
 ///    public ProductController(ProductService productService)
 ///    {
 ///        _productService = productService;
 ///    }
 ///    public IActionResult GetProduct(int id)
 ///    {
 ///        var Product = _productService.GetProductById(id);
 ///        return View(Product);
 ///    }
 ///}
 ///
 ///class ProductService
 ///{
 ///    private ProductRepository _productRepository;
 ///    private CategoryRepository _categoryRepository;
 ///
 ///
 ///    public ProductService(ProductRepository productRepository , CategoryRepository categoryRepository )
 ///    {
 ///        _productRepository = productRepository;
 ///        _categoryRepository = categoryRepository;
 ///
 ///    }
 ///    public Product GetProductById(int id)
 ///    {
 ///        //Business Logic 
 ///        var categories = _categoryRepository.GetALL().FindAll(c => c.ISOutOfStock == false);
 ///        var product = _productRepository.Get(id);
 ///        if (!categories.Contains(product.Category))
 ///        {
 ///            product = null;
 ///        }
 ///        return product;
 ///    }
 ///}
 ///
 ///class ProductRepository
 ///{
 ///    private ApplicationDbContext _dbContext;
 ///    
 ///    public ProductRepository(ApplicationDbContext dbContext)//Ask CLR to creating object from dbcontex
 ///    {
 ///        _dbContext =dbContext;
 ///    }
 ///    public void Get(int id)
 ///    {
 ///        return _dbContext.Products.Find(id);
 ///    }
 ///}
 ///
 ///class CategoryRepository
 ///   {
 ///       private ApplicationDbContext _dbContext;
 ///
 ///       public CategoryRepository(ApplicationDbContext dbContext)
 ///       {
 ///           _dbContext = dbContext; 
 ///       }
 ///       public List<Category> GetALL()
 ///       {
 ///           return _dbContext.Categorys.ToList();
 ///       }
 ///   }
 ///class ApplicationDbContext : DbContext
 ///{
 ///    public ApplicationDbContext(DbContextOption option) : base(option)
 ///    {
 ///
 ///    }
 ///    public DbSet<Product> Products { get; set; }
 ///    public DbSet<Category>Categorys { get; set; }   
 ///}
 ///class Product
 ///{
 ///    public int Id { get; set; }
 ///    public string Name { get; set; }
 ///    public string Description { get; set; }
 ///    public decimal UnitPrice { get; set; }
 ///    public Category Category { get; set; }
 ///
 ///}
 ///
 ///class Category
 ///{
 ///    public int Id { get; set; }
 ///    public string Name { get; set; }
 ///    public bool ISOutOfStock { get; set; }  
 ///
 ///}
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
          /// // services.AddTransient<ApllicationDbContext>();
          ///  //services.AddSingleton<CategoryRepository>();    
          ///  services.AddScoped<ApplicationDbContext>(option =>
          ///  {
          ///      option.UseSqlServer("StringConnection ");
          ///  });
          ///  services.AddScoped<CategoryRepository>();
          ///  services.AddScoped<ProductRepository>();
          ///  
        
        
        services.AddControllersWithViews(); 
           /// services.AddMvc();
           /// services.AddControllers();
           /// services.AddRazorPages();   
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapGet("/Hamada", async context =>
                {
                    await context.Response.WriteAsync("Hello Hamada!");
                });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}"

                    );


            });
           
        }
    }
}
