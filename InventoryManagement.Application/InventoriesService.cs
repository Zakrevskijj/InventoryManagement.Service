using InventoryManagement.Application.Interfaces;
using InventoryManagement.Application.Mapper;
using InventoryManagement.Application.Models;
using InventoryManagement.Core.Entities;
using InventoryManagement.Core.Repositories;
using TagDataTranslation;

namespace InventoryManagement.Application
{
    public class InventoriesService : IInventoriesService
    {
        private readonly IInventoriesRepository _inventoriesRepository;
        private readonly IProductsRepository _productsRepository;
        private readonly ICompaniesRepository _companiesRepository;

        public InventoriesService(
            IInventoriesRepository inventoriesRepository,
            IProductsRepository productsRepository,
            ICompaniesRepository companiesRepository)
        {
            _inventoriesRepository = inventoriesRepository;
            _productsRepository = productsRepository;
            _companiesRepository = companiesRepository;
        }

        public async Task<InventoryModel> CreateInventoryAsync(InventoryModel inventoryModel, ICollection<string> productTags)
        {
            await ValidateIfInventoryExists(inventoryModel);

            var newInventory = ObjectMapper.Mapper.Map<Inventory>(inventoryModel);
            if (newInventory == null)
            {
                //ToDo: Throw good exception here
                throw new Exception($"Unable to map");
            }

            foreach (var tag in productTags)
            {
                var productData = FetchProductData(tag);

                Company company = await _companiesRepository.GetCompanyByPrefixAsync(productData.CompanyPrefix);
                Product product = await _productsRepository.GetProductByCompanyAndItemReferenceAsync(company.Id, productData.ItemReference);

                //ToDo: Handle errors above

                newInventory.Products.Add(product);
            }

            var newInventoryEntity = await _inventoriesRepository.AddAsync(newInventory);

            var newInventoryModel = ObjectMapper.Mapper.Map<InventoryModel>(newInventoryEntity);
            return newInventoryModel;
        }

        //ToDo: Move into a separate service
        private static ProductData FetchProductData(string tag)
        {
            TDTEngine engine = new TDTEngine();
            string epcIdentifier = engine.HexToBinary(tag);
            string parameterList = @"tagLength=96";
            string tagData = engine.Translate(epcIdentifier, parameterList, @"TAG_ENCODING");

            tagData = tagData.Remove(0, 21);
            var arr = tagData.Split('.');

            return new ProductData(int.Parse(arr[1]), int.Parse(arr[2]));
        }

        public Task<ICollection<ProductsCountForCompanyModel>> GetProductsCountPerCompany()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ProductsCountForDayPerProductModel>> GetProductsCountPerDayPerProduct()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ProductCountModel>> GetProductsCountPerProductByInventoryExternalId(string externalInventoryId)
        {
            throw new NotImplementedException();
        }

        public Task ProcessInventoryDataAsync(InventoryModel inventoryModel, ICollection<string> productTags)
        {
            throw new NotImplementedException();
        }

        private async Task ValidateIfInventoryExists(InventoryModel inventoryModel)
        {
            //ToDo: Check if inventory exists better here
            var existingEntity = await _inventoriesRepository.GetByIdAsync(inventoryModel.Id);
            if (existingEntity != null)
            {
                //ToDo: Throw good exception here
                throw new Exception($"{inventoryModel} with this id already exists");
            }
        }
    }

    internal class ProductData
    {
        public int CompanyPrefix { get; }
        public int ItemReference { get; }

        public ProductData(int companyPrefix, int itemReference)
        {
            CompanyPrefix = companyPrefix;
            ItemReference = itemReference;
        }

        public override bool Equals(object? obj)
        {
            return obj is ProductData other &&
                   CompanyPrefix == other.CompanyPrefix &&
                   ItemReference == other.ItemReference;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CompanyPrefix, ItemReference);
        }
    }
}