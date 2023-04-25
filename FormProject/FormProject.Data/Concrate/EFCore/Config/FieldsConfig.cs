using FormProject.Entity.Concrate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FormProject.Data.Concrate.EFCore.Config
{
    public class FieldsConfig : IEntityTypeConfiguration<Fields>
    {
        public void Configure(EntityTypeBuilder<Fields> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x=>x.LastName).IsRequired();

        }
    }
}
