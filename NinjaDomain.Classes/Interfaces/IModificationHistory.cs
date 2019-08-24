using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaDomain.Classes.Interfaces
{
    interface IModificationHistory
    {
        DateTime DateCreated { get; set; }

        DateTime  DateModified{ get; set; }

        bool isDirty { get; set; }

    }
}
