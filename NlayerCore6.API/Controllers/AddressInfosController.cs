using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerCore6.API.Filters;
using NLayerCore6.Core;
using NLayerCore6.Core.DTOs;
using NLayerCore6.Core.Services;

namespace NLayerCore6.API.Controllers
{

    public class AddressInfosController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<AddressInfo> _addressInfoservice;

        public AddressInfosController(IMapper mapper, IService<AddressInfo> addressInfoservice)
        {
            _mapper = mapper;
            _addressInfoservice = addressInfoservice;
        }


        /// GET api/AddressInfos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var addressInfos = await _addressInfoservice.GetAllAsync();
            var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.ToList());
            return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));
        }


        [HttpGet("[action]")]
        public IActionResult Search(string? districtNameOrderBy, string? cityName, string? cityCode, string? districtName, string? zipCode)
        {
            if (cityName != null && cityCode != null && districtName != null && zipCode != null)
            {
                var addressInfos = _addressInfoservice.Where(x => x.CityName.Contains(cityName) && x.CityCode.Contains(cityCode) && x.DistrictName.Contains(districtName) && x.ZipCode.Contains(zipCode));

                if (districtNameOrderBy == "Descending")
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.OrderByDescending(i => i.DistrictName).ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));

                }
                if (districtNameOrderBy == "Ascending")
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.OrderBy(i => i.DistrictName).ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));

                }
                if (districtNameOrderBy == null)
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));
                }
            }
            else if (cityName == null && cityCode == null && districtName != null && zipCode != null)
            {
                var addressInfos = _addressInfoservice.Where(x => x.DistrictName.Contains(districtName) && x.ZipCode.Contains(zipCode));

                if (districtNameOrderBy == "Descending")
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.OrderByDescending(i => i.DistrictName).ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));

                }
                if (districtNameOrderBy == "Ascending")
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.OrderBy(i => i.DistrictName).ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));

                }
                if (districtNameOrderBy == null)
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));
                }
            }
            else if (cityName == null && cityCode != null && districtName == null && zipCode != null)
            {
                var addressInfos = _addressInfoservice.Where(x => x.CityCode.Contains(cityCode) && x.ZipCode.Contains(zipCode));

                if (districtNameOrderBy == "Descending")
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.OrderByDescending(i => i.DistrictName).ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));

                }
                if (districtNameOrderBy == "Ascending")
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.OrderBy(i => i.DistrictName).ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));

                }
                if (districtNameOrderBy == null)
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));
                }
            }
            else if (cityName == null && cityCode != null && districtName != null && zipCode == null)
            {
                var addressInfos = _addressInfoservice.Where(x => x.CityCode.Contains(cityCode) && x.DistrictName.Contains(districtName));

                if (districtNameOrderBy == "Descending")
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.OrderByDescending(i => i.DistrictName).ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));

                }
                if (districtNameOrderBy == "Ascending")
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.OrderBy(i => i.DistrictName).ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));

                }
                if (districtNameOrderBy == null)
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));
                }
            }
            else if (cityName != null && cityCode != null && districtName == null && zipCode == null)
            {
                var addressInfos = _addressInfoservice.Where(x => x.CityName.Contains(cityName) && x.CityCode.Contains(cityCode));

                if (districtNameOrderBy == "Descending")
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.OrderByDescending(i => i.DistrictName).ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));

                }
                if (districtNameOrderBy == "Ascending")
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.OrderBy(i => i.DistrictName).ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));

                }
                if (districtNameOrderBy == null)
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));
                }
            }
            else if (cityName != null && cityCode == null && districtName != null && zipCode == null)
            {
                var addressInfos = _addressInfoservice.Where(x => x.CityName.Contains(cityName) && x.DistrictName.Contains(districtName));

                if (districtNameOrderBy == "Descending")
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.OrderByDescending(i => i.DistrictName).ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));

                }
                if (districtNameOrderBy == "Ascending")
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.OrderBy(i => i.DistrictName).ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));

                }
                if (districtNameOrderBy == null)
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));
                }
            }
            else if (cityName != null && cityCode == null && districtName == null && zipCode != null)
            {
                var addressInfos = _addressInfoservice.Where(x => x.CityName.Contains(cityName) && x.ZipCode.Contains(zipCode));

                if (districtNameOrderBy == "Descending")
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.OrderByDescending(i => i.DistrictName).ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));

                }
                if (districtNameOrderBy == "Ascending")
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.OrderBy(i => i.DistrictName).ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));

                }
                if (districtNameOrderBy == null)
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));
                }
            }
            else if (cityName != null && cityCode == null && districtName == null && zipCode == null)
            {
                var addressInfos = _addressInfoservice.Where(x => x.CityName.Contains(cityName));

                if (districtNameOrderBy == "Descending")
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.OrderByDescending(i => i.DistrictName).ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));

                }
                if (districtNameOrderBy == "Ascending")
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.OrderBy(i => i.DistrictName).ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));

                }
                if (districtNameOrderBy == null)
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));
                }
            }
            else if (cityName == null && cityCode != null && districtName == null && zipCode == null)
            {
                var addressInfos = _addressInfoservice.Where(x => x.CityCode.Contains(cityCode));

                if (districtNameOrderBy == "Descending")
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.OrderByDescending(i => i.DistrictName).ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));

                }
                if (districtNameOrderBy == "Ascending")
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.OrderBy(i => i.DistrictName).ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));

                }
                if (districtNameOrderBy == null)
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));
                }
            }
            else if (cityName == null && cityCode == null && districtName != null && zipCode == null)
            {
                var addressInfos = _addressInfoservice.Where(x => x.DistrictName.Contains(districtName));

                if (districtNameOrderBy == "Descending")
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.OrderByDescending(i => i.DistrictName).ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));

                }
                if (districtNameOrderBy == "Ascending")
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.OrderBy(i => i.DistrictName).ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));

                }
                if (districtNameOrderBy == null)
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));
                }
            }
            else if (cityName == null && cityCode == null && districtName == null && zipCode != null)
            {
                var addressInfos = _addressInfoservice.Where(x => x.ZipCode.Contains(zipCode));

                if (districtNameOrderBy == "Descending")
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.OrderByDescending(i => i.DistrictName).ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));

                }
                if (districtNameOrderBy == "Ascending")
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.OrderBy(i => i.DistrictName).ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));

                }
                if (districtNameOrderBy == null)
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));
                }
            }
            else if (cityName == null && cityCode == null && districtName == null && zipCode == null)
            {
                var addressInfos = _addressInfoservice.Where(x => x.DistrictName != null);

                if (districtNameOrderBy == "Descending")
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.OrderByDescending(i => i.DistrictName).ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));

                }
                if (districtNameOrderBy == "Ascending")
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.OrderBy(i => i.DistrictName).ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));

                }
                if (districtNameOrderBy == null)
                {
                    var addressInfosDtos = _mapper.Map<List<AddressInfoDto>>(addressInfos.ToList());
                    return CreateActionResult(CustomResponseDto<List<AddressInfoDto>>.Success(200, addressInfosDtos));
                }
            }
            return CreateActionResult(CustomResponseDto<List<NoContentDto>>.Fail(404, "Not Found"));
        }


        [ServiceFilter(typeof(NotFoundFilter<AddressInfo>))]
        //GET /api/AddressInfos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var addressInfos = await _addressInfoservice.GetByIdAsync(id);
            var addressInfosDto = _mapper.Map<AddressInfoDto>(addressInfos);
            return CreateActionResult(CustomResponseDto<AddressInfoDto>.Success(200, addressInfosDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(AddressInfoDto addressInfoDto)
        {
            var addressInfos = await _addressInfoservice.AddAsync(_mapper.Map<AddressInfo>(addressInfoDto));
            var addressInfosDto = _mapper.Map<AddressInfoDto>(addressInfos);
            return CreateActionResult(CustomResponseDto<AddressInfoDto>.Success(201, addressInfosDto));
        }


        [HttpPut]
        public async Task<IActionResult> Update(AddressInfoDto addressInfoDto)
        {
            await _addressInfoservice.UpdateAsync(_mapper.Map<AddressInfo>(addressInfoDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        // DELETE api/AddressInfos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var addressInfos = await _addressInfoservice.GetByIdAsync(id);

            await _addressInfoservice.RemoveAsync(addressInfos);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
