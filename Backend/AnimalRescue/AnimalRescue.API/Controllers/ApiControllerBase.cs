﻿using AnimalRescue.API.Core.Responses;
using AnimalRescue.API.Models;
using AnimalRescue.Contracts.BusinessLogic.Interfaces;
using AnimalRescue.Contracts.BusinessLogic.Interfaces.CRUD;
using AnimalRescue.Contracts.BusinessLogic.Models;
using AnimalRescue.Contracts.Common.Query;

using AutoMapper;

using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalRescue.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
        private const string GetItemByIdMethodName = "Get";

        protected async Task<ActionResult<CollectionSegmentApiResponse<TResponse>>> GetCollectionAsync<TCollectin, TResponse>(
            IBlCollectinQueryAsyncy<TCollectin> service,
            ApiQueryRequest queryRequest,
            IMapper mapper)
            where TResponse : class
        {
            BlCollectonResponse<TCollectin> serviceResponse = await service.GetAsync(queryRequest);
            List<TResponse> result = mapper.Map<List<TCollectin>, List<TResponse>>(serviceResponse.Collection);

            return Collection(result, serviceResponse.TotalCount, queryRequest.Page, queryRequest.Size);
        }

        protected ActionResult<CollectionSegmentApiResponse<T>> Collection<T>(
            IReadOnlyCollection<T> source,
            int totalCount,
            int pageNumber,
            int pageSize)
            where T : class
        {
            if (!IsPagingValid(pageNumber, pageSize, totalCount))
            {
                return BadRequest("Page criteria oversizes the total quantity of items in the list.");
            }

            int pageCount = totalCount / pageSize + (totalCount % pageSize == 0 ? 0 : 1);

            return new CollectionSegmentApiResponse<T>
            {
                Data = source,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                PageCount = pageCount,
                Self = BuildSelf()
            };
        }

        protected async Task<ActionResult<TModel>> CreatedItemAsync<TDtoIn, TModel>(
            IBlCreateAsync<TDtoIn, TDtoIn> service,
            TModel value,
            IMapper mapper) where TModel : BaseModel
        {
            TDtoIn itemDto = mapper.Map<TModel, TDtoIn>(value);
            itemDto = await service.CreateAsync(itemDto);
            var itemModel = mapper.Map<TDtoIn, TModel>(itemDto);

            return CreatedItem(itemModel);
        }
        protected async Task<ActionResult<TOutModel>> CreatedItemAsync<TDto, TInModel, TOutModel>(
            IBlCreateAsync<TDto, TDto> service,            
            IDocumentService documentService,  
            TInModel value,       
            List<IFormFile> files,
            IMapper mapper) 
            where TOutModel : BaseModel
            where TDto : BaseCommonDto
        {
            TDto itemDto = mapper.Map<TInModel, TDto>(value);
            itemDto.ImageIds = await documentService.UploadFileAsync(files);
            itemDto = await service.CreateAsync(itemDto);
            var itemModel = mapper.Map<TDto, TOutModel>(itemDto);

            return CreatedItem(itemModel);
        }
        protected ActionResult<T> CreatedItem<T>(T item) where T : BaseModel
        {
            return CreatedAtAction(
                GetItemByIdMethodName,
                new { id = item.Id },
                BuildContentApiResponse(item));
        }

        protected async Task UpdateDataAsync<TDto, TModel>(
            IBlUpdateAsync<TDto> service,
            TModel value,
            IMapper mapper)
        {
            var dto = mapper.Map<TModel, TDto>(value);

            await service.UpdateAsync(dto);
        }
        protected async Task UpdateDataAsync<TDto, TModel>(
            IBlUpdateAsync<TDto> service,
            IDocumentService documentService,
            string id,
            TModel value,
            List<IFormFile> files,
            IMapper mapper)
            where TDto : BaseCommonDto
        {
            var dto = mapper.Map<TModel, TDto>(value);
            dto.Id = id;
            dto.ImageIds = await documentService.UploadFileAsync(files);

            await service.UpdateAsync(dto);
        }
        protected async Task<ActionResult<TModel>> GetItemAsync<TDto, TModel>(
            IBlOneItemQueryAsyncy<TDto> service,
            string id,
            IMapper mapper)
        {
            var data = await service.GetAsync(id);

            var result = mapper.Map<TModel>(data);

            return Item(result);
        }
        protected ActionResult<T> Item<T>(T source)
        {
            if (source == null)
            {
                return NotFound();
            }

            return Ok(BuildContentApiResponse(source));
        }

        protected ApiResponse EmptyContent()
        {
            return new ApiResponse
            {
                Self = BuildSelf()
            };
        }

        private static bool IsPagingValid(int pageNumber, int pageSize, int totalCount)
        {
            if (pageNumber > 1)
            {
                int startItemNumber = ((pageNumber - 1) * pageSize) + 1;
                return startItemNumber <= totalCount;
            }

            return true;
        }

        private ContentApiResponse<T> BuildContentApiResponse<T>(T source)
        {
            return new ContentApiResponse<T>
            {
                Data = source,
                Self = BuildSelf()
            };
        }

        private string BuildSelf()
        {
            return Request.GetUri().ToString();
        }
    }
}
