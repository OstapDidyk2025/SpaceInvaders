using Space_Invaders.GameObjects;

namespace Space_Invaders.GameObjectsFactories
{
    internal class AlienShipMissileFactory : GameObjectFactory
    {
        public AlienShipMissileFactory(GameSettings settings) : base(settings) 
        { }

        public override GameObject GameObject(GameObjectPlace place) 
        {
            GameObjectPlace missilePlace = new GameObjectPlace() {XCordinate = place.XCordinate, YCordinate = place.YCordinate + 1};
            GameObject missile = new AlienShipMissile() { figure = settings.AlienMissileFigure, GameObjectPlace = missilePlace, gameObjectType = GameObjectType.AlienShipMissile };
            return missile;
        }
    }
}
