using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebApp22.Entity;

namespace WebApp22.EntityConfig
{
    class SharedCarConfig:EntityTypeConfiguration<SharedCar>
    {
        public SharedCarConfig()
        {
            this.ToTable("T_SharedCar");
          
        }
    }
}