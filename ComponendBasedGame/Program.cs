using ComponentBasedGame.Model;
using Raylib_cs;





Game.Instance.Init();

// Main game loop
while (!Raylib.WindowShouldClose()) // Detect window close button or ESC key
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.SkyBlue);
    Raylib.BeginBlendMode(BlendMode.Multiplied);
    Game.Instance.Update(Raylib.GetFrameTime());
    Raylib.EndBlendMode();
    Raylib.DrawFPS(10, 10);
    Raylib.EndDrawing();
}
Raylib.CloseWindow();
