using ControllerProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllerProject.DataBase.Maps
{

    public class ContactMap : IEntityTypeConfiguration<ContactModel>
    {

        public void Configure(EntityTypeBuilder<ContactModel> builder)
        {

            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User);

        }

    }

}
