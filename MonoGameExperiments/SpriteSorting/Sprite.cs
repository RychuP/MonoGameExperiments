using Microsoft.Xna.Framework.Graphics;

namespace MonoGameExperiments.SpriteSorting;

internal class Sprite : DrawableGameComponent
{
    readonly SpriteSortingSample _parent;
    readonly string _textureName;
    readonly float _layer;
    readonly int _offsetX;
    Texture2D _texture;
    Manager Manager => Game as Manager;

    string Name => $"{_textureName[0]}".ToUpper() + _textureName[1..];

    public Sprite(string textureName, int drawOrder, float layer, int offsetX, SpriteSortingSample parent) 
        : base(parent.Game)
    {
        _textureName = textureName;
        _parent = parent;
        _layer = layer;
        _offsetX = offsetX;
        DrawOrder = drawOrder;
        Game.Components.Add(this);
    }

    protected override void LoadContent()
    {
        _texture = Game.Content.Load<Texture2D>($"Art/{_textureName}");
    }

    public override string ToString()
    {
        return $"{Name, -8}: DrawOrder {DrawOrder}, Layer: {_layer}";
    }

    public override void Draw(GameTime gameTime)
    {
        Manager.SpriteBatch.Draw(_texture, _parent.GetCenteredPosition(_texture) + Vector2.UnitX * _offsetX,
            _texture.Bounds, Color.White, 0, Vector2.Zero, 1.3f, SpriteEffects.None, _layer);
        //_parent.SpriteBatch.Draw(_texture, _parent.GetCenteredPosition(_texture), Color.White);
    }
}