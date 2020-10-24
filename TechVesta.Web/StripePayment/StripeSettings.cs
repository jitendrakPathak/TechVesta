using System;
using Stripe;

namespace TechVesta.Web.StripePayment
{
    public class StripeSettings
    {
        public Decimal Amount { get; set; }
        public String ServiceName { get; set; }
    }

    public static class StripeKey
    {
        public static string SecretKey { get; } = "sk_test_51HU7jIBuCXOoVi4eAWSKdBwez7piMPfWEyyEhsavLLnCjoD4krj3XJmPr1DpwwER4oCzuZZHx1VUqD57wBEX1UMp00JCpQ73wR";
        public static string PublishableKey { get; } = "pk_test_51HU7jIBuCXOoVi4eZO6EZHhrSHMzSThuTFlqdy76imVvmu0x7USsN7vVY1B77paTCGolkGaXIoVXGGCfn6xz1OGB00bDWjLc0X";

}
}
