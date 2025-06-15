#nullable disable
public class ShortUrl
{
    public string ShortCode { get; set; }
    public string OriginalUrl { get; set; }

    public string GenerateUrlString()
    {

        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        int urlSize = random.Next(5, 8); // generates a random url size between 5-7
        char[] code = new char[urlSize];

        for (int i = 0; i < urlSize; i++)
        {
            code[i] = chars[random.Next(chars.Length)];
        }

        ShortCode = new string(code);
        return ShortCode;
    }
}