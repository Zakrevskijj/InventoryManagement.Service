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
                //ToDo: Here we get product info from tag
                TDTEngine engine = new TDTEngine();
                string epcIdentifier = engine.HexToBinary(tag);
                string parameterList = @"tagLength=96";
                string tagData = engine.Translate(epcIdentifier, parameterList, @"TAG_ENCODING");
                //urn:epc:tag:sgtin-96:4.213645.6152432.887742324
                tagData = tagData.Remove(0, 21);
                var arr = tagData.Split('.');
                var companyPrefix = Int32.Parse(arr[1]);
                var itemReference= Int32.Parse(arr[2]);

                Company company = await _companiesRepository.GetCompanyByPrefixAsync(66);
                Product product = await _productsRepository.GetProductByCompanyAndItemReferenceAsync(company.Id, 6688);

                //ToDo: Handle errors above

                newInventory.Products.Add(product);
            }

            var newInventoryEntity = await _inventoriesRepository.AddAsync(newInventory);

            var newInventoryModel = ObjectMapper.Mapper.Map<InventoryModel>(newInventoryEntity);
            return newInventoryModel;
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
}