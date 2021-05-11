using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TrafficMonitor.Domain.Entities;

namespace TrafficMonitor.Infrastructure.SchemaDefinitions
{
    public class TrafficDetectorEntitySchemaDefinition : IEntityTypeConfiguration<TrafficDetector>
    {
        public void Configure(EntityTypeBuilder<TrafficDetector> builder)
        {
            builder.ToTable("TrafficDetectors", TrafficMonitorContext.DEFAULT_SCHEMA);
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Latitude).IsRequired();
            builder.Property(p => p.Longitude).IsRequired();
        }
    }
}
