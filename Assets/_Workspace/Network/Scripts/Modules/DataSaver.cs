using UnityEngine;
using System.IO;

public class DataSaver
{
    private string _fileName;
    private string _editorDirectory;
    private string _path;

    public DataSaver(string fileName, string editorDirectory)
    {
        _fileName = fileName;
        _editorDirectory = editorDirectory;

#if UNITY_ANDROID && !UNITY_EDITOR
        _path = $"{Application.persistentDataPath}{Path.AltDirectorySeparatorChar}";
#else
        _path = $"{Application.dataPath}{_editorDirectory}";
#endif
    }

    public bool DataAvailable() =>
        File.Exists(_path + _fileName);

    public void SaveData(string text)
    {
        if (Directory.Exists(_path) == false)
            Directory.CreateDirectory(_path);

        using (var writer = new StreamWriter(_path + _fileName))
        {
            writer.WriteLine(text);
        }
    }

    public string LoadStringFormat()
    {
        string value = "";

        if (!File.Exists(_path + _fileName))
        {
            Debug.Log(_path + _fileName + " not found.");

            return value;
        }

        using (var reader = new StreamReader(_path + _fileName))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                value += line;
            }

            if (string.IsNullOrEmpty(value))
            {
                return value;
            }
        }

        return value;
    }

    public T LoadData<T>(T value)
    {
        if (!File.Exists(_path + _fileName))
            return value;

        string json = "";

        using (var reader = new StreamReader(_path + _fileName))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                json += line;
            }

            if (string.IsNullOrEmpty(json))
            {
                return value;
            }

            return JsonUtility.FromJson<T>(json);
        }
    }

    public T LoadDataBase<T>(T value)
    {
        if (!File.Exists(_path + _fileName))
            return value;

        string json = "";

        using (var reader = new StreamReader(_path + _fileName))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                json += line;
            }

            if (string.IsNullOrEmpty(json))
            {
                return value;
            }

            return JsonUtility.FromJson<T>(json);
        }
    }
}
