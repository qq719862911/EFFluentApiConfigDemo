using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApp22.DB
{
    public static class EFHelper
    {
        public static void LogEFConfigError(DbEntityValidationException ex)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var err in ex.EntityValidationErrors.SelectMany(dvr => dvr.ValidationErrors))
            {
                sb.AppendLine(err.PropertyName + ":" + err.ErrorMessage);
            }
            byte[] myByte = System.Text.Encoding.UTF8.GetBytes(sb.ToString());
            using (FileStream fsWrite = new FileStream(@"D:\fluentApiErrorLog.txt", FileMode.Append))
            {
                fsWrite.Write(myByte, 0, myByte.Length);
            };
        }
    }
}