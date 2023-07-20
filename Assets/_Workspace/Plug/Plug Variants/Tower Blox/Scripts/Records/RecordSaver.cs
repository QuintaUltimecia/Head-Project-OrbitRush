using UnityEngine;

namespace Tower_Bloxx
{
    public static class RecordSaver
    {
        private static string _key = "record";

        public static void SaveRecord(int value) =>
            PlayerPrefs.SetInt(_key, value);

        public static int GetRecord() =>
            PlayerPrefs.GetInt(_key);
    }
}