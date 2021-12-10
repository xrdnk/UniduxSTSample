namespace Deniverse.UniduxSTSample.Domain.Unidux
{
    /// <summary>
    /// シーンファイル名の列挙隊
    /// <remarks>ここにUnityScene名を設定する</remarks>
    /// </summary>
    public enum SceneName
    {
        // Permanent
        EntryPoint,
        CommonSystem,
        UniduxService,

        // Title
        Title_UI,
        Title_Logic,

        // Main
        Main_UI,
        Main_Logic,
        Main_Level,

        // Result
        Result_UI,
        Result_Logic
    }
}