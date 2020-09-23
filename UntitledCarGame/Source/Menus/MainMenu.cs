using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using UntitledCarGame.UI;
using UntitledCarGame.GameManagement;

namespace UntitledCarGame.Menus
{
	class MainMenu : IScene
	{
		private UICanvas canvas;

		private UISprite logo;

		private Button startRaceButton;
		private Button optionsButton;
		private Button quitButton;

		private Textbox copyrightText;

		public void LoadSceneData()
		{
			UntitiledCarGame.instance.ChangeWindowDimensions(1280, 720);
			UntitiledCarGame.instance.IsMouseVisible = true;

			canvas = new UICanvas();

			logo = new UISprite(ref canvas, UntitiledCarGame.instance.LoadFromPipeline<Texture2D>("ui/untitled_car_game_logo"), new Vector2(UntitiledCarGame.instance.GraphicsDevice.Viewport.Width / 2, (UntitiledCarGame.instance.GraphicsDevice.Viewport.Height / 2) - 50));
			startRaceButton = new Button(ref canvas, UntitiledCarGame.instance.LoadFromPipeline<SpriteFont>("ui/arial"), UntitiledCarGame.instance.LoadFromPipeline<Texture2D>("ui/default_button"), new Vector2((UntitiledCarGame.instance.GraphicsDevice.Viewport.Width / 2) - 164, (UntitiledCarGame.instance.GraphicsDevice.Viewport.Height / 2) + 150));
			optionsButton = new Button(ref canvas, UntitiledCarGame.instance.LoadFromPipeline<SpriteFont>("ui/arial"), UntitiledCarGame.instance.LoadFromPipeline<Texture2D>("ui/default_button"), new Vector2((UntitiledCarGame.instance.GraphicsDevice.Viewport.Width / 2), (UntitiledCarGame.instance.GraphicsDevice.Viewport.Height / 2) + 150), _interactable: false);
			quitButton = new Button(ref canvas, UntitiledCarGame.instance.LoadFromPipeline<SpriteFont>("ui/arial"), UntitiledCarGame.instance.LoadFromPipeline<Texture2D>("ui/default_button"), new Vector2((UntitiledCarGame.instance.GraphicsDevice.Viewport.Width / 2) + 164, (UntitiledCarGame.instance.GraphicsDevice.Viewport.Height / 2) + 150));
			copyrightText = new Textbox(ref canvas, UntitiledCarGame.instance.LoadFromPipeline<SpriteFont>("ui/arial"), new Vector2((UntitiledCarGame.instance.GraphicsDevice.Viewport.Width) - 256, (UntitiledCarGame.instance.GraphicsDevice.Viewport.Height) - 32));

			startRaceButton.SetText("New Race");
			optionsButton.SetText("Options");
			quitButton.SetText("Quit");

			copyrightText.SetText("(C) 2020 Brian Bennett, Brandon Louis, Collin Hughes, Peter Giovi");

			startRaceButton.SetEventToRun(UntitiledCarGame.instance.SceneChangeToSetup);
			optionsButton.SetEventToRun(UntitiledCarGame.instance.SceneChangeToOptions);
			quitButton.SetEventToRun(UntitiledCarGame.instance.Exit);
		}

		public void UnloadSceneData()
		{
		}

		public void UpdateSceneData(GameTime _gameTime)
		{
			startRaceButton.OnHover(Mouse.GetState());
			startRaceButton.OnClick(Mouse.GetState());

			optionsButton.OnHover(Mouse.GetState());
			optionsButton.OnClick(Mouse.GetState());

			quitButton.OnHover(Mouse.GetState());
			quitButton.OnClick(Mouse.GetState());
		}

		public void DrawSceneData(SpriteBatch _spriteBatch)
		{
			logo.OnDraw(_spriteBatch);

			startRaceButton.OnDraw(_spriteBatch);
			optionsButton.OnDraw(_spriteBatch);
			quitButton.OnDraw(_spriteBatch);

			copyrightText.OnDraw(_spriteBatch);
		}
	}
}
