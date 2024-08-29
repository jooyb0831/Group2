public static class VSDefine
{
    public enum GameState
    {
        play,
        end
    }
    public static GameState gameState = GameState.play;

    public static int presentStage = 1;

    public static int killCut = 0;
    public static float speedTimer = 0;
    public static float speedDelay = 7;
}
