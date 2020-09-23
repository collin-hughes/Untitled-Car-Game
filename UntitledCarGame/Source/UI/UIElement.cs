using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace UntitledCarGame.UI
{
	abstract class UIElement
	{
		protected Vector2 position;
		protected float rotation;
		protected bool enabled;
		protected bool interactable;
		protected Color color;
		protected UICanvas canvas;
		protected bool active;
		public UIElement(ref UICanvas _canvas, Vector2 _position , Color _color, float _rotation = 0f, bool _enabled = true, bool _interactable = true)
		{
			canvas = _canvas;
			active = false;

			canvas.AddElement(this);

			position = _position;
			rotation = _rotation;

			color = _color;

			SetEnabled(_enabled);
			SetInteractable(_interactable);
		}

		public Vector2 GetPosition()
		{
			return position;
		}

		public void SetPosition(Vector2 _position)
		{
			position = _position;
		}

		public void SetPosition(float _positionX, float _positionY)
		{
			position = new Vector2(_positionX, _positionY);
		}

		public float GetRotation()
		{
			return rotation;
		}

		public bool IsEnabled()
		{
			return enabled;
		}

		public bool IsInteractable()
		{
			return interactable;
		}

		public void SetEnabled(bool _enabled)
		{
			enabled = _enabled;
		}

		public void SetInteractable(bool _interactable)
		{
			interactable = _interactable;

			if(!interactable)
			{
				color = new Color(color, .65f);
			}

			else
			{
				color = new Color(color, 1f);
			}
		}

		public void SetActive(bool _active)
		{
			active = _active;
		}

		public void ToggleEnabled()
		{
			SetEnabled(!enabled);
		}

		public void ToggleInteractable()
		{
			SetInteractable(!interactable);
		}
	
		abstract public void OnDraw(SpriteBatch _spriteBatch);
	}
}
