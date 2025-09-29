using ZenBlog.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddZenBlogApi(builder.Configuration);

var app = builder.Build();

app.AddZenBlogApiApp();