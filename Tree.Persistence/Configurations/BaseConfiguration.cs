using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Tree.Domain.Models;

namespace Tree.Persistence.Configurations;
internal abstract class BaseConfiguration<TBase> 
    : IEntityTypeConfiguration<TBase> where TBase : Base {
    public virtual void Configure(EntityTypeBuilder<TBase> builder) {
        builder.HasKey(u => u.Id);
        builder.ToTable(nameof(TBase));
    }
}
