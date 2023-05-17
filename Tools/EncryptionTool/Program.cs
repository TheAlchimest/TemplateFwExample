// See https://aka.ms/new-console-template for more information
using TemplateFw.Shared.Helpers;
while (true)
{
    Console.WriteLine("Enter Your text to encrypt:");
    var text = Console.ReadLine();
    string encryptedTxt = StringCipher.Encrypt(text);
    Console.WriteLine("your encrypted text:"+ encryptedTxt);
}

