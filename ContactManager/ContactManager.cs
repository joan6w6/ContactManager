using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ContactManager
{
    private readonly FileStorage<Contact> _storage;
    private List<Contact> _contacts;

    public ContactManager(string filePath)
    {
        _storage = new FileStorage<Contact>(filePath);
        _contacts = _storage.Load(); // 從文件加載數據
    }

    private void SaveContacts()
    {
        _storage.Save(_contacts); // 保存數據到文件
    }

    public void DisplayAllContacts()
    {
        if (_contacts.Count == 0)
        {
            Console.WriteLine("目前沒有聯絡人！");
            return;
        }

        Console.WriteLine("\n所有聯絡人：");
        foreach (var contact in _contacts)
        {
            Console.WriteLine(contact);
        }
    }

    public void AddContact()
    {
        Console.Write("輸入聯絡人姓名：");
        string name = Console.ReadLine();

        Console.Write("輸入聯絡人電話號碼：");
        string phone = Console.ReadLine();

        _contacts.Add(new Contact { Name = name, PhoneNumber = phone });
        SaveContacts();

        Console.WriteLine("聯絡人已添加！");
    }

    public void DeleteContact()
    {
        Console.Write("輸入要刪除的聯絡人姓名：");
        string name = Console.ReadLine();

        var contact = _contacts.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (contact != null)
        {
            _contacts.Remove(contact);
            SaveContacts();
            Console.WriteLine("聯絡人已刪除！");
        }
        else
        {
            Console.WriteLine("未找到該聯絡人！");
        }
    }

    public void SearchContact()
    {
        Console.Write("輸入要搜索的聯絡人姓名或電話：");
        string query = Console.ReadLine();

        var results = _contacts.Where(c =>
            c.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
            c.PhoneNumber.Contains(query)).ToList();

        if (results.Count == 0)
        {
            Console.WriteLine("未找到匹配的聯絡人！");
            return;
        }

        Console.WriteLine("\n搜索結果：");
        foreach (var contact in results)
        {
            Console.WriteLine(contact);
        }
    }
}

