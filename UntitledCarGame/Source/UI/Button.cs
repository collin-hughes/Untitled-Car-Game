using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace UntitledCarGame.UI
{
	class Button : UIElement
	{
		private Textbox buttonText;

		private Action[] eventsToRun;
		private bool isPressed;

		public Button(ref UICanvas _canvas, SpriteFont _font, Texture2D _sprite, Vector2 _position, float _rotation = 0f, bool _enabled = true, bool _interactable = true) :
			base(ref _canvas, _position, Color.White, _rotation, _enabled, _interactable)
		{
			buttonText = new Textbox(ref _canvas, _font, _sprite, _position, _rotation, _enabled, _interactable);
		}

		public Button(ref UICanvas _canvas, SpriteFont _font, Texture2D _sprite, Vector2 _position, Color _color, float _rotation = 0f, bool _enabled = true, bool _interactable = true) :
			base(ref _canvas, _position, _color, _rotation, _enabled, _interactable)
		{
			buttonText = new Textbox(ref _canvas, _font, _sprite, _position, _color, _rotation, _enabled, _interactable);
		}

		public void SetSprite(Texture2D _sprite)
		{
			buttonText.SetSprite(_sprite);
		}
				
		public void SetEventToRun(params Action[] _eventsToRun)
		{
			eventsToRun = _eventsToRun;
		}

		public void SetText(string _text)
		{
			buttonText.SetText(_text);
		}

		public bool IsHovering(MouseState _mouseState)
		{
			if ((_mouseState.Position.X < position.X + (buttonText.GetCenter().X)) 
				&& (_mouseState.Position.X > position.X - (buttonText.GetCenter().X)) 
				&& (_mouseState.Position.Y < position.Y + (buttonText.GetCenter().Y)) 
				&& (_mouseState.Position.Y > position.Y - (buttonText.GetCenter().Y)))
			{
				return true;
			}

			else
			{
				return false;
			}
		}

		public new void SetInteractable(bool _interactable)
		{
			interactable = _interactable;

			buttonText.SetInteractable(_interactable);

		}

		public new void ToggleInteractable()
		{
			SetInteractable(!interactable);
		}

		public void OnHover(MouseState _mouseState)
		{
			if (IsInteractable())
			{
				if (IsHovering(_mouseState))
				{
					color = Color.LightGray;
					buttonText.SetColor(color);
				}

				else
				{
					color = Color.White;
					buttonText.SetColor(color);
				}
			}

		}

		public void OnClick(MouseState _mouseState)
		{
			if ((IsHovering(_mouseState) && IsInteractable() && _mouseState.LeftButton == ButtonState.Pressed))
			{
				isPressed = true;

				color = Color.Gray;
				buttonText.SetColor(color);
			}

			else if ((IsHovering(_mouseState) && IsInteractable() && isPressed && _mouseState.LeftButton == ButtonState.Released))
			{
				foreach (Action eventToRun in eventsToRun)
				{
					eventToRun();
				}

				isPressed = false;
			}

			else
			{
				isPressed = false;
			}
		}

		public override void OnDraw(SpriteBatch _spriteBatch)
		{
			if(IsEnabled())
			{
				buttonText.OnDraw(_spriteBatch);
			}
		}
	}
}
