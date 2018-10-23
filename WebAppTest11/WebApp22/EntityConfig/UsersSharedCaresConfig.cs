using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebApp22.Entity;

namespace WebApp22.EntityConfig
{
    class UsersSharedCaresConfig : EntityTypeConfiguration<UsersSharedCar>
    {
        public UsersSharedCaresConfig()
        {
            this.ToTable("T_User_SharedCar");
            //拆成两个1对多

            //一对多个车
            this.HasRequired(uc => uc.SharedCar).WithMany().HasForeignKey(uc => uc.SharedCarId);

            //一对多个用户
            this.HasRequired(uc => uc.User).WithMany().HasForeignKey(uc => uc.UserId);
        }
    }
}