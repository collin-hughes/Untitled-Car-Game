using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.IO;

using UntitledCarGame.UI;
using UntitledCarGame.GameManagement;
using UntitledCarGame.Exceptions;

namespace UntitledCarGame.Menus
{
	class SetupMenu : IScene
	{
		private UICanvas canvas;

		private Textbox menuLabel;
		private Textbox mapFileLabel;
		private Textbox mapFilePrompt;
		private Textbox carSelectLabel;
		private Textbox oneCarSelectLabel;
		private Textbox twoCarSelectLabel;
		private Textbox carInstructionLabel;
		private Textbox firstCarInstructionPrompt;
		private Textbox secondCarInstructionPrompt;

		private Textbox invalidMapFileWarning;
		private Textbox invalidInstructionWarning;

		private InputTextbox mapFileInput;
		private InputTextbox firstCarInstructionInput;
		private InputTextbox secondCarInstructionInput;

		private RadioButtonController carSelectController;

		private RadioButton oneCarSelect;
		private RadioButton twoCarSelect;

		private Button startRace;
		private Button mainMenu;


		public void LoadSceneData()
		{
			UntitiledCarGame.instance.ChangeWindowDimensions(1280, 720);

			canvas = new UICanvas();
			carSelectController = new RadioButtonController();

			menuLabel = new Textbox(ref canvas, UntitiledCarGame.instance.LoadFromPipeline<SpriteFont>("ui/arial"), new Vector2(116, 50));
			mapFileLabel = new Textbox(ref canvas, UntitiledCarGame.instance.LoadFromPipeline<SpriteFont>("ui/arial"), new Vector2(150, 100));
			mapFilePrompt = new Textbox(ref canvas, UntitiledCarGame.instance.LoadFromPipeline<SpriteFont>("ui/arial"), new Vector2(200, 150));
			carSelectLabel = new Textbox(ref canvas, UntitiledCarGame.instance.LoadFromPipeline<SpriteFont>("ui/arial"), new Vector2(175, 250));
			oneCarSelectLabel = new Textbox(ref canvas, UntitiledCarGame.instance.LoadFromPipeline<SpriteFont>("ui/arial"), new Vector2(200, 300));
			twoCarSelectLabel = new Textbox(ref canvas, UntitiledCarGame.instance.LoadFromPipeline<SpriteFont>("ui/arial"), new Vector2(350, 300));
			carInstructionLabel = new Textbox(ref canvas, UntitiledCarGame.instance.LoadFromPipeline<SpriteFont>("ui/arial"), new Vector2(190, 400));
			firstCarInstructionPrompt = new Textbox(ref canvas, UntitiledCarGame.instance.LoadFromPipeline<SpriteFont>("ui/arial"), new Vector2(265, 450));
			secondCarInstructionPrompt = new Textbox(ref canvas, UntitiledCarGame.instance.LoadFromPipeline<SpriteFont>("ui/arial"), new Vector2(265, 500));


			invalidMapFileWarning = new Textbox(ref canvas, UntitiledCarGame.instance.LoadFromPipeline<SpriteFont>("ui/arial"), new Vector2(450, 100), Color.Red, _enabled: false);
			invalidInstructionWarning = new Textbox(ref canvas, UntitiledCarGame.instance.LoadFromPipeline<SpriteFont>("ui/arial"), new Vector2(575, 400), Color.Red, _enabled: false);


			mapFileInput = new InputTextbox(ref canvas, UntitiledCarGame.instance.LoadFromPipeline<SpriteFont>("ui/arial"), UntitiledCarGame.instance.LoadFromPipeline<Texture2D>("ui/default_input_textbox"), UntitiledCarGame.instance.LoadFromPipeline<Texture2D>("ui/default_button"), new Vector2(450, 150));
			firstCarInstructionInput = new InputTextbox(ref canvas, UntitiledCarGame.instance.LoadFromPipeline<SpriteFont>("ui/arial"), UntitiledCarGame.instance.LoadFromPipeline<Texture2D>("ui/default_input_textbox"), UntitiledCarGame.instance.LoadFromPipeline<Texture2D>("ui/default_button"), new Vector2(575, 450));
			secondCarInstructionInput = new InputTextbox(ref canvas, UntitiledCarGame.instance.LoadFromPipeline<SpriteFont>("ui/arial"), UntitiledCarGame.instance.LoadFromPipeline<Texture2D>("ui/default_input_textbox"), UntitiledCarGame.instance.LoadFromPipeline<Texture2D>("ui/default_button"), new Vector2(575, 500));

			oneCarSelect = new RadioButton(ref canvas, UntitiledCarGame.instance.LoadFromPipeline<Texture2D>("ui/default_radio_button"), UntitiledCarGame.instance.LoadFromPipeline<Texture2D>("ui/default_radio_button_enabled"), true, ref carSelectController, new Vector2(150, 300));
			twoCarSelect = new RadioButton(ref canvas, UntitiledCarGame.instance.LoadFromPipeline<Texture2D>("ui/default_radio_button"), UntitiledCarGame.instance.LoadFromPipeline<Texture2D>("ui/default_radio_button_enabled"), false, ref carSelectController, new Vector2(300, 300));

			startRace = new Button(ref canvas, UntitiledCarGame.instance.LoadFromPipeline<SpriteFont>("ui/arial"), UntitiledCarGame.instance.LoadFromPipeline<Texture2D>("ui/default_button"), new Vector2(300, 600), _interactable: false);
			mainMenu = new Button(ref canvas, UntitiledCarGame.instance.LoadFromPipeline<SpriteFont>("ui/arial"), UntitiledCarGame.instance.LoadFromPipeline<Texture2D>("ui/default_button"), new Vector2(600, 600));


			menuLabel.SetText("Setup Game");

			mapFileLabel.SetText("Select Map File");
			mapFilePrompt.SetText("Enter Map File Name");

			carSelectLabel.SetText("Select Number of Cars");
			oneCarSelectLabel.SetText("One Car");
			twoCarSelectLabel.SetText("Two Cars");

			invalidMapFileWarning.SetText("Map File Does Not Exist");
			invalidInstructionWarning.SetText("Instruction File Does Not Exist");

			carInstructionLabel.SetText("Select Car Instruction File");
			firstCarInstructionPrompt.SetText("Enter Car One Instructions File Name");
			secondCarInstructionPrompt.SetText("Enter Car Two Instructions File Name");

			startRace.SetText("Start Race");
			mainMenu.SetText("Main Menu");

			startRace.SetEventToRun(PrepareForLevelLoading);
			mainMenu.SetEventToRun(UntitiledCarGame.instance.SceneChangeToMainMenu);
	}

		public void UnloadSceneData()
		{

		}

		public void UpdateSceneData(GameTime _gameTime)
		{
			if(twoCarSelect.IsSelected())
			{
				secondCarInstructionInput.SetInteractable(true);
			}

			else
			{
				secondCarInstructionInput.SetInteractable(false);
			}

			if((String.Compare("", mapFileInput.GetText()) != 0) && (String.Compare("", firstCarInstructionInput.GetText()) != 0) && ((String.Compare("", secondCarInstructionInput.GetText()) != 0|| !twoCarSelect.IsSelected())))
			{
				startRace.SetInteractable(true);
			}

			else
			{
				startRace.SetInteractable(false);
			}

			mapFileInput.OnHover(Mouse.GetState());
			mapFileInput.OnClick(Mouse.GetState());

			firstCarInstructionInput.OnHover(Mouse.GetState());
			firstCarInstructionInput.OnClick(Mouse.GetState());

			secondCarInstructionInput.OnHover(Mouse.GetState());
			secondCarInstructionInput.OnClick(Mouse.GetState());

			oneCarSelect.OnHover(Mouse.GetState());
			oneCarSelect.OnClick(Mouse.GetState());

			twoCarSelect.OnHover(Mouse.GetState());
			twoCarSelect.OnClick(Mouse.GetState());

			startRace.OnHover(Mouse.GetState());
			startRace.OnClick(Mouse.GetState());

			mainMenu.OnHover(Mouse.GetState());
			mainMenu.OnClick(Mouse.GetState());
		}

		public void DrawSceneData(SpriteBatch _spriteBatch)
		{
			menuLabel.OnDraw(_spriteBatch);
			mapFileLabel.OnDraw(_spriteBatch);
			mapFilePrompt.OnDraw(_spriteBatch);
			carSelectLabel.OnDraw(_spriteBatch);
			oneCarSelectLabel.OnDraw(_spriteBatch);
			twoCarSelectLabel.OnDraw(_spriteBatch);
			carInstructionLabel.OnDraw(_spriteBatch);
			firstCarInstructionPrompt.OnDraw(_spriteBatch);
			secondCarInstructionPrompt.OnDraw(_spriteBatch);

			invalidMapFileWarning.OnDraw(_spriteBatch);
			invalidInstructionWarning.OnDraw(_spriteBatch);

			mapFileInput.OnDraw(_spriteBatch);
			firstCarInstructionInput.OnDraw(_spriteBatch);
			secondCarInstructionInput.OnDraw(_spriteBatch);

			oneCarSelect.OnDraw(_spriteBatch);
			twoCarSelect.OnDraw(_spriteBatch);

			startRace.OnDraw(_spriteBatch);
			mainMenu.OnDraw(_spriteBatch);
		}

		public void PrepareForLevelLoading()
		{
			string mapFile;
			string mapDirectory;
			string playerOneInstructions;
			string playerTwoInstructions;

			int extensionDelimiter;

			try
			{
				if((extensionDelimiter = mapFileInput.GetText().LastIndexOf('.')) == -1)
				{
					throw new Exception();
				}

				else
				{
					mapDirectory = mapFileInput.GetText().Substring(0, extensionDelimiter);
				}
			}

			catch
			{
				mapDirectory = "";
				invalidMapFileWarning.SetEnabled(false);
			}

			mapFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content", "maps", mapDirectory, mapFileInput.GetText());

			playerOneInstructions = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content", "instructions", firstCarInstructionInput.GetText());
			playerTwoInstructions = "";

			try
			{
				if (!File.Exists(mapFile))
				{
					throw new InvalidMapFileException();
				}

				else
				{
					invalidMapFileWarning.SetEnabled(false);
				}

				try
				{
					if (!File.Exists(playerOneInstructions))
					{
						throw new InvalidInstructionFileException();
					}

					else
					{
						invalidInstructionWarning.SetEnabled(false);
					}

					if (twoCarSelect.IsSelected())
					{
						playerTwoInstructions = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content", "instructions", secondCarInstructionInput.GetText());

						if (!File.Exists(playerTwoInstructions))
						{
							throw new InvalidInstructionFileException();
						}

						else
						{
							invalidInstructionWarning.SetEnabled(false);
						}
					}

					try
					{
						UntitiledCarGame.instance.SceneChangeToLevel(mapFile, playerOneInstructions, playerTwoInstructions, twoCarSelect.IsSelected());
					}

					catch
					{
						Console.WriteLine("Unable to load map. Returning to main menu...");
						UntitiledCarGame.instance.SceneChangeToMainMenu();
					}
				}

				catch
				{
					invalidInstructionWarning.SetEnabled(true);
				}
			}

			catch
			{
				invalidMapFileWarning.SetEnabled(true);
			}
		}
	}
}
