using ChanceNET;

namespace convey_cqrs_tests
{
    public static class TestUtils
    {
        public static string CreateUpc()
        {
            var chance = new Chance();
            return chance.Long(100000000000, 999999999999).ToString();
        }
    }
}
