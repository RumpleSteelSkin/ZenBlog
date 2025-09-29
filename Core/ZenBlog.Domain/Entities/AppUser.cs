using Microsoft.AspNetCore.Identity;

namespace ZenBlog.Domain.Entities;

public class AppUser: IdentityUser<string>
{
    public AppUser()
    {
        Id = Guid.NewGuid().ToString();
    }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? ImageUrl { get; set; }
    public virtual required IList<Blog> Blogs { get; set; }
}