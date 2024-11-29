using System;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "contacts.json"; // 聯絡人數據文件
        var manager = new ContactManager(filePath);

        while (true)
        {
            Console.WriteLine("\n聯絡人管理系統");
            Console.WriteLine("1. 查看所有聯絡人");
            Console.WriteLine("2. 添加聯絡人");
            Console.WriteLine("3. 刪除聯絡人");
            Console.WriteLine("4. 搜索聯絡人");
            Console.WriteLine("5. 退出");
            Console.Write("請選擇操作：");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.DisplayAllContacts();
                    break;
                case "2":
                    manager.AddContact();
                    break;
                case "3":
                    manager.DeleteContact();
                    break;
                case "4":
                    manager.SearchContact();
                    break;
                case "5":
                    Console.WriteLine("退出系統...");
                    return;
                default:
                    Console.WriteLine("無效的選項，請重新選擇！");
                    break;
            }
        }
    }
}
