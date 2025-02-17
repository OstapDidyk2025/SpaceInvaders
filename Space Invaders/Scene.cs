using Space_Invaders.GameObjectsFactories;
using System.Collections.Generic;

namespace Space_Invaders
{
    internal class Scene
    {
        public List<GameObject> swarm;

        public List<GameObject> ground;

        public GameObject playerShip;

        public List<GameObject> playerShipMissile;

        public List<GameObject> alienShipMissile;

        GameSettings _gameSettings;

        private static Scene _scene;

        private Scene()
        { }
        private Scene(GameSettings settings)
        {
            _gameSettings = settings;
            swarm = new AlienShipFactory(_gameSettings).GetSwarm();
            ground = new GroundFactory(_gameSettings).GetGround();
            playerShip = new PlayerShipFactory(_gameSettings).GetPlayerShip();
            playerShipMissile = new List<GameObject>();
            alienShipMissile = new List<GameObject>();
        }

        public static Scene GetScene(GameSettings settings)
        {
            if (_scene == null)
            { 
                _scene = new Scene(settings);
            }
            return _scene;
        }

        public static void ResetScene()
        {
            _scene = null;
        }

    }
}
