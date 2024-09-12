using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Tree.Domain.Models;

namespace Tree.Persistence.Configurations;
internal sealed class NodeConfiguration 
    : BaseConfiguration<Node> {

    public override void Configure(EntityTypeBuilder<Node> builder) {
        base.Configure(builder);

        builder.Property(n => n.Name)
            .IsRequired();
    }
}
