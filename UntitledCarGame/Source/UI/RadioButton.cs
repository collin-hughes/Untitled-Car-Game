using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UntitledCarGame.UI
{
	class RadioButton : UIElement
	{
		bool isSelected;

		RadioButtonController controller;

		Texture2D selectedSprite;
		Texture2D unselectedSprite;

		UISprite sprite;

		public RadioButton(ref UICanvas _canvas, Texture2D _unselectedSprite, Texture2D _selectedSprite, bool _isSelected, ref RadioButtonController _controller, Vector2 _position, float _rotation = 0f, bool _enabled = true, bool _interactable = true) :
			base(ref _canvas, _position, Color.White, _rotation, _enabled, _interactable)
		{
			isSelected = _isSelected;

			unselectedSprite = _unselectedSprite;
			selectedSprite = _selectedSprite;

			controller = _controller;

			controller.AddButton(this);

			if (isSelected)
			{
				sprite = new UISprite(ref _canvas, _selectedSprite, _position, _rotation, _enabled, _interactable);
			}

			else
			{
				sprite = new UISprite(ref _canvas, _unselectedSprite, _position, _rotation, _enabled, _interactable);
			}
		}

		public RadioButton(ref UICanvas _canvas, Texture2D _unselectedSprite, Texture2D _selectedSprite, bool _isSelected, ref RadioButtonController _controller, Vector2 _position, Color _color, float _rotation = 0f, bool _enabled = true, bool _interactable = true) :
			base(ref _canvas, _position, _color, _rotation, _enabled, _interactable)
		{
			isSelected = _isSelected;

			unselectedSprite = _unselectedSprite;
			selectedSprite = _selectedSprite;

			controller = _controller;

			controller.AddButton(this);

			if (isSelected)
			{
				sprite = new UISprite(ref _canvas, _selectedSprite, _position, _rotation, _enabled, _interactable);
			}

			else
			{
				sprite = new UISprite(ref _canvas, _unselectedSprite, _position, _rotation, _enabled, _interactable);
			}
		}

		public bool IsHovering(MouseState _mouseState)
		{
			if ((_mouseState.Position.X < position.X + (sprite.GetCenter().X))
				&& (_mouseState.Position.X > position.X - (sprite.GetCenter().X))
				&& (_mouseState.Position.Y < position.Y + (sprite.GetCenter().Y))
				&& (_mouseState.Position.Y > position.Y - (sprite.GetCenter().Y)))
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

			sprite.SetInteractable(_interactable);
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
					sprite.SetColor(color);
				}

				else
				{
					color = Color.White;
					sprite.SetColor(color);
				}
			}
		}

		public void OnClick(MouseState _mouseState)
		{
			if ((IsHovering(_mouseState) && IsInteractable() && _mouseState.LeftButton == ButtonState.Pressed))
			{
				isSelected = true;

				color = Color.Gray;
				sprite.SetColor(color);

				controller.SelectedButton(this);

				sprite.SetSprite(selectedSprite);
			}
		}

		public bool IsSelected()
		{
			return isSelected;
		}

		public void Deselect()
		{
			isSelected = false;
			sprite.SetSprite(unselectedSprite);
		}

		public override void OnDraw(SpriteBatch _spriteBatch)
		{
			if (IsEnabled())
			{
				sprite.OnDraw(_spriteBatch);
			}
		}
	}
}
