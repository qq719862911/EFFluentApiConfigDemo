using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp22.Entity
{
    public class UsersSharedCar
    {
        public long Id { get; set; }
        
        public long UserId { get; set; }

        public long SharedCarId { get; set; }
        /// <summary>
        /// 亲密度 
        /// </summary>
        public int? IntimacyValue { get; set; }
       /// <summary>
       /// 这个关系对应的用户信息
       /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// 这个关系对应的共享车信息
        /// </summary>
        public virtual SharedCar SharedCar { get; set; }
    }
}