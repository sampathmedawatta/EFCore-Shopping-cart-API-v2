namespace OnlineShopping.Data.Profiles
{
    public class MappingProfile
    {
        private readonly ProductsProfile _productsProfile;
        private readonly CategoriesProfile _categoriesProfile;
        private readonly UsersProfile _usersProfile;
        public MappingProfile()
        {
            _productsProfile = new ProductsProfile();
            _categoriesProfile = new CategoriesProfile();
            _usersProfile = new UsersProfile();
        }
    }
}
