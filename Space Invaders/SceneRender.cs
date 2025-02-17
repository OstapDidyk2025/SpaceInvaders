using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Space_Invaders
{
    internal class SceneRender
    {
        int _screenHeight;
        int _screenWidth;

        char[,] _screenMatrix;

        public SceneRender(GameSettings settings)
        {
            _screenHeight = settings.ConsoleHeight;
            _screenWidth = settings.ConsoleWidth;
            _screenMatrix = new char[settings.ConsoleHeight, settings.ConsoleWidth];

            Console.WindowHeight = _screenHeight;
            Console.WindowWidth = _screenWidth;


            SetCursor();
        }

        public void SetCursor()
        {
            Console.SetCursorPosition(0, 0);
        }
        public void Render(Scene scene)
        {
            Console.OutputEncoding = Encoding.UTF8;

            SetCursor();

            AddListForRenderinh(scene.swarm);
            AddListForRenderinh(scene.ground);
            AddListForRenderinh(scene.playerShipMissile);
            AddListForRenderinh(scene.alienShipMissile);

            AddGameObjectForRenderinh(scene.playerShip);

            StringBuilder stringBuilder = new StringBuilder();

            for (int y = 0; y < _screenHeight; y++)
            {
                for (int x = 0; x < _screenWidth; x++)
                {
                    stringBuilder.Append(_screenMatrix[y, x]);
                }
                stringBuilder.Append(Environment.NewLine);
            }

            Console.WriteLine(stringBuilder.ToString());

            Console.CursorVisible = false;
            SetCursor();
        }

        public void AddGameObjectForRenderinh(GameObject gameObject)
        {
            if (gameObject.GameObjectPlace.YCordinate < _screenMatrix.GetLength(0) &&
                gameObject.GameObjectPlace.XCordinate < _screenMatrix.GetLength(1))
            {
                _screenMatrix[gameObject.GameObjectPlace.YCordinate, gameObject.GameObjectPlace.XCordinate] = gameObject.figure;
            }
            else
            {
                ;// _screenMatrix[gameObject.GameObjectPlace.YCordinate, gameObject.GameObjectPlace.XCordinate] = ' ';
            }
        }

        public void AddListForRenderinh(List<GameObject> gameObjects)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                AddGameObjectForRenderinh(gameObject);
            }
        }

        public void AddSwarmListForRenderinh(List<GameObject> gameObjects)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                AddGameObjectForRenderinh(gameObject);
            }
        }

        public void GetClear()
        {
            for (int y = 0; y < _screenHeight; y++)
            {
                for (int x = 0; x < _screenWidth; x++)
                {
                    _screenMatrix[y, x] = ' ';
                }
            }
        }

        private void ShowScore(GameSettings settings, StringBuilder stringBuilder)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            stringBuilder.Append($"Score: {settings.ScoreCount}");

            Console.WriteLine(stringBuilder.ToString());

            Console.ForegroundColor = ConsoleColor.White;
        }


        public void RenderGameWin(GameSettings settings)
        {

            StringBuilder stringBuilder = new StringBuilder();

            Console.ForegroundColor = ConsoleColor.Yellow;

            stringBuilder.Append("Our Congratulation! You Win!");

            Console.WriteLine(stringBuilder.ToString());

            ShowScore(settings, stringBuilder);

        }

        public void RenderGameOver(GameSettings settings)
        {

            StringBuilder stringBuilder = new StringBuilder();

            Console.ForegroundColor = ConsoleColor.Red;

            stringBuilder.Append("Game Over!");

            Console.WriteLine(stringBuilder.ToString());

            ShowScore(settings, stringBuilder);
        }
    }
}
