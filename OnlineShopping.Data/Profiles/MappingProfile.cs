namespace OnlineShopping.Data.Profiles
{
    public class MappingProfile
    {
        private readonly ProductsProfile _productsProfile;
        private readonly CategoriesProfile _categoriesProfile;
        private readonly UsersProfile _usersProfile;
        private readonly OrdersProfile _ordersProfile;

        public MappingProfile()
        {
            _productsProfile = new ProductsProfile();
            _categoriesProfile = new CategoriesProfile();
            _usersProfile = new UsersProfile();
            _ordersProfile = new OrdersProfile();
        }
    }
}
