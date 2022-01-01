using System;
using System.Collections.Generic;
using System.Security.Principal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace grid_engine
{
    public class Engine : EngineGame
    {
        public readonly GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;

        private Stage _stage;
        public static bool Debug = true;
        public static Texture2D Pixel;
        public static Texture2D x32Miss;

        public InputActionManager GameplayActions;
        public InputActionManager InventoryActions;
        

        public enum Actions
        {
            Enter,
            Down,
            Left,
            Right,
            Up,
            Escape,
            Inventory,
            E,
            Q,
            Skills,
            LeftClicked,
            MenuDown,
            MenuUp,
            MenuYes,
            MenuNo
        }

        public StageManager StageManager = new StageManager();
        
        public Engine()
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
            StageManager.Stages.AddFirst(new LinkedListNode<Stage>(new Stage()));
            StageManager.Stages.AddLast(new LinkedListNode<Stage>(new Stage()));
            StageManager.Stages.AddLast(new LinkedListNode<Stage>(new Stage()));
            StageManager.Stages.AddLast(new LinkedListNode<Stage>(new Stage()));
        }

        public static void Write(string s)
        {
            if (!Debug) return;
            Console.Write(s);
        }
        
        public static void WriteLine(string s)
        {
            if (!Debug) return;
            Console.WriteLine(s);
        }

        protected override void Initialize()
        {
            _stage = new Stage();

            GameplayActions = new InputActionManager();
            InventoryActions = new InputActionManager();
            
            var inputAction = new InputAction((int)Actions.Escape, TriggerState.Pressed)
            {
                GamePadButton = Buttons.Start,
                KeyButton = Keys.Escape
            };
            
            GameplayActions.MapAction(inputAction);
            InventoryActions.MapAction(inputAction);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Pixel = Content.Load<Texture2D>("p_w");
            x32Miss = Content.Load<Texture2D>("x32Miss");
            
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (Inventory)
            {
                InventoryActions.Update();
                
                Window.Title = "Inventory";
            }
            else
            {
                GameplayActions.Update();
                Window.Title = "Gameplay";
            }
            
            _stage.Update(gameTime);

            if (GameplayActions.IsActionTriggered((int)Actions.Escape))
            {
                //Inventory = !Inventory;
            }
            
            if (InventoryActions.IsActionTriggered((int)Actions.Escape))
            {
                Inventory = !Inventory;
            }
            
            base.Update(gameTime);
        }

        public bool Inventory { get; set; } = true;

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}