namespace SongLoaderLite
{
    /// <summary>
    /// Song model class that will hold all of the information needed for our custom song
    /// </summary>
    class Song
    {
        //TODO: add in song properties that will be used throughout the program
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
