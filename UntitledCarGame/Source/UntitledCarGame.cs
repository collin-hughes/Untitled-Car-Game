using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using VelcroPhysics.Dynamics;
using VelcroPhysics.Utilities;
using System;
using UntitledCarGame.GameManagement;
using UntitledCarGame.Menus;
using UntitledCarGame.MapCreator;

namespace UntitledCarGame
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class UntitiledCarGame : Game
	{
		private GraphicsDeviceManager graphics;

		private SpriteBatch spriteBatch;

		private GameStates gameState;
		private MainMenu mainMenu;
		private SetupMenu setupMenu;
		private OptionsMenu optionsMenu;
		private MapDraw level;

		public static UntitiledCarGame instance;

		public UntitiledCarGame()
		{
			if (instance != null)
			{
				Console.WriteLine("More than one instance of UntitledCarGame found!");
			}

			instance = this;

			graphics = new GraphicsDeviceManager(this);

			Content.RootDirectory = "Content";

			gameState = new GameStates();
			mainMenu = new MainMenu();
			setupMenu = new SetupMenu();
			optionsMenu = new OptionsMenu();
			level = new MapDraw();
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			base.Initialize();
		}

		public T LoadFromPipeline<T>(String assetName)
		{
			return this.Content.Load<T>(assetName);
		}

		public void LoadFromPipeline<T>(String assetName, ref T asset)
		{
			asset = this.Content.Load<T>(assetName);
		}

		public void SceneChangeToSetup()
		{
			gameState.LoadData(setupMenu);
		}

		public void SceneChangeToOptions()
		{
			gameState.LoadData(optionsMenu);
		}

		public void SceneChangeToMainMenu()
		{
			gameState.LoadData(mainMenu);
		}

		public void SceneChangeToLevel(string _mapFile, string _playerOneInstructions, string _playerTwoInstructions, bool _isTwoPlayer)
		{
			level.SetMapFileName(_mapFile);
			level.SetCarInstructionOne(_playerOneInstructions);
			level.SetCarInstructionTwo(_playerTwoInstructions);
			level.SetTwoPlayerFlag(_isTwoPlayer);

			gameState.LoadData(level);
		}

		public void ChangeWindowDimensions(int width, int height)
		{
			graphics.PreferredBackBufferWidth = width;
			graphics.PreferredBackBufferHeight = height;
			graphics.ApplyChanges();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
			gameState.LoadData(mainMenu);
        }

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here


		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
        {
			gameState.UpdateData(gameTime);

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.LightSlateGray);

			// Start of Sprite Batch
			spriteBatch.Begin();

			gameState.DrawData(spriteBatch);

            // End of Sprite Batch
            spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
