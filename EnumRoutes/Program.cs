using EnumRoutes;
using System.Text.Json.Serialization;

/*
 * 
 * There are 3 spots in the app setup that have code for the route enum setup. They are marked below
 * 
 */

var builder = WebApplication.CreateBuilder(args);

// 1 - Call is already present in the default template, but added the options config
builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("tcgPlayerCategoryEnum", typeof(RouteConstraint));
});

// 2 - Call is already present in the default template, but added the options config
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();

// 3 - Call is already present in the default template, but added the options config
builder.Services.AddSwaggerGen(options =>
{
    options.SchemaFilter<EnumSchemaFilter>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
