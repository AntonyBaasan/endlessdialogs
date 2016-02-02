using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EndlessDialogs
{
    /// <summary>
    /// Saves and loads Scene object to a file.
    /// </summary>
    public class SceneFileSerializer : ISceneSerializer
    {
        public IScene Deserialize(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("File ");

            IScene scene = null;
            using (Stream fileStream = File.OpenRead(fileName))
            { 
                BinaryFormatter deserializer = new BinaryFormatter();
                scene = (Scene)deserializer.Deserialize(fileStream);
            }

            return scene;
        }

        public void Serialize(IScene scene, string fileName)
        {
            using (Stream fileStream = File.Create(fileName))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(fileStream, scene);
            }
        }
    }
}
