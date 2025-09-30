using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ZenBlog.Domain.Entities.Common;

namespace ZenBlog.Persistence.Interceptors;

public class AuditDbContextInterceptor : SaveChangesInterceptor
{
    private static readonly Dictionary<EntityState, Action<DbContext, BaseEntity>> Behaviors = new()
    {
        {
            EntityState.Added, AddedBehavior
        },
        {
            EntityState.Modified, ModifiedBehavior
        }
    };

    private static void AddedBehavior(DbContext context, BaseEntity baseEntity)
    {
        context.Entry(baseEntity).Property(x => x.UpdatedAt).IsModified = false;
        baseEntity.CreatedAt = DateTime.UtcNow;
    }

    private static void ModifiedBehavior(DbContext context, BaseEntity baseEntity)
    {
        context.Entry(baseEntity).Property(x => x.CreatedAt).IsModified = false;
        baseEntity.UpdatedAt = DateTime.UtcNow;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new())
    {
        if (eventData.Context == null) return base.SavingChangesAsync(eventData, result, cancellationToken);
        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if (entry.Entity is not BaseEntity baseEntity) continue;
            if (entry.State is not (EntityState.Added or EntityState.Modified)) continue;
            Behaviors[entry.State](eventData.Context, baseEntity);
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        if (eventData.Context == null) return base.SavingChanges(eventData, result);
        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if (entry.Entity is not BaseEntity baseEntity) continue;
            if (entry.State is not (EntityState.Added or EntityState.Modified)) continue;
            Behaviors[entry.State](eventData.Context, baseEntity);
        }

        return base.SavingChanges(eventData, result);
    }
}