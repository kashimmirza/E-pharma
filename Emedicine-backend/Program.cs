var builder = WebApplication.CreateBuilder(args);

//// Add services to the container
builder.Services.AddControllers();

//// Register Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the configuration
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowFrontendOrigin",
//        builder =>
//        {
//            builder.WithOrigins("http://localhost:3000") // Match the frontend port
//                   .AllowAnyHeader()
//                   .AllowAnyMethod();
//        });
//});*/
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAllOrigins",

//        builder =>
//        {
//            builder.AllowAnyOrigin()
//            .AllowAnyHeader()
//            .AllowAnyMethod();

//        });


//});



//Register CORS with a policy for your specific frontend origin
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontendOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000") // Allow only your frontend origin
                   .AllowAnyHeader()   // Allows any HTTP headers
                   .AllowAnyMethod();  // Allows any HTTP methods (GET, POST, etc.)
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Apply the specific CORS policy globally (important for API access from frontend)
app.UseCors("AllowFrontendOrigin");

app.MapControllers();

app.Run();

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllers(); // Ensure this line is present

//// Add CORS policy, if needed
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowSpecificOrigins", builder =>
//    {
//        builder.WithOrigins("http://localhost:3000")
//            .AllowAnyHeader()
//            .AllowAnyMethod()
//            .AllowCredentials();
//    });
//});

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}

//app.UseHttpsRedirection();

//app.UseRouting();

//// Use CORS
//app.UseCors("AllowSpecificOrigins");

//// Enable controllers
//app.UseAuthorization();
//app.MapControllers(); // Ensure this line is present

//app.Run();

