namespace WebUI.Utils
{
    public class Quadruple<T, U, V, Y>
    {
        public Quadruple()
        {
        }

        public Quadruple(T first, U second, V third, Y fourth)
        {
            First = first;
            Second = second;
            Third = third;
            Fourth = fourth;
        }

        public T First { get; set; }
        public U Second { get; set; }
        public V Third { get; set; }
        public Y Fourth { get; set; }
    };
}
