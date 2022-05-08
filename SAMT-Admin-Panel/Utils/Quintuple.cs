namespace WebUI.Utils
{
    public class Quintuple<T, U, V, Y, X>
    {
        public Quintuple()
        {
        }

        public Quintuple(T first, U second, V third, Y fourth, X fifth)
        {
            First = first;
            Second = second;
            Third = third;
            Fourth = fourth;
            Fifth = fifth;
        }

        public T First { get; set; }
        public U Second { get; set; }
        public V Third { get; set; }
        public Y Fourth { get; set; }
        public X Fifth { get; set; }
    };
}
