namespace Collections
{
    public class Lists
    {
        public List<string> StringList { get; }
        
        public List<int> IntList { get;  }

        public Dictionary<int, string> IntStringDictionary { get;  }

        public List<List<string>> StringListInList { get; }

        public Lists()
        {
            StringList = new List<string> {
            "one",
            "two",
            "tree",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "ten",
            "ten",
            "ten",
            "ten"
            };
            IntList = new List<int> {1,2,3,4,5,6,7,8,9,10,10,10,10};

            IntStringDictionary = new Dictionary<int, string>
            {
                { 1, "one" },
                { 2, "two" },
                { 3, "three" },
                { 4, "four" },
                { 5, "five" },
                { 6, "six" },
                { 7, "seven" },
                { 8, "eight" },
                { 9, "nine" },
                { 10, "ten" },
                { 11, "ten" },
                { 12, "ten" },
                { 13, "thirteen" }
            };
            StringListInList = new List<List<string>>
            {
                new List<string> { "apple", "banana", "cherry" },
                new List<string> { "dog", "cat", "mouse" },
                new List<string> { "red", "green", "blue" }
            };
        }


    }
}
