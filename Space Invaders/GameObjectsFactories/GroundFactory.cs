
using System.Collections.Generic;

namespace Space_Invaders.GameObjectsFactories
{
    internal class GroundFactory : GameObjectFactory
    {
        public GroundFactory(GameSettings Settings) : base(Settings)
        {

        }


        public override GameObject GameObject(GameObjectPlace place)
        {
            GameObject ground = new GroundObject() {figure = settings.GroundObjectFigure, GameObjectPlace = place, gameObjectType = GameObjectType.GroundObject };

            return ground;
        }

        public List<GameObject> GetGround()
        {
            List<GameObject> ground = new List<GameObject>();

            int StartX = settings.GroundObjectXCordinate;
            int StartY = settings.GroundObjectYCordinate;


            for (int y = 0; y < settings.GroundObjectRow; y++)
            {
                for (int x = 0; x < settings.GroundObjectColumn; x++)
                {

                    GameObjectPlace place = new GameObjectPlace() { XCordinate = StartX + x, YCordinate = StartY + y };
                    GameObject GroundPiece = GameObject(place);
                    ground.Add(GroundPiece);
                }
            }

            return ground;
        }
    }
}
