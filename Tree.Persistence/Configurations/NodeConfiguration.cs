using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Tree.Domain.Models;
using Tree.Persistence.Constants;

namespace Tree.Persistence.Configurations;
internal sealed class NodeConfiguration 
    : BaseConfiguration<Node> {
    public NodeConfiguration(): base(TablesNames.Nodes) { }

    public override void Configure(EntityTypeBuilder<Node> builder) {
        base.Configure(builder);

        builder.Property(n => n.Name)
            .IsRequired();

        builder.HasOne(t => t.Parent)
            .WithMany(t => t.Children)
            .HasForeignKey(t => t.ParentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
