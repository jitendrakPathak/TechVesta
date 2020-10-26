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
        public static string SecretKey_Live { get; } = "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";
        public static string PublishableKey_Live { get; } = "pk_live_51HU7jIBuCXOoVi4eVfjOX1scTXroEIwDkVwWB5V74nBy6mKgneAuaxmYHv9BRWtsfQ78OGOfdo3PEhk4J3ySA9SI00NOBkCnc0";
    }
}
