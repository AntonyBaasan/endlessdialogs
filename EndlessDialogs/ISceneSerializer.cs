namespace EndlessDialogs
{
    public interface ISceneSerializer
    {
        void Serialize(IScene scene, string fileName);

        IScene Deserialize(string fileName);
		
    }
}
