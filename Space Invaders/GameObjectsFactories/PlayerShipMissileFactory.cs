
namespace Space_Invaders.GameObjectsFactories
{
    internal class PlayerShipMissileFactory : GameObjectFactory
    {
        public PlayerShipMissileFactory(GameSettings settings) : base(settings)
            { }

        public override GameObject GameObject(GameObjectPlace place)
        {
            GameObjectPlace misslePlace = new GameObjectPlace() {XCordinate = place.XCordinate, YCordinate = place.YCordinate - 1 };
            GameObject missile = new PlayerShipMissile() { figure = settings.PlayerMissileFigure, GameObjectPlace = misslePlace, gameObjectType = GameObjectType.PlayerShipMissile };
            return missile;
        }
    }
}
