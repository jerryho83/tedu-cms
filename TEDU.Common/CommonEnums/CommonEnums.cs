using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEDU.Common
{
    public enum StatusEnum
    {
        Publish,
        Locked,
        Pending,
        Draft,
        Trash,
        Top
    }

    public enum PostTypeEnum
    {
        Article,
        Image,
        Video,
        File
    }
}
