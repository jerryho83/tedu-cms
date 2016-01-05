using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedu.Entities;

namespace Tedu.Data.Configurations
{
    public class VisitorConfiguration : EntityBaseConfiguration<Visitor>
    {
        public VisitorConfiguration()
        {
            Property(e => e.IPAddress)
              .IsUnicode(false);

            Property(e => e.Brower)
                .IsUnicode(false);

            Property(e => e.Platform)
                .IsUnicode(false);
        }
    }
}
