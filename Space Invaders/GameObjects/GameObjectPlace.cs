
namespace Space_Invaders
{
    internal class GameObjectPlace
    {
        public int XCordinate { get; set; }
        public int YCordinate { get; set; }

        public override bool Equals(object obj)
        {
            GameObjectPlace newObject = obj as GameObjectPlace;

            if ( newObject != null 
                && this.XCordinate == newObject.XCordinate
                && this.YCordinate == newObject.YCordinate 
                ) 
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
