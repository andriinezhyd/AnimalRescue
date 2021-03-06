﻿using AnimalRescue.Contracts.BusinessLogic.Interfaces.CRUD;
using AnimalRescue.Contracts.BusinessLogic.Models;

using System.Collections.Generic;

namespace AnimalRescue.Contracts.BusinessLogic.Interfaces
{
    public interface ITagService :
        IBlCollectinQueryAsyncy<TagDto>,
        IBlOneItemQueryAsyncy<TagDto>,
        IBlCreateAsync<TagDto, TagDto>,
        IBlUpdateAsync<TagDto>,
        IBlDeleteAsync,
        IBlCreateIfNotExistAsync<IEnumerable<TagDto>>
    {
    }
}
