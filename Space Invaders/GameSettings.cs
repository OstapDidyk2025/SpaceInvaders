
namespace Space_Invaders
{
    internal class GameSettings
    {
        public int ConsoleHeight { get; set; } = 30;
        public int ConsoleWidth { get; set; } = 80;

        //-------------------------------------------------
        public int AlienShipRow { get; set; } = 2;
        public int AlienShipColumn { get; set; } = 25;
        public int AlienShipXCordinate { get; set; } = 10;
        public int AlienShipYCordinate { get; set; } = 2;
        public char AlienShipFigure { get; set; } = '\u028A';
        public int SwarmSpeed { get; set; } = 50;

        //-------------------------------------------------

        public int PlayerShipXCordinate { get; set; } = 40;
        public int PlayerShipYCordinate { get; set; } = 20;
        public char PlayerShipFigure { get; set; } = '\u03EA';

        //-------------------------------------------------

        public int GroundObjectRow { get; set; } = 1;
        public int GroundObjectColumn { get; set; } = 80;
        public int GroundObjectXCordinate { get; set; } = 1;
        public int GroundObjectYCordinate { get; set; } = 21;
        public char GroundObjectFigure { get; set; } = '\u039E';

        //-------------------------------------------------

        public char PlayerMissileFigure { get; set; } = '.';
        public int PlayerMissileSpeed { get; set; } = 10;

        //-------------------------------------------------

        public int GameSpeed { get; set; } = 100;

        //-------------------------------------------------
    
        public int ScoreCount { get; set; } = 0;
        public int AlienDestroyedCount { get; set; } = 0;
        public int GroundIsNotDestroyedCount { get; set; } = 80;


        //-------------------------------------------------

        public char AlienMissileFigure { get; set; } = '*';
        public int AlienMissileSpeed { get; set; } = 5;
    }
}
