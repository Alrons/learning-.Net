namespace Collections
{
    public class Lists
{
    public List<string> stringList { get; set; }
        
    public List<int> intList { get; set; }

    public Lists()
    {
        stringList = new List<string> {
        "one",
        "two",
        "tree",
        "four",
        "five",
        "six",
        "seven",
        "eght",
        "nine",
        "ten"
        };
        intList = new List<int> {1,2,3,4,5,6,7,8,9,10};
    }

}
}
