using System;
using Stripe;

namespace TechVesta.Web.Helper
{
    public class StripeSettings
    {
        public decimal Amount { get; set; }
        public string ServiceName { get; set; }
    }

    public static class StripeKey
    {
        public static string SecretKey_Test { get; } = "sk_test_51HU7jIBuCXOoVi4eAWSKdBwez7piMPfWEyyEhsavLLnCjoD4krj3XJmPr1DpwwER4oCzuZZHx1VUqD57wBEX1UMp00JCpQ73wR";
        public static string PublishableKey_Test { get; } = "pk_test_51HU7jIBuCXOoVi4eZO6EZHhrSHMzSThuTFlqdy76imVvmu0x7USsN7vVY1B77paTCGolkGaXIoVXGGCfn6xz1OGB00bDWjLc0X";
        public static string SecretKey_Live { get; } = "sk_test_51HU7jIBuCXOoVi4eAWSKdBwez7piMPfWEyyEhsavLLnCjoD4krj3XJmPr1DpwwER4oCzuZZHx1VUqD57wBEX1UMp00JCpQ73wR";
        public static string PublishableKey_Live { get; } = "pk_test_51HU7jIBuCXOoVi4eZO6EZHhrSHMzSThuTFlqdy76imVvmu0x7USsN7vVY1B77paTCGolkGaXIoVXGGCfn6xz1OGB00bDWjLc0X";
    }
}
