using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
//using Newtonsoft.Json;

public class FileStorage<T>
{
    private readonly string _filePath;

    public FileStorage(string filePath)
    {
        _filePath = filePath;
    }

    // 從文件中讀取數據
    public List<T> Load()
    {
        if (!File.Exists(_filePath))
        {
            // 文件不存在時，自動創建一個空的 JSON 文件
            Save(new List<T>());
            return new List<T>();
        }

        try
        {
            string jsonData = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<T>>(jsonData) ?? new List<T>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"讀取文件時發生錯誤：{ex.Message}");
            return new List<T>();
        }
    }

    // 將數據保存到文件
    public void Save(List<T> data)
    {
        try
        {
            string jsonData = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, jsonData);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"保存文件時發生錯誤：{ex.Message}");
        }
    }
}
