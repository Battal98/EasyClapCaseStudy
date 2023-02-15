using System;
using SaveLoadModule.Enums;
using SaveLoadModule.Interfaces;

namespace LevelModule.Data
{
    [Serializable]
    public class LevelData: ISavable
    {
        public int Value;

        private const SaveLoadType Key = SaveLoadType.LevelData; 

        public SaveLoadType GetKey()
        {
            return Key;
        }
        public LevelData()
        {
            
        }
        public LevelData(int value)
        {
           Value = value;
        }
    } 
}
