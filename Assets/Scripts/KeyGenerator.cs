
namespace Bounce.EventSystem 
{
    public static class KeyGenerator
    {
        private static int key;

        public static int GetKey() 
        {
            return ++key;
        }
    }
}


