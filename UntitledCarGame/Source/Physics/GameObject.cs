using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UntitledCarGame.Physics
{
	//==================================================================================================
	// Orientation				Enum for defining which direction a game object is facing.
	//==================================================================================================
	enum Orientation
	{
		north, south, east, west
	};

	//==================================================================================================
	// GameObject               Base class for all game objects. Contains a position, a sprite and an
	//							orientation
	//==================================================================================================
	abstract class GameObject
    {
        protected Vector2 position;
		protected Vector2 forwardVector;

		protected Texture2D sprite;

		//==============================================================================================
		// GameObject               Constructor for GameObject. Creates an object with a position, a
		//                          texture and an orientation. All methods should be overrriden or 
		//							replaced.
		//
		// Input                    Texture, Position, Orientation
		//
		// Output                   N/A
		//==============================================================================================
		public GameObject(Vector2 _position, Texture2D _sprite, Orientation _orientation)
        {
            //Set the position and orientation
            position = _position;
            sprite = _sprite;

            //Determine the forward vector based on the sprite orientation
			switch (_orientation)
			{
				case Orientation.north:
					forwardVector = new Vector2(0f, -1f);
					break;
				case Orientation.south:
					forwardVector = new Vector2(0f, 1f);
					break;
				case Orientation.east:
					forwardVector = new Vector2(-1f, 0f);
					break;
				case Orientation.west:
					forwardVector = new Vector2(1f, 0f);
					break;
			}
		}

        //==============================================================================================
        // OnUpdate                 Method for updating GameObject. Should be called from Update 
        //                          method in main game class. Should be replaced by child class.
        //
        // Input                    N/A
        //
        // Output                   N/A
        //==============================================================================================
        public void OnUpdate()
        {
            return;
        }

        //==============================================================================================
        // OnDraw                   Method for drawing texture on the screen. Uses a sprite batch that
        //                          is passed in, should be main sprite batch. Called from Draw method
        //                          in main game class. Should be replaced by child class.
        //
        // Input                    Sprite Batch
        //
        // Output                   N/A
        //==============================================================================================
        public void OnDraw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(sprite, position, Color.White);
        }
    }
}
