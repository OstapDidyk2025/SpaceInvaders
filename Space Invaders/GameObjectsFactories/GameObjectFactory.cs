
namespace Space_Invaders.GameObjectsFactories
{
    abstract class GameObjectFactory
    {

        public GameSettings settings { get; set; }

        public abstract GameObject GameObject(GameObjectPlace place);

        public GameObjectFactory(GameSettings Settings)
        { 
            settings = Settings;
        }
    }
}
