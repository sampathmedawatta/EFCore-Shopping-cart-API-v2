using OnlineShopping.Common.Profiles;

namespace OnlineShopping.Business.Profiles
{
    public class MappingProfile
    {
        private readonly ProductsProfile _productsProfile;

        public MappingProfile()
        {
            _productsProfile = new ProductsProfile();
        }
    }
}
