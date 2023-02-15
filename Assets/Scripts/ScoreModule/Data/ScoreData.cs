using SaveLoadModule.Enums;
using SaveLoadModule.Interfaces;
using System;

namespace ScoreModule.Data
{
    [Serializable]
    public class ScoreData : ISavable
    {
        public int TotalBlueScore;
        public int TotalGreenScore;
        private const SaveLoadType Key = SaveLoadType.ScoreData;
        public ScoreData(int greenScore, int blueScore)
        {
            TotalBlueScore = blueScore;
            TotalGreenScore = greenScore;
        }
        public ScoreData()
        {

        }
        public SaveLoadType GetKey()
        {
            return Key;
        }
    } 
}
