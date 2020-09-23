using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VelcroPhysics.Dynamics;
using VelcroPhysics.Factories;
using VelcroPhysics.Utilities;

namespace UntitledCarGame.Physics
{
	//==================================================================================================
	// BoxColliderObject        Class for creating BoxColliderObjects. Inherits GameObject class.
	//                          These are rectangular physics objects. They can have 3 body types:
	//                              - Static: Unmoving, Unaffected by Physics
	//                              - Kinematic: Moving, Unaffected by Physics and Collision
	//                              - Dynamic: Moving, Affected by Physics and Collision
	//                          All objects in the world should either be static or dynamic. All bodies
	//                          can be collided with. 
	//==================================================================================================
	class BoxColliderObject : GameObject
	{
		protected Body collisionBody;

        //==============================================================================================
        // BoxColliderObject        Constructor for BoxColliderObject. Creates a collider object with a
        //                          position, texture and a body type. Uses a world object to create
        //                          the body and sprite dimensions and position. Body type can be Static,
        //                          Kinematic or Dynamic.
        //
        // Input                    World Object, Texture, Position, BodyType, Orientation
        //
        // Output                   N/A
        //==============================================================================================
		public BoxColliderObject(World _world, Texture2D _sprite, Vector2 _position, BodyType _bodyType, Orientation _orientation = Orientation.north) : base(_position, _sprite, _orientation)
		{
            //Create a rectangular physics body
			collisionBody = BodyFactory.CreateRectangle(_world, ConvertUnits.ToSimUnits(sprite.Width), ConvertUnits.ToSimUnits(sprite.Height), 1f, ConvertUnits.ToSimUnits(_position), 0f, _bodyType, null);
		}

		public BoxColliderObject(World _world, Vector2 _dimensions, Vector2 _position) : base(_position, null, Orientation.north)
		{
			//Create a rectangular physics body
			collisionBody = BodyFactory.CreateRectangle(_world, ConvertUnits.ToSimUnits(_dimensions.X), ConvertUnits.ToSimUnits(_dimensions.Y), 1f, ConvertUnits.ToSimUnits(_position), 0f, BodyType.Static, null);
		}

		//==============================================================================================
		// OnUpdate                 Method for updating BoxColliderObject. Should be called from Update 
		//                          method in main game class.
		//
		// Input                    N/A
		//
		// Output                   N/A
		//==============================================================================================
		public new void OnUpdate()
		{
			return;
		}

        //==============================================================================================
        // OnDraw                   Method for drawing texture on the screen. Uses a sprite batch that
        //                          is passed in, should be main sprite batch. Called from Draw method
        //                          in main game class
        //
        // Input                    Sprite Batch
        //
        // Output                   N/A
        //==============================================================================================
        public new void OnDraw(SpriteBatch _spriteBatch)
		{
			if(sprite != null)
			{
				//Draw the sprite on the screen at the object position
				_spriteBatch.Draw(sprite, ConvertUnits.ToDisplayUnits(collisionBody.Position), null, Color.White, collisionBody.Rotation, new Vector2(sprite.Width / 2, sprite.Height / 2), new Vector2(1f, 1f), SpriteEffects.None, 1f);

			}
		}




	}
}
