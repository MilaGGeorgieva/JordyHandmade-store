namespace JordyHandmade.Common
{
    public static class EntityValidationConstants
    {
        public static class Category 
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 40;

            public const int DescriptionMinLength = 20;
            public const int DescriptionMaxLength = 200;
        }
        
        public static class Product 
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 50;

            public const int DescriptionMinLength = 20;
            public const int DescriptionMaxLength = 300;

            public const int ImageUrlMinLength = 10;
            public const int ImageUrlMaxLength = 2048;

            public const string PriceMinValue = "1";
            public const string PriceMaxValue = "2000";

            //public const decimal PriceMinValue = 0.01m;
            //public const decimal PriceMaxValue = 2000.00m;

            public const int QuantityInStockMinValue = 0;
            public const int QuantityInStockMaxValue = 50; 
        }

        public static class Supplier 
        {
            public const int SupplierNameMinLength = 4;
            public const int SupplierNameMaxLength = 50;

            public const int WebAddressMinLength = 10;
            public const int WebAddressMaxLength = 100;
            public const string WebAddressRegEx = @"(http://|https://|www.)[a-zA-Z0-9\-]+.(com|bg|org|us|uk)";
 

            public const int EmailAddressMinLength = 10;
            public const int EmailAddressMaxLength = 50;
            public const string EmailAddressRegEx = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;

        }

        public static class PartsInProduct 
        {
            public const int NameMinLength = 10;
            public const int NameMaxLength = 50;

            public const int DescriptionMinLength = 20;
            public const int DescriptionMaxLength = 50;

            public const string PriceMinValue = "1";
            public const string PriceMaxValue = "2000";

            public const int MeasureUnitMinLength = 2;
            public const int MeasureUnitMaxLength = 10;
        }
        
        public static class Address 
        {
            public const int StreetAddressMinLength = 10;
            public const int StreetAddressMaxLength = 50;
        }

        public static class Town 
        {
            public const int NameMinLength = 4;
            public const int NameMaxLength = 50;

            public const int ZipLength = 4;
            public const string ZipRegEx = @"^[0-9]*$";
        }
        
        public static class Order 
        {
            public const int DiscountMinValue = 5;
            public const int DiscountMaxValue = 20;
            public const int OrderStatusMin = 0;
            public const int OrderStatusMax = 5;
        }

        public static class ClientCard 
        {
            public const int BonusPointsMinValue = 1;
            public const int BonusPointsMaxValue = 100;
        }

        public static class Customer 
        {
            public const int CustomerNameMinLength = 6;
            public const int CustomerNameMaxLength = 70;
            
            public const int CustomerRatingMin = 1;
            public const int CustomerRatingMax = 3;

            public const int EmailAddressMinLength = 10;
            public const int EmailAddressMaxLength = 50;
            public const string EmailAddressRegEx = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

            public const int PhoneNumberMinLength = 7;
            public const int PhoneNumberMaxLength = 15;
        }
    }
}
