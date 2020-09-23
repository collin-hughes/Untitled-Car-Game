using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VelcroPhysics.Dynamics;
using VelcroPhysics.Factories;
using VelcroPhysics.Utilities;

using System;

using UntitledCarGame.Interface;

namespace UntitledCarGame.Physics
{
	//==================================================================================================
	// PlayerObject             Class for creating PlayerObjects. Inherits BoxColliderObject class. 
	//							These are physics objects with dynamic bodies, allowing them to be
	//							manipulated with forces. The car can accelerate, steer and brake.
	//							They also have stats:
	//								- Braking: 		How long it takes the car to slow when no longer
	//												accelerating or when the brake is pressed.
	//												Higher values -> Faster stopping
	//								- Handling:		How tight the car turns, and how much the car 
	//												rotates when the wheel is turned.
	//												Higher values -> Tighter turns, less rotation
	//								- Mass:			How much force is required to move the car
	//												Higher values -> More force required
	//								- Acceleration:	How much extra power the engine gives the car to
	//												accelerate forward.
	//												Higher values -> Faster car
	//==================================================================================================
	class PlayerObject : BoxColliderObject
	{
		private ProgrammingInterface programmingInterface;

		private float acceleration;

		//==============================================================================================
		// PlayerObject             Constructor for Player. Creates an object in the game world with a 
		//                          sprite, position, orientation and stats for braking, handling, mass
		//                          and acceleration. Calls the BoxCollider constructor using a dynamic
		//                          body.
		//
		// Input                    World, Sprite, Position, Orientation, Braking, Handling, Mass,
		//                          Acceleration
		//
		// Output                   N/A
		//==============================================================================================
		public PlayerObject(World _world, String _fileName, Texture2D _sprite, Vector2 _position, Orientation _orientation, float _braking, float _handling, float _mass, float _acceleration) : base(_world, _sprite, _position, BodyType.Dynamic, _orientation)
		{
			programmingInterface = new ProgrammingInterface();
			programmingInterface.GiveFilepath(_fileName);

			SetStats(_braking, _handling, _mass, _acceleration);
		}

		//==============================================================================================
		// OnUpdate                 Method for updating Player data each update call. Passed a vector2
		//                          containing data for moving the player. The x component handles
		//                          steering and the y component handles acceleration. Each component
		//                          should be in a range of -1f to 1f. Should be called in the Update
		//                          method of the main class.
		//
		// Input                    MoveInput, BrakeValue
		//
		// Output                   N/A
		//==============================================================================================
		public void OnUpdate(Vector2 moveInput, float brakeValue)
		{
			Steer(moveInput.X);
			Accelerate(moveInput.Y);
			Brake(brakeValue);
		}

		public new void OnUpdate()
		{
			PlayerData playerData;

			playerData = programmingInterface.GetInstruction();

			Steer(playerData.moveInput.X);
			Accelerate(playerData.moveInput.Y);
			Brake(playerData.brkAmt);
		}

		//==============================================================================================
		// OnDraw                   Method for drawing Player on the screen each draw call. Converts the
		//                          player position to display units and draws it using that position, 
		//                          the body rotation, the center of the sprite as the origin and a scale
		//                          of 1.
		//
		// Input                    SpriteBatch
		//
		// Output                   N/A
		//==============================================================================================
		public new void OnDraw(SpriteBatch _spriteBatch)
		{
			_spriteBatch.Draw(sprite, ConvertUnits.ToDisplayUnits(collisionBody.Position), null, Color.White, collisionBody.Rotation, new Vector2(sprite.Width / 2, sprite.Height / 2), new Vector2(1f, 1f), SpriteEffects.None, 1f);
		}

		//==============================================================================================
		// SetStats                 Method for setting player stats. Converts player stats to attributes
		//                          for the physics body. Called from the constructor for the player
		//                          object
		//
		// Input                    Braking, Handling, Mass, Acceleration
		//
		// Output                   N/A
		//==============================================================================================
		public void SetStats(float _braking, float _handling, float _mass, float _acceleration)
		{
			collisionBody.LinearDamping = _braking;
			collisionBody.AngularDamping = _handling;
			collisionBody.Mass = _mass;
			acceleration = _acceleration;
		}

		//==============================================================================================
		// Accelerate               Method for accelerating the player. Takes in a direction value from 
		//                          -1f to 1f representing a percentage of the acceleration to use. 
		//                          A positive value corresponds to positive acceleration, and a
		//                          negative value corresponds to negative acceleration.
		//
		// Input                    Direction
		//
		// Output                   N/A
		//==============================================================================================
		public void Accelerate(float direction)
		{
			if (direction > 1f)
			{
				direction = 1;
			}

			else if (direction < -1f)
			{
				direction = -1f;
			}

			collisionBody.ApplyForce(collisionBody.GetWorldVector(forwardVector * direction * acceleration));
		}

		//==============================================================================================
		// Steer                    Method for steering the player. Takes in a direction value from 
		//                          -1f to 1f representing how many Nm of torque to apply.
		//                          A positive value corresponds to right turn, and a negative value
		//                          corresponds to a left turn.
		//
		// Input                    Direction
		//
		// Output                   N/A
		//==============================================================================================
		public void Steer(float direction)
		{
			if (direction > 1f)
			{
				direction = 1;
			}

			else if (direction < -1f)
			{
				direction = -1f;
			}

			collisionBody.ApplyTorque(direction);
		}

		//==============================================================================================
		// Brake                    Method for causing the car to brake. It does this by applying the
		//                          the negative of the velocity times the linear damping or braking 
		//                          time the brake value. The longer the brake is applied, the more the
		//                          body slows down.
		//
		// Input                    Brake Value
		//
		// Output                   N/A
		//==============================================================================================
		public void Brake(float brakeValue)
		{
			if (brakeValue > 1f)
			{
				brakeValue = 1;
			}

			else if (brakeValue < -1f)
			{
				brakeValue = -1f;
			}

			collisionBody.ApplyForce(new Vector2(-collisionBody.LinearVelocity.X * collisionBody.LinearDamping * brakeValue, -collisionBody.LinearVelocity.Y * collisionBody.LinearDamping * brakeValue));
		}
	}
}
