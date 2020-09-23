using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Text;

namespace UntitledCarGame.UI
{
	class InputTextbox : Textbox
	{
		string submittedText;

		StringBuilder builder;

		Button submitButton;

		public InputTextbox(ref UICanvas _canvas, SpriteFont _font, Texture2D _sprite, Texture2D _buttonSprite, Vector2 _position, float _rotation = 0f, bool _enabled = true, bool _interactable = true) :
			base(ref _canvas, _font, _sprite, _position, _rotation, _enabled, _interactable)
		{
			builder = new StringBuilder();
			submittedText = "";
			UntitiledCarGame.instance.Window.TextInput += ChangeText;

			submitButton = new Button(ref _canvas, _font, _buttonSprite, new Vector2(_position.X + sprite.GetSize().X / 2 + _buttonSprite.Width / 2 + 16, _position.Y), _rotation, _enabled, _interactable);
			submitButton.SetEventToRun(this.SetText, this.Deactivate);
			submitButton.SetText("Submit");
		}

		public InputTextbox(ref UICanvas _canvas, SpriteFont _font, Texture2D _sprite, Texture2D _buttonSprite, Vector2 _position, Color _color, float _rotation = 0f, bool _enabled = true, bool _interactable = true) :
			base(ref _canvas, _font, _sprite, _position, _color, _rotation, _enabled, _interactable)
		{
			builder = new StringBuilder();
			submittedText = "";
			UntitiledCarGame.instance.Window.TextInput += ChangeText;

			submitButton = new Button(ref _canvas, _font, _buttonSprite, new Vector2(_position.X + sprite.GetSize().X / 2 + _buttonSprite.Width / 2 + 16, _position.Y), _color, _rotation, _enabled, _interactable);
			submitButton.SetEventToRun(this.SetText, this.Deactivate);
			submitButton.SetText("Submit");
		}

		public void ChangeText(object sender, TextInputEventArgs e)
		{
			if (active)
			{
				if (e.Key == Keys.Back)
				{
					if (builder.Length > 0)
						builder.Remove(builder.Length - 1, 1);
				}

				else if (e.Key == Keys.Enter)
				{
					SetText();
				}

				else
				{
					if (char.IsLetter(e.Character) || char.IsDigit(e.Character) || char.IsPunctuation(e.Character) || char.IsSymbol(e.Character))
					{
						builder.Append(e.Character);
					}
				}

				text = builder.ToString();
			}
		}

		public new void SetInteractable(bool _interactable)
		{
			interactable = _interactable;


			sprite.SetInteractable(_interactable);
			submitButton.SetInteractable(_interactable);

		}

		public void Deactivate()
		{
			canvas.DeactivateElement(this);
		}

		public new void ToggleInteractable()
		{
			SetInteractable(!interactable);
		}

		public void SetText()
		{
			submittedText = text;
		}

		public string GetText()
		{
			return submittedText;
		}

		public bool IsHovering(MouseState _mouseState)
		{
			if ((_mouseState.Position.X < position.X + (GetCenter().X))
				&& (_mouseState.Position.X > position.X - (GetCenter().X))
				&& (_mouseState.Position.Y < position.Y + (GetCenter().Y))
				&& (_mouseState.Position.Y > position.Y - (GetCenter().Y)))
			{
				return true;
			}

			else
			{
				return false;
			}
		}

		public void OnHover(MouseState _mouseState)
		{
			if (IsInteractable())
			{
				if (IsHovering(_mouseState))
				{
					color = Color.LightGray;
					SetColor(color);
				}

				else
				{
					color = Color.White;
					SetColor(color);
				}
			}

			submitButton.OnHover(_mouseState);

		}

		public void OnClick(MouseState _mouseState)
		{
			if ((IsHovering(_mouseState) && IsInteractable() && _mouseState.LeftButton == ButtonState.Pressed))
			{
				canvas.SetActiveElement(this);
				text = "";
				builder.Clear();
			}

			submitButton.OnClick(_mouseState);
		}

		public override void OnDraw(SpriteBatch _spriteBatch)
		{
			base.OnDraw(_spriteBatch);
			submitButton.OnDraw(_spriteBatch);
		}
	}
}
