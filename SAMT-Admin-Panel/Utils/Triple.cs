namespace WebUI.Utils
{
    public class Triple<T, U, V>
    {
        public Triple()
        {
        }

        public Triple(T first, U second, V third)
        {
            First = first;
            Second = second;
            Third = third;
        }

        public T First { get; set; }
        public U Second { get; set; }
        public V Third { get; set; }
    };
}
