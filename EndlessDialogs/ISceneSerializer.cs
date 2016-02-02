using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessDialogs
{
    public interface ISceneSerializer
    {
        void Serialize(IScene scene, string fileName);

        IScene Deserialize(string fileName);
    }
}
