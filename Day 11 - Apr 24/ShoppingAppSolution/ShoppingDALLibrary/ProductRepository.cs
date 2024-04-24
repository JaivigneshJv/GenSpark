using ShoppingModelLibrary;

namespace ShoppingDALLibrary
{
    public class ProductRepository : AbstractRepository<int, Product>
    {
        public override Product Delete(int key)
        {
            throw new NotImplementedException();
        }

        public override Product GetByKey(int key)
        {
            throw new NotImplementedException();
        }

        public override Product Update(Product item)
        {
            throw new NotImplementedException();
        }
    }
}
