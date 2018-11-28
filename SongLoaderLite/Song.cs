namespace SongLoaderLite
{
    /// <summary>
    /// Song model class that will hold all of the information needed for our custom song
    /// </summary>
    class Song
    {
        string songName;
        string subSongName;
        string authorName;
        float bpm;
        float previewStartTime;
        float previewDuration;
        string coverImagePath;
        string environmentName;
        DifficultyLevel[] difficultyLevels;

    }
}
