namespace NetGenericApp
{
    struct Passport<T>
    {
        public T Seria { get; set; }
        public int Number { get; set; }
    }
    class Person<T> where T : Message
    {
        public T Id { set; get; }
        public string Name { set; get; } = null!;
        public Person(T id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    class Employe<T, U> : Person<T> where T : EmailMessage where U : class
    {
        public T Code { set; get; }
        public Employe(T id, string name) : base(id, name) { }
    }

    class Citizen : Person<string>
    {
        public Citizen(string id, string name) : base(id, name) { }
    }

    class User<T> : Person<int>
    {
        public T Code { set; get; }
        public User(int id, string name) : base(id, name) { }
    }

    static class Operations
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            (a, b) = (b, a);
        }
    }
    class Message
    {
        public string Text { set; get; }
        public Message(string text)
        {
            Text = text;
        }
    }
    class EmailMessage : Message
    {
        public EmailMessage(string text) : base(text) { }
    }
    class SmsMessage : Message
    {
        public SmsMessage(string text) : base(text) { }
    }
    interface IExamp
    {
        string Text { set; get; }
    }
    class Messanger<T> where T : Message, IExamp, new()
    {
        public void SendMessage(T message)
        {
            Console.WriteLine($"Send message: {message.Text}");
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            SendMessage<EmailMessage>(new EmailMessage("from ivan to petya"));
        }

        static void SendMessage<T>(T message) where T : Message
        {
            Console.WriteLine($"Send message: {message.Text}");
        }

        static void PersonExample()
        {
            Person<string> person1 = new("AS-67", "Bob");
            Person<int> person2 = new(123, "Bob");
            Person<Passport<int>> person3;

            int id = person2.Id;
            string ids = person1.Id;

            int n = 20;
            int m = 30;
            Operations.Swap(ref n, ref m);
            float x = 10.5f;
            float y = 20.5f;
            Operations.Swap(ref x, ref y);
        }
    }
}