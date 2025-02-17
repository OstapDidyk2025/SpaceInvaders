
namespace Space_Invaders.GameObjectsFactories
{
    internal class PlayerShipFactory : GameObjectFactory
    {
        public PlayerShipFactory(GameSettings Settings) : base(Settings)
        { }
        public override GameObject GameObject(GameObjectPlace place)
        {
            GameObject playerShip = new PlayerShip() { figure = settings.PlayerShipFigure, GameObjectPlace = place, gameObjectType = GameObjectType.PlayerShip };

            return playerShip;
        }

        public GameObject GetPlayerShip()
        {
            GameObjectPlace playerPlace = new GameObjectPlace() { XCordinate = settings.PlayerShipXCordinate, YCordinate = settings.PlayerShipYCordinate };
            GameObject playerShip = GameObject(playerPlace);
            return playerShip;
        }

    }
}
