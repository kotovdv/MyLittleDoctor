using UnityEngine.Assertions;

namespace MyLittleDoctor.Util
{
    public static class AssertExt
    {
        public static T IsNotNull<T>(T value, string message = "Value can not be null") where T : class
        {
            Assert.IsNotNull(value, message);
            return value;
        }
    }
}