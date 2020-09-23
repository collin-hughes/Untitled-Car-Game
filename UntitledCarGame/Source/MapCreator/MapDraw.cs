using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Collections.Generic;
using System.Linq;
using System.IO;

using VelcroPhysics.Dynamics;
using VelcroPhysics.Utilities;

using UntitledCarGame;
using UntitledCarGame.GameManagement;
using UntitledCarGame.Physics;
using UntitledCarGame.UI;

namespace UntitledCarGame.MapCreator
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class MapDraw : IScene
	{
		private UICanvas canvas;
		private Button mainMenu;

		public static World world;

		private PlayerObject playerOne;
		private PlayerObject playerTwo;
		private Texture2D playerTexture;

		int iterator = 0;
		int mapWidth;
		int mapHeight;

		SpriteBatch spriteBatch;

		//Called information
		List<Images> tileImages = new List<Images>();
		List<Layer> layerList = new List<Layer>();
		List<LayerStruct> cvsData = new List<LayerStruct>();
		List<Gid> gidList = new List<Gid>();
		List<Collision> objectList = new List<Collision>();

		//New lists
		List<Texture2D> images = new List<Texture2D>();
		
		List<BoxColliderObject> boxColliders = new List<BoxColliderObject>();


		private bool isTwoPlayers;

		private string mapFileName;
		private string carInstructionOne;
		private string carInstructionTwo;

		public void SetMapFileName(string _name)
		{
			mapFileName = _name;
		}

		public void SetTwoPlayerFlag(bool _flag)
		{
			isTwoPlayers = _flag;
		}

		public void SetCarInstructionOne(string _carInstructionFile)
		{
			carInstructionOne = _carInstructionFile;
		}

		public void SetCarInstructionTwo(string _carInstructionFile)
		{
			carInstructionTwo = _carInstructionFile;
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		public void LoadSceneData()
		{
			TileMap map = new TileMap(mapFileName);

			//Gets map height and width
			mapWidth = map.mapWidth();
			mapHeight = map.mapHeight();

			//Sets map height and width values to framework
			UntitiledCarGame.instance.ChangeWindowDimensions(mapWidth, mapHeight);

			// TODO: Add your initialization logic here
			tileImages = map.imagesList();
			layerList = map.layerList();
			cvsData = map.cvsList();
			gidList = map.gidList();
			objectList = map.objectList();

			world = new World(new Vector2(0f));

			//Set the scale for VelcroPhysics
			//1 meter = 32 pixels 
			ConvertUnits.SetDisplayUnitToSimUnitRatio(32f);

			UntitiledCarGame.instance.LoadFromPipeline<Texture2D>("car_blue", ref playerTexture);

			// Creation of Player Instance
			playerOne = new PlayerObject(world, carInstructionOne, playerTexture, new Vector2(200, 300), Orientation.north, .5f, 1f, .5f, 10f);

			if (isTwoPlayers)
			{
				playerTwo = new PlayerObject(world, carInstructionTwo, playerTexture, new Vector2(200, 300), Orientation.north, .5f, 1f, .5f, 10f);
			}

			else
			{
				playerTwo = null;
			}

			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(UntitiledCarGame.instance.GraphicsDevice);

			int index = tileImages.Count();
			for (iterator = 0; iterator < index; iterator++)
			{

				FileStream filestream = new FileStream(Path.Combine(map.mapDirectory, tileImages[iterator].getimageSource()), FileMode.Open);
				Texture2D pictures = Texture2D.FromStream(UntitiledCarGame.instance.GraphicsDevice, filestream);
				images.Add(pictures);
				filestream.Close();
			}

			for (int index2 = 0; index2 < objectList.Count(); index2++)
			{
				boxColliders.Add(new BoxColliderObject(world, new Vector2((int)objectList[index2].objWidth(), (int)objectList[index2].objHeight()), new Vector2((int)objectList[index2].objXvalue() + (int)objectList[index2].objWidth() / 2, (int)objectList[index2].objYvalue() + (int)objectList[index2].objHeight() / 2)));
			}

			canvas = new UICanvas();
			mainMenu = new Button(ref canvas, UntitiledCarGame.instance.LoadFromPipeline<SpriteFont>("ui/arial"), UntitiledCarGame.instance.LoadFromPipeline<Texture2D>("ui/default_button"), new Vector2(100, mapHeight - 50));

			mainMenu.SetText("Main Menu");
			mainMenu.SetEventToRun(UntitiledCarGame.instance.SceneChangeToMainMenu);
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		public void UnloadSceneData()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		public void UpdateSceneData(GameTime gameTime)
		{
			// OnUpdate calls follow here
			playerOne.OnUpdate();

			if (playerTwo != null)
			{
				playerTwo.OnUpdate();
			}

			mainMenu.OnHover(Mouse.GetState());
			mainMenu.OnClick(Mouse.GetState());

			// Update Physics
			world.Step((float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.001f);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		public void DrawSceneData(SpriteBatch spriteBatch)
		{
			//Need to get layer data and then assign images to positions according
			// To data numbers corresponding to images (0 is empty so starts at 1)
			//Get that position and draw image according to image there 

			foreach (LayerStruct layer in cvsData)
			{
				for (int y = 0; y < layer.height; y++)
				{
					for (int x = 0; x < layer.width; x++)
					{
						if (layer.layerData[x, y] > 0)
						{
							spriteBatch.Draw(images[layer.layerData[x, y] - 1], new Vector2(x * 32, y * 32), Color.White);
						}

					}
				}
			}

			playerOne.OnDraw(spriteBatch);


			if (playerTwo != null)
			{
				playerTwo.OnDraw(spriteBatch);
			}

			mainMenu.OnDraw(spriteBatch);
		}
	}
}
