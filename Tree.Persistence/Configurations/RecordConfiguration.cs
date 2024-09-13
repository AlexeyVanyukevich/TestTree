using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Tree.Domain.Models;

using Tree.Persistence.Constants;

namespace Tree.Persistence.Configurations;
internal class RecordConfiguration : BaseConfiguration<Record> {
    public RecordConfiguration() : base(TablesNames.Journal) { }

    public override void Configure(EntityTypeBuilder<Record> builder) {
        base.Configure(builder);

        builder.Property(n => n.Text)
            .IsRequired();

        builder.Property(n => n.EventId)
            .IsRequired();

    }
}