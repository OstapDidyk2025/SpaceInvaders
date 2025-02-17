using System.Collections.Generic;

namespace Space_Invaders.GameObjectsFactories
{
    internal class AlienShipFactory : GameObjectFactory
    {
        public AlienShipFactory(GameSettings Settings) : base(Settings)
        { 
            
        }


        public override GameObject GameObject(GameObjectPlace place)
        {
            GameObject alienShip = new AlienShip() {figure = settings.AlienShipFigure, GameObjectPlace = place, gameObjectType = GameObjectType.AlienShip };
        
            return alienShip;
        }

        public List<GameObject> GetSwarm()
        { 
            List<GameObject> swarm = new List<GameObject>();

            int StartX = settings.AlienShipXCordinate;
            int StartY = settings.AlienShipYCordinate;
            int PresentX;
            int PresentY;

            for (int y = 0; y < settings.AlienShipRow; y++)
            {
                PresentY = y * 2;

                for (int x = 0; x < settings.AlienShipColumn; x++)
                {
                    PresentX = x * 2;

                    GameObjectPlace place = new GameObjectPlace() { XCordinate = StartX + PresentX, YCordinate = StartY + PresentY };
                    GameObject AlienShip = GameObject(place);
                    swarm.Add(AlienShip);
                }
            }

            return swarm;
        }
    }
}
