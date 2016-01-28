using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessDialogs
{
    public interface IBasicObject
    {
        void SetName(string name);
        string GetName();

        void SetDescription(string description);
        string GetDescription();
    }
}
