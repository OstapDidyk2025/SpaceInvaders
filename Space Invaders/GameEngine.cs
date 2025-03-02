using Space_Invaders.GameObjectsFactories;
using System;
using System.Threading;

namespace Space_Invaders
{
    internal class GameEngine
    {
        private static GameEngine _gameEngine;
        private Scene _scene;
        private bool _isNotPaused;
        private bool _isNotOver;
        private bool _isMoveRight;
        private SceneRender _sceneRender;
        private GameSettings _settings;
        private Random _random;
        private GameEngine() { }

        public static GameEngine GetGameEngine(GameSettings settings) 
        { 
            if (_gameEngine == null) 
            { 
                _gameEngine = new GameEngine(settings);
            }
            return _gameEngine; 
        }

        private GameEngine(GameSettings settings) 
        {
            _isNotPaused = true;
            _settings = settings;
            _isNotOver = true;
            _scene = Scene.GetScene(settings);
            _sceneRender = new SceneRender(settings);
            _random = new Random();
            _isMoveRight = true;
        }

        public void Run(GameSettings settings) 
        {
            int SwormMoveSpeed = 0;
            int MissileMoveSpeed = 0;
            int AlienMissileMoveSpeed = 0;

            Thread shootingThread = new Thread(AlienShot);
            shootingThread.Start();

            do
            {
                StatePauseGame();

                _sceneRender.GetClear();
                _sceneRender.Render(_scene);
                Thread.Sleep(_settings.GameSpeed);

                    if (SwormMoveSpeed == _settings.SwarmSpeed)
                    {
                        CalculateSwormMove();
                        SwormMoveSpeed = 0;
                    }
                SwormMoveSpeed++;

                    if (MissileMoveSpeed == _settings.PlayerMissileSpeed)
                    {
                        CalculateMissileMove();
                        MissileMoveSpeed = 0;
                    }
                MissileMoveSpeed++;

                if (AlienMissileMoveSpeed == _settings.AlienMissileSpeed)
                {
                    CalculateAlienMissileMove();
                    AlienMissileMoveSpeed = 0;
                }
                AlienMissileMoveSpeed++;

                EndGame();
            } while (_isNotOver );

            CalculateScore();


            LastMessageShow();
        }

        public void ClalculatePlayerMoveLeft()
        {
            if (_scene.playerShip.GameObjectPlace.XCordinate > 1) 
            {
                _scene.playerShip.GameObjectPlace.XCordinate--;
            }
        }

        public void ClalculatePlayerMoveRight()
        {
            if (_scene.playerShip.GameObjectPlace.XCordinate < _settings.ConsoleWidth - 2)
            {
                _scene.playerShip.GameObjectPlace.XCordinate++;
            }
        }

        private void CalculateSwormMove()
        {
            (GameObject, GameObject) closestsShips = ClosectToSide();
            GameObject closestToRightShip = closestsShips.Item1;
            GameObject closestToLeftShip = closestsShips.Item2;

            if (_isMoveRight && closestToRightShip.GameObjectPlace.XCordinate >= _settings.ConsoleWidth - 2)
            {
                _isMoveRight = false;
                CalculateDownMove();
            }
            else if (!_isMoveRight && closestToLeftShip.GameObjectPlace.XCordinate <= 1)
            {
                _isMoveRight = true;
                CalculateDownMove();
            }
            else 
            {
                CalculateGorizontalMove();
            }
        }

        private void CalculateDownMove()
        {
            for (int i = 0; i < _scene.swarm.Count; i++)
            {
                GameObject alienship = _scene.swarm[i];
                alienship.GameObjectPlace.YCordinate++;

                if (alienship.GameObjectPlace.YCordinate == _scene.playerShip.GameObjectPlace.YCordinate)
                {
                    _isNotOver = false;
                }
            }
        }

        private void CalculateGorizontalMove()
        {

            for (int i = 0; i < _scene.swarm.Count; i++)
            {
                GameObject alienship = _scene.swarm[i];
                if (_isMoveRight)
                {
                    if (alienship.GameObjectPlace.XCordinate < _settings.ConsoleWidth - 2)
                    { 
                        alienship.GameObjectPlace.XCordinate++; 
                    }
                }
                else if (!_isMoveRight)
                {
                    if (alienship.GameObjectPlace.XCordinate > 1)
                    { 
                        alienship.GameObjectPlace.XCordinate--; 
                    }
                }
            }
        }
        private (GameObject, GameObject) ClosectToSide()
        {
            GameObject closestToRight = _scene.swarm[0];
            GameObject closestToLeft = _scene.swarm[0];

            for (int i = 1; i < _scene.swarm.Count; i++)
            {
                GameObject alienShip = _scene.swarm[i];

                if (closestToRight.GameObjectPlace.XCordinate < alienShip.GameObjectPlace.XCordinate)
                {
                    closestToRight = alienShip;
                }
            }
            for (int i = 1; i < _scene.swarm.Count; i++)
            {
                GameObject alienShip = _scene.swarm[i];

                if (closestToLeft.GameObjectPlace.XCordinate > alienShip.GameObjectPlace.XCordinate)
                {
                    closestToLeft = alienShip;
                }
            }

            return (closestToRight, closestToLeft);
        }

        public void Shot()
        {
            PlayerShipMissileFactory missleFactory = new PlayerShipMissileFactory(_settings);

            GameObject missle = missleFactory.GameObject(_scene.playerShip.GameObjectPlace);

            _scene.playerShipMissile.Add(missle);

            Console.Beep(1100, 75);
        }

        private void LastMessageShow()
        {
            if (_scene.swarm.Count == 0)
            {
                _sceneRender.RenderGameWin(_settings);
            }
            else 
            { 
                _sceneRender.RenderGameOver(_settings);
            }
        }

        private void EndGame()
        {
            if (_scene.swarm.Count == 0)
            {
                _isNotOver = false;
            }
        }

        public void AlienShot()
        {
            while (true)
            {
                foreach (AlienShip alienShip in _scene.swarm)
                {
                    if (_random.Next(0, 100) < 1)
                    {
                        if (CanShootChecker(alienShip))
                        {
                            AlienShipMissileFactory missleFactory = new AlienShipMissileFactory(_settings);

                            GameObject missle = missleFactory.GameObject(alienShip.GameObjectPlace);

                            _scene.alienShipMissile.Add(missle);
                        } 
                    }
                }
                Thread.Sleep(1000);
            }
        }

        private void CalculateMissileMove()
        {
            for (int i = 0; i < _scene.playerShipMissile.Count; i++)
            {
                GameObject missile = _scene.playerShipMissile[i];

                if (missile.GameObjectPlace.YCordinate == 1)
                {
                    _scene.playerShipMissile.RemoveAt(i);
                }

                missile.GameObjectPlace.YCordinate--;
                for (int x = 0; x < _scene.swarm.Count; x++)
                {
                    GameObject alienShip = _scene.swarm[x];
                    if (missile.GameObjectPlace.Equals(alienShip.GameObjectPlace))
                    {
                        _scene.swarm.RemoveAt(x);
                        _settings.AlienDestroyedCount++;

                        _scene.playerShipMissile.RemoveAt(i);

                        Console.Beep(700, 300);

                    }
                }

                for (int j = 0; j < _scene.alienShipMissile.Count; j++)
                {
                    GameObject alienMissile = _scene.alienShipMissile[j];
                    if (missile.GameObjectPlace.Equals(alienMissile.GameObjectPlace))
                    {
                        _scene.alienShipMissile.RemoveAt(j);

                        _scene.playerShipMissile.RemoveAt(i);

                        Console.Beep(700, 300);

                    }
                }
            }
        }

        private void CalculateAlienMissileMove()
        {
            for (int i = 0; i < _scene.alienShipMissile.Count; i++)
            {
                GameObject alienMissile = _scene.alienShipMissile[i];

                if (alienMissile.GameObjectPlace.YCordinate == 22)
                {
                    _scene.alienShipMissile.RemoveAt(i);
                }

                alienMissile.GameObjectPlace.YCordinate++;
                for (int x = 0; x < _scene.ground.Count; x++)
                {
                    GameObject groundPiece = _scene.ground[x];
                    if (alienMissile.GameObjectPlace.Equals(groundPiece.GameObjectPlace))
                    {
                        _scene.ground.RemoveAt(x);
                        _settings.GroundIsNotDestroyedCount--;

                        _scene.alienShipMissile.RemoveAt(i);

                        Console.Beep(700, 300);

                    }
                    else if (alienMissile.GameObjectPlace.Equals(_scene.playerShip.GameObjectPlace))
                    {

                        _isNotOver = false;

                        Console.Beep(700, 300);
                    }

                }
            }
        }

        private bool CanShootChecker(AlienShip alienShooter)
        {
            foreach (AlienShip alienShip in _scene.swarm)
            {
                if (alienShooter.GameObjectPlace.XCordinate == alienShip.GameObjectPlace.XCordinate && 
                    alienShooter.GameObjectPlace.YCordinate < alienShip.GameObjectPlace.YCordinate)
                {
                    return false;
                }
            }
            return true;
        }

        public void ExitGame()
        {
            Environment.Exit(0);
        }

        public void PauseGame()
        {
            _isNotPaused = !_isNotPaused;
        }

        public void StatePauseGame()
        {
            if (_isNotPaused == false)
            {
                Console.WriteLine("Game is on Pause, press p to continue");
                while (_isNotPaused == false)
                {
                    Thread.Sleep(100);
                }
            }
        }

        private void CalculateScore()
        {
            _settings.ScoreCount += 100 * _settings.AlienDestroyedCount + 50 * _settings.GroundIsNotDestroyedCount;
        }

       /* public void RestartGame()
        {
            Console.Clear();

            _isNotOver = false;
            Thread.Sleep(200); 
            
            Scene.ResetScene();
            _scene = Scene.GetScene(_settings);


            _settings.AlienDestroyedCount = 0;
            _settings.GroundIsNotDestroyedCount = 0;
            _settings.ScoreCount = 0;

            _sceneRender = new SceneRender(_settings);

            
            _isNotOver = true;
            _isNotPaused = true;

            
            Thread shootingThread = new Thread(AlienShot);
            shootingThread.Start();
            
            Run(_settings);
        }*/


    }
}
