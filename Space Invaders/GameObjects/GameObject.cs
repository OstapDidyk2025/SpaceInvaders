
namespace Space_Invaders
{
    abstract class GameObject
    {
        public GameObjectPlace GameObjectPlace { get; set; }

        public char figure { get; set; }
        public GameObjectType gameObjectType { get; set; }

    }
}
