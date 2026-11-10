using LevGamekit.Infrastructure.ServiceLocator;
using System;

namespace LevGamekit.Infrastructure.SceneLoader
{
    public interface ISceneLoader : IService
    {
        void Load(string name, Action onLoaded = null);
    }
}
