namespace OnlineShopping.Data.Profiles
{
    public class MappingProfile
    {
        private readonly ProductsProfile _productsProfile;
        private readonly CategoriesProfile _categoriesProfile;

        public MappingProfile()
        {
            _productsProfile = new ProductsProfile();
            _categoriesProfile = new CategoriesProfile();
        }
    }
}
