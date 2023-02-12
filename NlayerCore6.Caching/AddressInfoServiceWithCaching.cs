using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NLayerCore6.Core;
using NLayerCore6.Core.Repositories;
using NLayerCore6.Core.Services;
using NLayerCore6.Core.UnitOfWorks;
using NLayerCore6.Repository.Repositories;
using NLayerCore6.Service.Exceptions;
using System.Linq.Expressions;

namespace NLayerCore6.Caching
{
    public class AddressInfoServiceWithCaching : IService<AddressInfo>
    {
        private const string CacheAddressInfoKey = "addressInfosCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IGenericRepository<AddressInfo> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AddressInfoServiceWithCaching(IUnitOfWork unitOfWork, IGenericRepository<AddressInfo> repository, IMemoryCache memoryCache, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _memoryCache = memoryCache;
            _mapper = mapper;

            if (!_memoryCache.TryGetValue(CacheAddressInfoKey, out _))
            {
                _memoryCache.Set(CacheAddressInfoKey, _repository.GetAll().ToList());
            }


        }

        public async Task<AddressInfo> AddAsync(AddressInfo entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllAddressInfosAsync();
            return entity;
        }

        public async Task<IEnumerable<AddressInfo>> AddRangeAsync(IEnumerable<AddressInfo> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllAddressInfosAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<AddressInfo, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AddressInfo>> GetAllAsync()
        {

            var addressInfos = _memoryCache.Get<IEnumerable<AddressInfo>>(CacheAddressInfoKey);
            return Task.FromResult(addressInfos);
        }

        public Task<AddressInfo> GetByIdAsync(int id)
        {
            var addressInfo = _memoryCache.Get<List<AddressInfo>>(CacheAddressInfoKey).FirstOrDefault(x => x.Id == id);

            if (addressInfo == null)
            {
                throw new NotFoundExcepiton($"{typeof(AddressInfo).Name}({id}) not found");
            }

            return Task.FromResult(addressInfo);
        }

        public async Task RemoveAsync(AddressInfo entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllAddressInfosAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<AddressInfo> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllAddressInfosAsync();
        }

        public async Task UpdateAsync(AddressInfo entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllAddressInfosAsync();
        }

        public IQueryable<AddressInfo> Where(Expression<Func<AddressInfo, bool>> expression)
        {
            return _memoryCache.Get<List<AddressInfo>>(CacheAddressInfoKey).Where(expression.Compile()).AsQueryable();
        }


        public async Task CacheAllAddressInfosAsync()
        {
            _memoryCache.Set(CacheAddressInfoKey, await _repository.GetAll().ToListAsync());

        }
    }
}
